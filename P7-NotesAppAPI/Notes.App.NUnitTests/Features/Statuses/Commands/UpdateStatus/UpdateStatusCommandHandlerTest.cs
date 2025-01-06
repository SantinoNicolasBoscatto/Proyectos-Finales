using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;
using NotesApp.Application.Features.Statuses.Commands.UpdateStatus;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Statuses.Commands.UpdateStatus
{
    [TestFixture]
    public class UpdateStatusCommandHandlerTest
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
        public async Task UpdateStatusCommand_ReturnNotNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new UpdateStatusCommandHandler(unitOfWork!.Object);
            await handler.Handle(new UpdateStatusCommand() { Name = "Generic", Id = _statusId }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Status.First(x => x.Name == "Generic");
            Assert.That(entity, Is.Not.Null);
        }
    }
}
