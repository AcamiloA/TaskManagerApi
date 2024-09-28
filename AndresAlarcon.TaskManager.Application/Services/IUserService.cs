using AndresAlarcon.TaskManager.Application.DTOs;

namespace AndresAlarcon.TaskManager.Application.Services
{
    public interface IUserService
    {
        Task<UserDTO> RegisterAsync(UserDTO user);
        Task<TokenDTO> Login(string? email, string password);
    }
}
