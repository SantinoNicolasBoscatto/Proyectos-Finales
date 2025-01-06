using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Notes.Queries.GetNoteById;
using NotesApp.Application.Features.Notes.Queries.GetNotesPerUser;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Notes.Queries.GetNoteById
{
    [TestFixture]
    public class GetNoteByIdHandlerNUnitTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private readonly string _userId = "d6d94155-1a3f-4ce5-a819-eba202ed823d";

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
        }

        [Test]
        public async Task GetNoteByIdHandler_ReturnsNotNull()
        {
            var handler = new GetNoteByIdQueryHandler(unitOfWork!.Object);
            var note = await handler.Handle(new GetNoteByIdQuery() { IdentityUserId = _userId, NoteId = 8001 }, new CancellationToken());
            unitOfWork.Object.Dispose();
            Assert.That(note, Is.Not.Null);
            Assert.That(note.Id, Is.EqualTo(8001));
            Assert.That(note.IdentityUserId, Is.EqualTo(_userId));
        }
    }
}
