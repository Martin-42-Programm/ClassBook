using System;
namespace ClassBook.Tests.Repository

namespace ClassBook.Tests.Repository
{
    public class ClassRepositoryTest
    {
        private var classRepositoryMock;

        public ClassRepositoryTest()
        {
            classRepositoryMock = SetUpClassRepositoryMock();
        }

        [Test]
        public void GetById_ExistingClassId_ReturnsClass()
        {
            // Arrange
            var classId = "1";
            var expectedClass = new Class { Id = classId, ClassName = "11A", Year = 2024 };

            classRepositoryMock.Setup(repo => repo.GetById(classId)).Returns(expectedClass);

            // Act
            var result = classRepositoryMock.Object.GetById(classId);

            // Assert
            Assert.AreEqual(expectedClass, result);
        }

        [Test]
        public void GetById_NonExistingClassId_ReturnsNull()
        {
            // Arrange
            var classId = "100";

            // Act
            var result = classRepositoryMock.Object.GetById(classId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllClasses()
        {
            // Arrange
            var expectedClasses = new List<Class>
            {
                new Class { Id = "1", ClassName = "11A", Year = 2023 },
                new Class { Id = "2", ClassName = "11B", Year = 2023 }
            };

            classRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedClasses);

            // Act
            var result = classRepositoryMock.Object.GetAll();

            // Assert
            Assert.AreEqual(expectedClasses, result);
        }

        [Test]
        public void Add_Class_AddsToRepository()
        {
            // Arrange
            var newClass = new Class { Id = "3", ClassName = "12A", Year = 2024 };

            // Act
            classRepositoryMock.Object.Add(newClass);

            // Assert
            classRepositoryMock.Verify(repo => repo.Add(It.IsAny<Class>()), Times.Once);
        }

        [Test]
        public void Remove_ExistingClass_RemovesFromRepository()
        {
            // Arrange
            var classIdToRemove = "2";

            // Act
            classRepositoryMock.Object.Remove(classIdToRemove);

            // Assert
            classRepositoryMock.Verify(repo => repo.Remove(classIdToRemove), Times.Once);
        }

        [Test]
        public void Remove_NonExistingClass_NoActionTaken()
        {
            // Arrange
            var classIdToRemove = "100";

            // Act
            classRepositoryMock.Object.Remove(classIdToRemove);

            // Assert
            classRepositoryMock.Verify(repo => repo.Remove(classIdToRemove), Times.Never);
        }

        private var SetUpClassRepositoryMock()
        {
            var classRepositoryMock = new Mock<IClassRepository>();

            return classRepositoryMock;
        }
    }
}