using Moq;
using Notes.App.NUnitTests.Mocks;
using NotesApp.Application.Features.Notes.Queries.GetNotesPerUser;
using NotesApp.Repository;
using NUnit.Framework;


namespace Notes.App.NUnitTests.Features.Notes.Queries.GetNotesPerUser
{
    [TestFixture]
    public class GetNotesPerUserQueryHandlerNUnitTests
    {
        private Mock<UnitOfWork>? unitOfWork;
        private readonly string _userId = "d6d94155-1a3f-4ce5-a819-eba202ed823d";

        [SetUp]
        public void Setup()
        {
            unitOfWork = MockUnitOfWork.GetUnitOfWork();
            MockDataGenerator.AddNotesRepository(unitOfWork.Object.Context);
        }

        [Test]
        public async Task GetNotesPerUserQuery_ReturnsNotNullNotEmptyCountOne()
        {
            var handler = new GetNotesPerUserQueryHandler(unitOfWork!.Object);
            var list = await handler.Handle(new GetNotesPerUserQuery() { IdentityUserId = _userId }, new CancellationToken());
            unitOfWork.Object.Dispose();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.Count, Is.EqualTo(1));
        }
    }
}
