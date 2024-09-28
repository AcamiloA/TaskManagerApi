using AndresAlarcon.TaskManager.Application.DTOs;
using AndresAlarcon.TaskManager.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndresAlarcon.TaskManager.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskBoardController(ITaskBoardService taskService) : ControllerBase
    {
        private readonly ITaskBoardService _taskService = taskService;

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="taskDto">El objeto de tarea a crear.</param>
        /// <returns>Una acción que representa el resultado de la creación.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TaskBoardDTO>> CreateTask([FromBody] TaskBoardDTO taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest("La tarea no puede ser nula.");
            }

            var createdTask = await _taskService.CreateTaskAsync(taskDto);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        /// <summary>
        /// Obtiene todas las tareas.
        /// </summary>
        /// <returns>Una lista de tareas.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TaskBoardDTO>>> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        /// <summary>
        /// Obtiene una tarea por su ID.
        /// </summary>
        /// <param name="id">El ID de la tarea.</param>
        /// <returns>La tarea correspondiente.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaskBoardDTO>> GetTask(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">El ID de la tarea a actualizar.</param>
        /// <param name="taskBoardDTO">El objeto de tarea con los nuevos datos.</param>
        /// <returns>Una acción que representa el resultado de la actualización.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTask(int id, [FromBody] TaskBoardDTO taskDto)
        {
            if (id != taskDto.Id)
            {
                return BadRequest("El ID de la tarea no coincide.");
            }

            var exists = await _taskService.GetTaskByIdAsync(id);
            if (exists == null)
            {
                return NotFound();
            }

            await _taskService.UpdateTaskAsync(taskDto);
            return NoContent();
        }

        /// <summary>
        /// Elimina una tarea.
        /// </summary>
        /// <param name="id">El ID de la tarea a eliminar.</param>
        /// <returns>Una acción que representa el resultado de la eliminación.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var exists = await _taskService.GetTaskByIdAsync(id);
            if (exists == null)
            {
                return NotFound();
            }

            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}
