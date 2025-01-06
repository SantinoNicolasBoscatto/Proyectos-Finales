using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.ToDoTasks.Commands.CreateToDoTask;
using NotesApp.Repository;
using NUnit.Framework;


namespace Notes.App.NUnitTests.Features.ToDoTasks.Commands.CreateToDoTask
{
    [TestFixture]
    public class CreateToDoTaskCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private string _userId = "d6d94155-1a3f-4ce5-a819-eba202ed823d";
        private int _priorityId;
        private int _statusId;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
            _priorityId = unitOfWork.Object.Context.Priorities.First().Id;
            _statusId = unitOfWork.Object.Context.Status.First().Id;
        }

        [Test]
        public async Task CreateToDoTaskCommand_ReturnNotNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new CreateToDoTaskCommandHandler(unitOfWork!.Object);
            await handler.Handle(new CreateToDoTaskCommand()
            { 
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
