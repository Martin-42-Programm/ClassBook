using System;
namespace ClassBook.Tests.Repository
{
    public class SubjectRepositoryTest
    {
        private var subjectRepositoryMock;

        public SubjectRepositoryTest()
        {
            subjectRepositoryMock = SetUpSubjectRepositoryMock();
        }

        [Test]
        public void GetById_ExistingSubjectId_ReturnsSubject()
        {
            // Arrange
            var subjectId = "1";
            var expectedSubject = new Subject { Id = subjectId, Name = "Mathematics", Teacher = "Mr. Draganov" };

            subjectRepositoryMock.Setup(repo => repo.GetById(subjectId)).Returns(expectedSubject);

            // Act
            var result = subjectRepositoryMock.Object.GetById(subjectId);

            // Assert
            Assert.AreEqual(expectedSubject, result);
        }

        [Test]
        public void GetById_NonExistingSubjectId_ReturnsNull()
        {
            // Arrange
            var subjectId = "100";

            // Act
            var result = subjectRepositoryMock.Object.GetById(subjectId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllSubjects()
        {
            // Arrange
            var expectedSubjects = new List<Subject>
            {
                new Subject { Id = "1", Name = "Mathematics", Teacher = "Mr. Draganov" },
                new Subject { Id = "2", Name = "Science", Teacher = "Ms. Ivanova" }
            };

            subjectRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedSubjects);

            // Act
            var result = subjectRepositoryMock.Object.GetAll();

            // Assert
            Assert.AreEqual(expectedSubjects, result);
        }

        [Test]
        public void Add_Subject_AddsToRepository()
        {
            // Arrange
            var newSubject = new Subject { Id = "3", Name = "History", Teacher = "Mrs. Petkov" };

            // Act
            subjectRepositoryMock.Object.Add(newSubject);

            // Assert
            subjectRepositoryMock.Verify(repo => repo.Add(It.IsAny<Subject>()), Times.Once);
        }

        [Test]
        public void Remove_ExistingSubject_RemovesFromRepository()
        {
            // Arrange
            var subjectIdToRemove = "2";

            // Act
            subjectRepositoryMock.Object.Remove(subjectIdToRemove);

            // Assert
            subjectRepositoryMock.Verify(repo => repo.Remove(subjectIdToRemove), Times.Once);
        }

        [Test]
        public void Remove_NonExistingSubject_NoActionTaken()
        {
            // Arrange
            var subjectIdToRemove = "100";

            // Act
            subjectRepositoryMock.Object.Remove(subjectIdToRemove);

            // Assert
            subjectRepositoryMock.Verify(repo => repo.Remove(subjectIdToRemove), Times.Never);
        }

        private var SetUpSubjectRepositoryMock()
        {
            var subjectRepositoryMock = new Mock<ISubjectRepository>();

            return subjectRepositoryMock;
        }
    }
}