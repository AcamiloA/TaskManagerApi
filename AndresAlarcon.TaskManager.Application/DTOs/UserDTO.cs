namespace AndresAlarcon.TaskManager.Application.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ConfirmEmail { get; set; } = string.Empty;
        public string? PasswordHash { get; set; } = string.Empty;
        public string? ConfirmPassword { get; set; } = string.Empty;
        public int RolId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
