using AndresAlarcon.TaskManager.Application.DTOs;
using AndresAlarcon.TaskManager.Application.Services;
using AndresAlarcon.TaskManager.Domain.Entities;
using AndresAlarcon.TaskManager.Infrastructure.Repositories.Contracts;
using AutoMapper;

namespace AndresAlarcon.TaskManager.Infrastructure.Services
{
    public class TaskBoardService(IUnitOfWork unitOfWork) : ITaskBoardService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        //inheritdoc
        public async Task<TaskBoardDTO> CreateTaskAsync(TaskBoardDTO taskDto)
        {

            Board board = new()
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                AssignedTo = taskDto.AssignedTo,
                CreatedBy = taskDto.CreatedBy,
                Status = taskDto.Status,
                Priority = taskDto.Priority,
                IsActive = taskDto.IsActive,
                CreatedOn = taskDto.CreatedOn
            };
            await _unitOfWork.BoardRepository.Add(board);
            await _unitOfWork.SaveChangesAsync();

            return taskDto;
        }

        //inheritdoc
        public async Task DeleteTaskAsync(int id)
        {
            Board board = await _unitOfWork.BoardRepository.GetById(id);
            if(board is not null)
                _unitOfWork.BoardRepository.Remove(board);
            await _unitOfWork.SaveChangesAsync();
        }

        //inheritdoc
        public async Task<IEnumerable<object>> GetAllTasksAsync()
        {
            return await _unitOfWork.BoardRepository.GetAll();
        }

        //inheritdoc
        public async Task<TaskBoardDTO> GetTaskByIdAsync(int id)
        {
            var taskBoard = await _unitOfWork.BoardRepository.GetById(id);

            if (taskBoard == null)
            {
                return null; 
            }

            TaskBoardDTO taskBoardDTO = new()
            {
                Id = taskBoard.Id,
                Title = taskBoard.Title,
                Description = taskBoard.Description,
                DueDate = taskBoard.DueDate,
                AssignedTo = taskBoard.AssignedTo,
            };

            return taskBoardDTO;
        }

        //inheritdoc
        public async Task UpdateTaskAsync(TaskBoardDTO taskDto)
        {
            Board board = new()
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                AssignedTo = taskDto.AssignedTo,
                CreatedBy = taskDto.CreatedBy,
                Status = taskDto.Status,
                Priority = taskDto.Priority,
                IsActive = taskDto.IsActive,
                CreatedOn = taskDto.CreatedOn,
                UpdatedOn = taskDto.UpdatedOn,
                UpdatedBy = taskDto.UpdatedBy,
            };
            _unitOfWork.BoardRepository.Update(board);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
