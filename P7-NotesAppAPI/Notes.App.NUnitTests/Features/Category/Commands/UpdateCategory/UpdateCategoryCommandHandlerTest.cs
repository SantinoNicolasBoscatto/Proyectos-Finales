using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Category.Commands.UpdateCategory
{
    [TestFixture]
    public class UpdateCategoryCommandHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;
        private int _catId;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            unitOfWork.Setup(x => x.Dispose()).Callback(() => { Console.WriteLine("Dispose method called"); });
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
            _catId = unitOfWork.Object.Context.Categories.First().Id;
        }

        [Test]
        public async Task UpdateCategoryCommand_ReturnNotNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new UpdateCategoryCommandHandler(unitOfWork!.Object);
            await handler.Handle(new UpdateCategoryCommand() { Name = "Generic", Id = _catId }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Categories.First(x => x.Name == "Generic");
            Assert.That(entity, Is.Not.Null);
        }
    }
}
