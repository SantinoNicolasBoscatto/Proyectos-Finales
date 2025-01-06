using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.Repository;
using NUnit.Framework;

namespace Notes.App.NUnitTests.Features.Category.Commands.CreateCategory
{
    [TestFixture]
    public class CreateCategoryCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
        }

        [Test]
        public async Task CreateCategoryCommand_ReturnNotNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new CreateCategoryCommandHandler(unitOfWork!.Object);
            await handler.Handle(new CreateCategoryCommand(){Name = "Generic"}, new CancellationToken());
            var entity = unitOfWork.Object.Context.Categories.First(x => x.Name == "Generic");
            Assert.That(entity, Is.Not.Null);
        }
    }
}
