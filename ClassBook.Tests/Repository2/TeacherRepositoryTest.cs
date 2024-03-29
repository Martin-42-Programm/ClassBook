using System;
namespace ClassBook.Tests.Repository

namespace ClassBook.Tests.Repository
{
    public class TeacherRepositoryTest
    {
        private var teacherRepositoryMock;

        public TeacherRepositoryTest()
        {
            teacherRepositoryMock = SetUpTeacherRepositoryMock();
        }

        [Test]
        public void GetById_ExistingTeacherId_ReturnsTeacher()
        {
            // Arrange
            var teacherId = "1";
            var expectedTeacher = new Teacher { Id = teacherId, Name = "Mr. Draganov", Subject = "Math" };

            teacherRepositoryMock.Setup(repo => repo.GetById(teacherId)).Returns(expectedTeacher);

            // Act
            var result = teacherRepositoryMock.Object.GetById(teacherId);

            // Assert
            Assert.AreEqual(expectedTeacher, result);
        }

        [Test]
        public void GetById_NonExistingTeacherId_ReturnsNull()
        {
            // Arrange
            var teacherId = "100";

            // Act
            var result = teacherRepositoryMock.Object.GetById(teacherId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllTeachers()
        {
            // Arrange
            var expectedTeachers = new List<Teacher>
            {
                new Teacher { Id = "1", Name = "Mr. Draganov", Subject = "Math" },
                new Teacher { Id = "2", Name = "Ms. Ivanova", Subject = "Science" }
            };

            teacherRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedTeachers);

            // Act
            var result = teacherRepositoryMock.Object.GetAll();

            // Assert
            Assert.AreEqual(expectedTeachers, result);
        }

        [Test]
        public void Add_Teacher_AddsToRepository()
        {
            // Arrange
            var newTeacher = new Teacher { Id = "3", Name = "Mr.Petkov", Subject = "English" };

            // Act
            teacherRepositoryMock.Object.Add(newTeacher);

            // Assert
            teacherRepositoryMock.Verify(repo => repo.Add(It.IsAny<Teacher>()), Times.Once);
        }

        [Test]
        public void Remove_ExistingTeacher_RemovesFromRepository()
        {
            // Arrange
            var teacherIdToRemove = "2";

            // Act
            teacherRepositoryMock.Object.Remove(teacherIdToRemove);

            // Assert
            teacherRepositoryMock.Verify(repo => repo.Remove(teacherIdToRemove), Times.Once);
        }

        [Test]
        public void Remove_NonExistingTeacher_NoActionTaken()
        {
            // Arrange
            var teacherIdToRemove = "100";

            // Act
            teacherRepositoryMock.Object.Remove(teacherIdToRemove);

            // Assert
            teacherRepositoryMock.Verify(repo => repo.Remove(teacherIdToRemove), Times.Never);
        }

        private var SetUpTeacherRepositoryMock()
        {
            var teacherRepositoryMock = new Mock<ITeacherRepository>();

            return teacherRepositoryMock;
        }
    }
}