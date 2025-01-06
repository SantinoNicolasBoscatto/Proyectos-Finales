using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.DeleteCategory;
using NotesApp.Application.Features.Statuses.Commands.DeleteStatus;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Statuses.Commands.DeleteStatus
{
    [TestFixture]
    public class DeleteStatusCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private int _statusId;


        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
            _statusId = unitOfWork.Object.Context.Status.First().Id;
        }

        [Test]
        public async Task DeleteStatusCommand_ReturnNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new DeleteStatusCommandHandler(unitOfWork!.Object);
            await handler.Handle(new DeleteStatusCommand() { Id = _statusId }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Status.Find(_statusId);
            Assert.That(entity, Is.Null);
        }
    }
}
