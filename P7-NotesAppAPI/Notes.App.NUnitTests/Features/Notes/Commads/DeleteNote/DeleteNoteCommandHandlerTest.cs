using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Notes.Commands.DeleteNote;
using NotesApp.Application.Features.Notes.Commands.UpdateNote;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Notes.Commads.DeleteNote
{
    public class DeleteNoteCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private readonly string _userId = "d6d94155-1a3f-4ce5-a819-eba202ed823d";

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => {Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
            unitOfWork.Object.Context.ChangeTracker.Clear();
        }

        [Test]
        public async Task DeleteNoteCommand_ReturnNull()
        {
            var handler = new DeleteNoteCommandHandler(unitOfWork!.Object);
            await handler.Handle(new DeleteNoteCommand()
            {
                IdentityUserId = _userId,
                NoteId = 8001
            }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Notes.Find(8001);
            Assert.That(entity, Is.Null);
        }
    }
}
