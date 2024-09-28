
using AndresAlarcon.TaskManager.Application.DTOs;

namespace AndresAlarcon.TaskManager.Application.Services
{
    public interface ITaskBoardService
    {
        /// <summary>
        /// Crea una nueva tarea de forma asíncrona.
        /// </summary>
        /// <param name="taskDto">El objeto de tarea a crear.</param>
        /// <returns>La tarea creada.</returns>
        Task<TaskBoardDTO> CreateTaskAsync(TaskBoardDTO taskDto);

        /// <summary>
        /// Obtiene todas las tareas de forma asíncrona.
        /// </summary>
        /// <returns>Una lista de tareas.</returns>
        Task<IEnumerable<TaskBoardDTO>> GetAllTasksAsync();

        /// <summary>
        /// Obtiene una tarea por su ID de forma asíncrona.
        /// </summary>
        /// <param name="id">El ID de la tarea.</param>
        /// <returns>La tarea correspondiente o null si no se encuentra.</returns>
        Task<TaskBoardDTO> GetTaskByIdAsync(int id);

        /// <summary>
        /// Actualiza una tarea existente de forma asíncrona.
        /// </summary>
        /// <param name="taskDto">El objeto de tarea con los nuevos datos.</param>
        /// <returns>Una tarea que representa el resultado de la actualización.</returns>
        Task UpdateTaskAsync(TaskBoardDTO taskDto);

        /// <summary>
        /// Elimina una tarea por su ID de forma asíncrona.
        /// </summary>
        /// <param name="id">El ID de la tarea a eliminar.</param>
        /// <returns>Una tarea que representa el resultado de la eliminación.</returns>
        Task DeleteTaskAsync(int id);
    }
}
