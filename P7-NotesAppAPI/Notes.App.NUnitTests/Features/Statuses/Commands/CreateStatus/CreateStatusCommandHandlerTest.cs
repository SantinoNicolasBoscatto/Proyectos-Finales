using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.Statuses.Commands.CreateStatus;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Statuses.Commands.CreateStatus
{
    [TestFixture]
    public class CreateStatusCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
        }

        [Test]
        public async Task CreateStatusCommand_ReturnNotNull()
        {
            var handler = new CreateStatusCommandHandler(unitOfWork!.Object);
            await handler.Handle(new CreateStatusCommand() { Name = "Generic" }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Status.First(x => x.Name == "Generic");
            Assert.That(entity, Is.Not.Null);
        }
    }
}
