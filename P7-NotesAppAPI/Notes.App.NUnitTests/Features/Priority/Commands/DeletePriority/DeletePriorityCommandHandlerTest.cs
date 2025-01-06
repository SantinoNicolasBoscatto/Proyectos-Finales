using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.DeleteCategory;
using NotesApp.Application.Features.Priorities.Commands.DeletePriority;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Priority.Commands.DeletePriority
{
    [TestFixture]
    public class DeletePriorityCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private int _prioId;


        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
            _prioId = unitOfWork.Object.Context.Priorities.First().Id;
        }

        [Test]
        public async Task DeletePriorityCommand_ReturnNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new DeletePriorityCommandHandler(unitOfWork!.Object);
            await handler.Handle(new DeletePriorityCommand() { Id = _prioId }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Priorities.Find(_prioId);
            Assert.That(entity, Is.Null);
        }
    }
}
