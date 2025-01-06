using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;
using NotesApp.Application.Features.Priorities.Commands.UpdatePriority;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Priority.Commands.UpdatePriority
{
    [TestFixture]
    public class UpdatePriorityCommandHandlerTest
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
        public async Task UpdatePriorityCommand_ReturnNotNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new UpdatePriorityCommandHandler(unitOfWork!.Object);
            await handler.Handle(new UpdatePriorityCommand() { Name = "Generic", Id = _prioId }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Priorities.First(x => x.Name == "Generic");
            Assert.That(entity, Is.Not.Null);
        }
    }
}
