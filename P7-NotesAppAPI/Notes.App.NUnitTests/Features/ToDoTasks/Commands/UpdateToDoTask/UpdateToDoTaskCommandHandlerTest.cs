using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.ToDoTasks.Commands.CreateToDoTask;
using NotesApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.ToDoTasks.Commands.UpdateToDoTask
{
    [TestFixture]
    public class UpdateToDoTaskCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private string _userId = "d6d94155-1a3f-4ce5-a819-eba202ed823d";
        private int _priorityId;
        private int _statusId;
        private int _taskId;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context, true);
            _priorityId = unitOfWork.Object.Context.Priorities.First().Id;
            _statusId = unitOfWork.Object.Context.Status.First().Id;
            _taskId = unitOfWork.Object.Context.ToDoTasks.First(x => x.NoteId == 8001).Id;
        }

        [Test]
        public async Task UpdateToDoTaskCommand_ReturnNotNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new UpdateToDoTaskCommandHandler(unitOfWork!.Object);
            await handler.Handle(new UpdateToDoTaskCommand()
            {
                ToDoTaskId = _taskId,
                IdentityUserId = _userId,
                NoteId = 8001,
                StatusId = _statusId,
                PriorityId = _priorityId,
                Name = "TestPrueba",
                DateLimit = DateTime.Now,
                Description = "Description",
            }, new CancellationToken());
            var entity = unitOfWork.Object.Context.ToDoTasks.First(x => x.Name == "TestPrueba");
            Assert.That(entity, Is.Not.Null);
        }
    }
}
