using Microsoft.EntityFrameworkCore;
using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.Application.Features.Notes.Queries.GetNotesPerUser;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Notes.Commads.CreateNote
{
    [TestFixture]
    public class CreateNoteCommandHandlerTest
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
        }

        [Test]
        public async Task CreateNoteCommand_ReturnNotNull()
        {
            var handler = new CreateNoteCommandHandler(unitOfWork!.Object);
            await handler.Handle(new CreateNoteCommand() { IdentityUserId = _userId,  CategoryId = _catId, Name = "Generic", 
                 Description= "Generic"}, new CancellationToken());
            var entity = unitOfWork.Object.Context.Notes.First(x => x.IdentityUserId == _userId && x.Name == "Generic");
            Assert.That(entity, Is.Not.Null);
        }
    }
}
