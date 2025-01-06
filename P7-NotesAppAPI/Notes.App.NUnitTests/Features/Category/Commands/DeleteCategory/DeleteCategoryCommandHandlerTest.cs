using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Commands.DeleteCategory;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Category.Commands.DeleteCategory
{
    [TestFixture]
    public class DeleteCategoryCommandHandlerTest
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
        public async Task DeleteCategoryCommand_ReturnNull()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new DeleteCategoryCommandHandler(unitOfWork!.Object);
            await handler.Handle(new DeleteCategoryCommand() { Id = _catId }, new CancellationToken());
            var entity = unitOfWork.Object.Context.Categories.Find(_catId);
            Assert.That(entity, Is.Null);
        }
    }
}
