
using AndresAlarcon.TaskManager.API.Controllers;
using AndresAlarcon.TaskManager.Application.DTOs;
using AndresAlarcon.TaskManager.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AndresAlarcon.TaskManager.Test.Task
{
    public class TaskBoardControllerTests
    {
        private readonly Mock<ITaskBoardService> _taskServiceMock;
        private readonly TaskBoardController _controller;

        public TaskBoardControllerTests()
        {
            _taskServiceMock = new Mock<ITaskBoardService>();
            _controller = new TaskBoardController(_taskServiceMock.Object);
        }

        [Fact]
        public async void CreateTask_ReturnsCreatedResult_WhenTaskIsValid()
        {
            // Arrange
            var taskDto = new TaskBoardDTO { Id = 1, Title = "Test Task" };
            _taskServiceMock.Setup(ts => ts.CreateTaskAsync(taskDto)).ReturnsAsync(taskDto);

            // Act
            var result = await _controller.CreateTask(taskDto);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(taskDto, actionResult.Value);
        }

        [Fact]
        public async void GetAllTasks_ReturnsOkResult_WithTaskList()
        {
            // Arrange
            var taskList = new List<TaskBoardDTO>
        {
            new TaskBoardDTO { Id = 1, Title = "Test Task 1" },
            new TaskBoardDTO { Id = 2, Title = "Test Task 2" }
        };
            _taskServiceMock.Setup(ts => ts.GetAllTasksAsync()).ReturnsAsync(taskList);

            // Act
            var result = await _controller.GetAllTasks();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<TaskBoardDTO>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async void GetTask_ReturnsOkResult_WhenTaskExists()
        {
            // Arrange
            var taskDto = new TaskBoardDTO { Id = 1, Title = "Test Task" };
            _taskServiceMock.Setup(ts => ts.GetTaskByIdAsync(1)).ReturnsAsync(taskDto);

            // Act
            var result = await _controller.GetTask(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(taskDto, actionResult.Value);
        }

        [Fact]
        public async void UpdateTask_ReturnsNoContent_WhenTaskExists()
        {
            // Arrange
            var taskDto = new TaskBoardDTO { Id = 1, Title = "Updated Task" };
            _taskServiceMock.Setup(ts => ts.GetTaskByIdAsync(1)).ReturnsAsync(taskDto);

            // Act
            var result = await _controller.UpdateTask(1, taskDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void DeleteTask_ReturnsNoContent_WhenTaskExists()
        {
            // Arrange
            var taskDto = new TaskBoardDTO { Id = 1, Title = "Test Task" };
            _taskServiceMock.Setup(ts => ts.GetTaskByIdAsync(1)).ReturnsAsync(taskDto);

            // Act
            var result = await _controller.DeleteTask(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

    }
}
