using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Categorys.Queries;
using NotesApp.Application.Features.Statuses.Queries;
using NotesApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Features.Statuses.Queries
{
    [TestFixture]
    public class GetStatusQueryHandlerTest
    {
        private Mock<UnitOfWork>? unitOfWork;

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
        }

        [Test]
        public async Task GetStatusQuery_ReturnsNotNullNotEmpty()
        {
            unitOfWork!.Object.Context.ChangeTracker.Clear();
            var handler = new GetStatusQueryHandler(unitOfWork!.Object);
            var list = await handler.Handle(new GetStatusQuery(), new CancellationToken());
            unitOfWork.Object.Dispose();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
        }
    }
}
