using System;
namespace ClassBook.Tests.Repository

namespace ClassBook.Tests.Repository
{
    public class StudentRepositoryTest
    {
        private var studentRepositoryMock;

        public StudentRepositoryTest()
        {
            studentRepositoryMock = SetUpStudentRepositoryMock();
        }

        [Test]
        public void GetById_ExistingStudentId_ReturnsStudent()
        {
            // Arrange
            var studentId = "1";
            var expectedStudent = new Student { Id = studentId, Name = "John", Age = 15 };

            studentRepositoryMock.Setup(repo => repo.GetById(studentId)).Returns(expectedStudent);

            // Act
            var result = studentRepositoryMock.Object.GetById(studentId);

            // Assert
            Assert.AreEqual(expectedStudent, result);
        }

        [Test]
        public void GetById_NonExistingStudentId_ReturnsNull()
        {
            // Arrange
            var studentId = "100";

            // Act
            var result = studentRepositoryMock.Object.GetById(studentId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllStudents()
        {
            // Arrange
            var expectedStudents = new List<Student>
            {
                new Student { Id = "1", Name = "Valentin", Age = 17 },
                new Student { Id = "2", Name = "Martin", Age = 18 }
            };

            studentRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedStudents);

            // Act
            var result = studentRepositoryMock.Object.GetAll();

            // Assert
            Assert.AreEqual(expectedStudents, result);
        }

        [Test]
        public void Add_Student_AddsToRepository()
        {
            // Arrange
            var newStudent = new Student { Id = "3", Name = "Bob", Age = 17 };

            // Act
            studentRepositoryMock.Object.Add(newStudent);

            // Assert
            studentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Student>()), Times.Once);
        }

        [Test]
        public void Remove_ExistingStudent_RemovesFromRepository()
        {
            // Arrange
            var studentIdToRemove = "2";

            // Act
            studentRepositoryMock.Object.Remove(studentIdToRemove);

            // Assert
            studentRepositoryMock.Verify(repo => repo.Remove(studentIdToRemove), Times.Once);
        }

        [Test]
        public void Remove_NonExistingStudent_NoActionTaken()
        {
            // Arrange
            var studentIdToRemove = "100";

            // Act
            studentRepositoryMock.Object.Remove(studentIdToRemove);

            // Assert
            studentRepositoryMock.Verify(repo => repo.Remove(studentIdToRemove), Times.Never);
        }

        private var SetUpStudentRepositoryMock()
        {
            var studentRepositoryMock = new Mock<IStudentRepository>();

            return studentRepositoryMock;
        }
    }
}