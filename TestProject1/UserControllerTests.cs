using Devops1.Controllers;
using Devops1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class UserControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Index_Post_WithValidUserInfo_ReturnsViewResultWithUserInfo()
        {
            // Arrange
            var controller = new UserController();
            var userInfo = new UserInfo { Firstname = "John ", Lastname="Coe",yearOfBirth = 2000, Email = "john@example.com", Mobile = "1234567890" };

            // Act
            var result = controller.Index(userInfo) as ViewResult;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(userInfo, result.Model);
        }

        [Fact]
        public void Index_Post_WithInvalidUserInfo_ReturnsViewResultWithModelError()
        {
            // Arrange
            var controller = new UserController();
            var invalidUserInfo = new UserInfo(); // Creating an invalid user info object with required fields missing
            controller.ModelState.AddModelError("Name", "The Name field is required.");
            controller.ModelState.AddModelError("Age", "The Age field is required.");

            // Act
            var result = controller.Index(invalidUserInfo) as ViewResult;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
        }
    }
}
