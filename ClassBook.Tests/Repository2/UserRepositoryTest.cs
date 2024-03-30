using System;
namespace ClassBook.Tests.Repository

namespace ClassBook.Tests.Repository
{
    public class UserRepositoryTest
    {
        private var userRepositoryMock;

        public UserRepositoryTest()
        {
            userRepositoryMock = SetUpUserRepositoryMock();
        }

        [Test]
        public void GetById_ExistingUserId_ReturnsUser()
        {
            // Arrange
            var userId = "1";
            var expectedUser = new User { Id = userId, Username = "Valcho2", Email = "valcho@gmail.com" };

            userRepositoryMock.Setup(repo => repo.GetById(userId)).Returns(expectedUser);

            // Act
            var result = userRepositoryMock.Object.GetById(userId);

            // Assert
            Assert.AreEqual(expectedUser, result);
        }

        [Test]
        public void GetById_NonExistingUserId_ReturnsNull()
        {
            // Arrange
            var userId = "100";

            // Act
            var result = userRepositoryMock.Object.GetById(userId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllUsers()
        {
            // Arrange
            var expectedUsers = new List<User>
            {
                new User { Id = "1", Username = "Valcho2", Email = "valcho@gmail.com" },
                new User { Id = "2", Username = "Marto2", Email = "mivanov@gmail.com" }
            };

            userRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedUsers);

            // Act
            var result = userRepositoryMock.Object.GetAll();

            // Assert
            Assert.AreEqual(expectedUsers, result);
        }

        [Test]
        public void Add_User_AddsToRepository()
        {
            // Arrange
            var newUser = new User { Id = "3", Username = "Petko", Email = "petko@gmail.com" };

            // Act
            userRepositoryMock.Object.Add(newUser);

            // Assert
            userRepositoryMock.Verify(repo => repo.Add(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void Remove_ExistingUser_RemovesFromRepository()
        {
            // Arrange
            var userIdToRemove = "2";

            // Act
            userRepositoryMock.Object.Remove(userIdToRemove);

            // Assert
            userRepositoryMock.Verify(repo => repo.Remove(userIdToRemove), Times.Once);
        }

        [Test]
        public void Remove_NonExistingUser_NoActionTaken()
        {
            // Arrange
            var userIdToRemove = "100";

            // Act
            userRepositoryMock.Object.Remove(userIdToRemove);

            // Assert
            userRepositoryMock.Verify(repo => repo.Remove(userIdToRemove), Times.Never);
        }

        private var SetUpUserRepositoryMock()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            return userRepositoryMock;
        }
    }
}