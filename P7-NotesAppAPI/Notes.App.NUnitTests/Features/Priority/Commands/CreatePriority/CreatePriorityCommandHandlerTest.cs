using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.Priorities.Commands.CreatePriority;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Priority.Commands.CreatePriority
{
    [TestFixture]
    public class CreatePriorityCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
        }

        [Test]
        public async Task CreatePriorityCommand_ReturnNotNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new CreatePriorityCommandHandler(unitOfWork!.Object);
            await handler.Handle(new CreatePriorityCommand() { Name = "Generic" }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Priorities.First(x => x.Name == "Generic");
            Assert.That(entity, Is.Not.Null);
        }
    }
}
