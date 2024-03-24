using System;
namespace ClassBook.Tests.Services
{
	public class UserServiceTest
	{
        private UserService UserService;
        private Mock<IUserService> UserServiceMock;
        private Mock<IUserRepository> UserRepositoryMock;
        private UserManager<User> userManager;
        private Mock<IUserStore<User>> userStoreMock;


        public UserServiceTest()
        {
            UserRepositoryMock = SetUpGradeRepositoryMock();
            UserServiceMock = new Mock<IUserService>();
            userStoreMock = new Mock<IUserStore<User>>();
            userManager = new UserManager<User>(userStoreMock.Object, null, null, null, null, null, null, null, null);
            UserService = new UserService(UserRepositoryMock.Object, userManager);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllUsers()
        {
            
            var expectedUsers = new List<UserViewModel> {
    
            new UserViewModel("azz", "a@b.bg", "UserName", "Student"),
            new UserViewModel ("amz", "b@b.bg", "UserName2", "Admin")};
        
    
            UserRepositoryMock.Setup(repo => repo.GetAll())
                              .Returns(expectedUsers);
           
            var users = UserService.GetAll();

           
            Assert.IsNotNull(users);
            Assert.AreEqual(expectedUsers.Count, users.Count());
            CollectionAssert.AreEquivalent(expectedUsers, users);
        }

        /*[Test]
        public async Task GetAllAsync_WhenCalled_ReturnsAllUsers()
        {
            // Arrange
            var expectedUsers = new List<UserViewModel>
    {
        new UserViewModel("aaaa", "a@g.m", "UserName", "Role"),
        new UserViewModel("bbbb", "s@h.j", "UserName2", "Role")
        
    };
          
            var users = await UserService.GetAllAsync();

            // Assert
            Assert.IsNotNull(users);
            Assert.AreEqual(expectedUsers.Count, users.Count());
            CollectionAssert.AreEquivalent(expectedUsers, users);
        }*/




        private Mock<IUserRepository> SetUpGradeRepositoryMock()
        {
            var UserRepositoryMock = new Mock<IUserRepository>();

            return UserRepositoryMock;
        }

    }
}

