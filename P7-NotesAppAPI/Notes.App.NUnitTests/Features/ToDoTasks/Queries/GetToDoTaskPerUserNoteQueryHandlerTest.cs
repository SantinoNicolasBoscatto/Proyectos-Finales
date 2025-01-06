using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.ToDoTasks.Commands.DeleteToDoTask;
using NotesApp.Application.Features.ToDoTasks.Queries.GetToDoTaskPerUserNote;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.ToDoTasks.Queries
{
    [TestFixture]
    public class GetToDoTaskPerUserNoteQueryHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private string _userId = "d6d94155-1a3f-4ce5-a819-eba202ed823d";

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context, true);
        }

        [Test]
        public async Task DeleteToDoTaskCommand_ReturnNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new GetToDoTasksPerUserNoteQueryHandler(unitOfWork!.Object);
            var list = await handler.Handle(new GetToDoTasksPerUserNoteQuery() { IdentityUserId = _userId, NoteId = 8001, Asc = false, 
                Priority = false, Status = false }, new CancellationToken());
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.Count, Is.GreaterThan(1));
        }
    }
}
