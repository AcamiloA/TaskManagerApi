using AndresAlarcon.TaskManager.Application.DTOs;
using AndresAlarcon.TaskManager.Application.Services;
using AndresAlarcon.TaskManager.Domain.Entities;
using AndresAlarcon.TaskManager.Infrastructure.Repositories.Contracts;
using AutoMapper;

namespace AndresAlarcon.TaskManager.Infrastructure.Services
{
    public class TaskBoardService(IUnitOfWork unitOfWork, IMapper mapper) : ITaskBoardService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        //inheritdoc
        public async Task<TaskBoardDTO> CreateTaskAsync(TaskBoardDTO taskDto)
        {
            Board board = _mapper.Map<Board>(taskDto);
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
        public async Task<IEnumerable<TaskBoardDTO>> GetAllTasksAsync()
        {
            return _mapper.Map<IEnumerable<TaskBoardDTO>>(await _unitOfWork.BoardRepository.GetAll());
        }

        //inheritdoc
        public async Task<TaskBoardDTO> GetTaskByIdAsync(int id)
        {
            return _mapper.Map<TaskBoardDTO>(await _unitOfWork.BoardRepository.GetById(id));
        }

        //inheritdoc
        public async Task UpdateTaskAsync(TaskBoardDTO taskDto)
        {
            Board board = _mapper.Map<Board>(taskDto);

            _unitOfWork.BoardRepository.Update(board);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
