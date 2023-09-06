//using CleanUserManagement.API.Controllers;
//using CleanUserManagement.Application;// For UserManagementController
//using CleanUserManagement.Domain;
//using Microsoft.AspNetCore.Mvc;            // For NotFoundResult, OkObjectResult, etc.
//using Moq;                                // For Mock<>
//using System.Collections.Generic;          // For List<>
//using Xunit;                              // For [Fact] and Assert methods


//namespace YourProjectName.UnitTests.API
//{
//    public class UserManagementControllerTests
//    {
//        private readonly UserManagementController _controller;
//        private readonly Mock<IUserService> _mockService;

//        public UserManagementControllerTests()
//        {
//            _mockService = new Mock<IUserService>();
//            _controller = new UserManagementController(_mockService.Object);
//        }

//        [Fact]
//        public void Get_ReturnsAllUsers()
//        {
//            var mockUsers = new List<User>
//            {
//                new User { Username = "user1" },
//                new User { Username = "user2" }
//            };

//            _mockService.Setup(s => s.GetAllUsers()).Returns(mockUsers);

//            var result = _controller.Get();

//            var okResult = Assert.IsType<OkObjectResult>(result.Result);
//            var returnedUsers = Assert.IsType<List<User>>(okResult.Value);

//            Assert.Equal(2, returnedUsers.Count);
//        }

//        [Fact]
//        public void GetUserByUsername_ReturnsNotFound_WhenUserIsMissing()
//        {
//            _mockService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns((User)null);

//            var result = _controller.GetUserByUsername("missingUser");

//            Assert.IsType<NotFoundResult>(result.Result);
//        }

//        [Fact]
//        public void GetUserByUsername_ReturnsUser_WhenUserExists()
//        {
//            var mockUser = new User { Username = "existingUser" };
//            _mockService.Setup(s => s.GetUserByUsername("existingUser")).Returns(mockUser);

//            var result = _controller.GetUserByUsername("existingUser");

//            var okResult = Assert.IsType<OkObjectResult>(result.Result);
//            var returnedUser = Assert.IsType<User>(okResult.Value);

//            Assert.Equal("existingUser", returnedUser.Username);
//        }

//        [Fact]
//        public void CreateUser_ReturnsBadRequest_WhenUserCreationFails()
//        {
//            var mockUser = new User { Username = "newUser" };
//            _mockService.Setup(s => s.CreateUser(mockUser)).Returns((null, "Creation Failed"));

//            var result = _controller.CreateUser(mockUser);

//            Assert.IsType<BadRequestObjectResult>(result.Result);
//        }

//        [Fact]
//        public void CreateUser_ReturnsCreatedUser_WhenSuccessful()
//        {
//            var mockUser = new User { Username = "newUser" };
//            _mockService.Setup(s => s.CreateUser(mockUser)).Returns((mockUser, "Creation Successful"));

//            var result = _controller.CreateUser(mockUser);

//            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
//            var returnedUser = Assert.IsType<User>(createdAtActionResult.Value);

//            Assert.Equal("newUser", returnedUser.Username);
//        }

//        [Fact]
//        public void UpdateUser_ReturnsBadRequest_WhenUsernameMismatch()
//        {
//            var mockUser = new User { Username = "updatedUser" };

//            var result = _controller.UpdateUser("differentUsername", mockUser);

//            Assert.IsType<BadRequestObjectResult>(result);
//        }

//        [Fact]
//        public void UpdateUser_ReturnsBadRequest_WhenUpdateFails()
//        {
//            var mockUser = new User { Username = "updatedUser" };
//            _mockService.Setup(s => s.UpdateUser(mockUser)).Returns((null, "Update Failed"));

//            var result = _controller.UpdateUser("updatedUser", mockUser);

//            Assert.IsType<BadRequestObjectResult>(result);
//        }

//        [Fact]
//        public void UpdateUser_ReturnsUpdatedUser_WhenSuccessful()
//        {
//            var mockUser = new User { Username = "updatedUser" };
//            _mockService.Setup(s => s.UpdateUser(mockUser)).Returns((mockUser, "Update Successful"));

//            var result = _controller.UpdateUser("updatedUser", mockUser);

//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedUser = Assert.IsType<User>(okResult.Value);

//            Assert.Equal("updatedUser", returnedUser.Username);
//        }

//        [Fact]
//        public void Delete_ReturnsNotFound_WhenDeletionMessageIsEmpty()
//        {
//            _mockService.Setup(s => s.DeleteUser("existingUser")).Returns(string.Empty);

//            var result = _controller.Delete("existingUser");

//            Assert.IsType<NotFoundObjectResult>(result);
//        }

//        [Fact]
//        public void Delete_ReturnsOk_WhenUserSuccessfullyDeleted()
//        {
//            _mockService.Setup(s => s.DeleteUser("existingUser")).Returns("User deleted successfully.");

//            var result = _controller.Delete("existingUser");

//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var message = Assert.IsType<string>(okResult.Value);

//            Assert.Equal("User deleted successfully.", message);
//        }
//    }
//}
