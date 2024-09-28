

using AndresAlarcon.TaskManager.API.Controllers;
using AndresAlarcon.TaskManager.API.Helpers;
using AndresAlarcon.TaskManager.Application.DTOs;
using AndresAlarcon.TaskManager.Application.Security;
using AndresAlarcon.TaskManager.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;

namespace AndresAlarcon.TaskManager.Test.User
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IOptions<JwtSecuritySettings>> _jwtSettingsMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _jwtSettingsMock = new Mock<IOptions<JwtSecuritySettings>>();
            _userController = new UserController(_userServiceMock.Object, _jwtSettingsMock.Object);
        }

        [Fact]
        public void Echo_ReturnsOkResult_WithCorrectMessage()
        {
            // Arrange
            string input = "prueba ECHO";
            string expectedMessage = $"Ejecución correcta: {input}";

            // Act
            ActionResult<string> result = _userController.Echo(input);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedMessage, okResult.Value);
        }

        [Fact]
        public async void Register_ReturnsOkResult_WithSuccessMessage()
        {
            // Arrange
            UserDTO userDto = new()
            {
                UserName = "testuser",
                Email = "test@example.com",
                ConfirmEmail = "test@example.com",
                PasswordHash = "hashedPassword",
                ConfirmPassword = "hashedPassword",
                RolId = 1,
                IsEnabled = true
            };

            Response expectedResponse = new ()
            {
                IsSuccess = true,
                Message = "Usuario creado con exito"
            };

            _userServiceMock.Setup(service => service.RegisterAsync(userDto))
                .ReturnsAsync(new UserDTO());

            // Act
            ActionResult<Response> result = await _userController.Register(userDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); 
            var response = Assert.IsType<Response>(okResult.Value);
            Assert.True(response.IsSuccess);
            Assert.Equal(expectedResponse.Message, response.Message);
        }

        [Fact]
        public async void Register_ReturnsConflictResult_WithErrorMessage()
        {
            // Arrange
            var userDto = new UserDTO
            {
                UserName = "testuser",
                Email = "test@example.com",
                ConfirmEmail = "test@example.com",
                PasswordHash = "hashedPassword",
                ConfirmPassword = "hashedPassword",
                RolId = 1,
                IsEnabled = true
            };

            var expectedErrorMessage = "Error al crear el usuario";

            _userServiceMock.Setup(service => service.RegisterAsync(userDto))
                .ThrowsAsync(new Exception(expectedErrorMessage)); 

            // Act
            ActionResult<Response> result = await _userController.Register(userDto);

            // Assert
            var conflictResult = Assert.IsType<ConflictObjectResult>(result.Result); 
            var response = Assert.IsType<Response>(conflictResult.Value);
            Assert.False(response.IsSuccess);
            Assert.Equal("No fue posible crear el usuario", response.Message);
            Assert.Equal(expectedErrorMessage, response.Errors);
        }
    }
}
