using Microsoft.EntityFrameworkCore;
using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.Application.Features.Notes.Commands.UpdateNote;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Notes.Commads.UpdateNote
{
    [TestFixture]
    public class UpdateNoteCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private readonly string _userId = "d6d94155-1a3f-4ce5-a819-eba202ed823d";
        private int _catId;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
            var cat = unitOfWork.Object.Context.Categories.First(x => x.Notes.Any(n => n.Id == 8001));
            _catId = cat.Id;
            unitOfWork.Object.Context.ChangeTracker.Clear();
        }

        [Test]
        public async Task CreateNoteCommand_ReturnNotNull()
        {
            var handler = new UpdateNoteCommandHandler(unitOfWork!.Object);
            await handler.Handle(new UpdateNoteCommand()
            {
                Id = 8001,
                IdentityUserId = _userId,
                CategoryId = _catId,
                Name = "Generic",
            }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Notes.Find(8001);
            Assert.That(entity, Is.Not.Null);
        }
    }
}
