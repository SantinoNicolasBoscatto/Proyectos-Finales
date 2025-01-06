using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Queries;
using NotesApp.Application.Features.Priorities.Queries;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Priority.Queries
{
    [TestFixture]
    public class GetPrioritiesQueryHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
        }

        [Test]
        public async Task GetCategoriesQuery_ReturnsNotNullNotEmpty()
        {
            var handler = new GetPrioritiesQueryHandler(unitOfWork!.Object);
            var list = await handler.Handle(new GetPrioritiesQuery(), new CancellationToken());
            unitOfWork.Object.Dispose();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
    }
}
