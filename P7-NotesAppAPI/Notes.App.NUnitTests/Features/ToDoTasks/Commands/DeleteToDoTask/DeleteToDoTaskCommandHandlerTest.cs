using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.DeleteCategory;
using NotesApp.Application.Features.ToDoTasks.Commands.DeleteToDoTask;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.ToDoTasks.Commands.DeleteToDoTask
{
    [TestFixture]
    public class DeleteToDoTaskCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private string _userId = "d6d94155-1a3f-4ce5-a819-eba202ed823d";
        private int _taskId;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context, true);
            _taskId = unitOfWork.Object.Context.ToDoTasks.First(x => x.NoteId == 8001).Id;
        }

        [Test]
        public async Task DeleteToDoTaskCommand_ReturnNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new DeleteToDoTaskCommandHandler(unitOfWork!.Object);
            await handler.Handle(new DeleteToDoTaskCommand() { IdentityUserId = _userId, ToDoTaskId = _taskId }, new CancellationToken());
            var entity = unitOfWork.Object.Context.ToDoTasks.Find(_taskId);
            Assert.That(entity, Is.Null);
        }
    }
}
