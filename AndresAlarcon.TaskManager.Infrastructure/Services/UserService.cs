using AndresAlarcon.TaskManager.Application.DTOs;
using AndresAlarcon.TaskManager.Application.Repositories;
using AndresAlarcon.TaskManager.Application.Services;
using AndresAlarcon.TaskManager.Domain.Entities;
using AndresAlarcon.TaskManager.Infrastructure.Repositories;
using AndresAlarcon.TaskManager.Infrastructure.Repositories.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace AndresAlarcon.TaskManager.Infrastructure.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        public async Task<UserDTO> RegisterAsync(UserDTO user)
        {
            await ValidateAsync(user);

            (string passwordHash, string salt) = CreatePasswordHash(user.PasswordHash!);

            User model = new()
            {
                Id = Guid.NewGuid(),
                RoleId = user.RolId,
                Username = user.UserName,
                Email = user.Email,
                PasswordHash = passwordHash,
                Salt = salt,
                IsActive = true,
                CreatedOn = DateTime.Now
            };

            await _unitOfWork.UserRepository.Add(model);
            await _unitOfWork.SaveChangesAsync();

            user.ConfirmEmail = null;
            user.PasswordHash = null;
            user.ConfirmPassword = null;

            return user;
        }

        public async Task<TokenDTO> Login(string? email, string password)
        {
            TokenDTO token = new();
            IEnumerable<User> list = await _unitOfWork.UserRepository.GetAll();

            User user = list.Where(_ => _.Email == email).FirstOrDefault()!;

            if (user == null)
            {
                token.IsSucceeded = false;
                return token;
            }
            if (VerifyPassword(password, user!.PasswordHash, user.Salt))
            {
                token.IsSucceeded = true;
                token.User = user.Id.ToString();
            }
            else token.IsSucceeded = false;


            return token;
        }

        #region PrivateMethods        
        private static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(password + storedSalt);
            byte[] hashBytes = SHA256.HashData(saltedPasswordBytes);
            string computedHash = Convert.ToBase64String(hashBytes);
            return computedHash == storedHash;
        }

        private static (string passwordHash, string salt) CreatePasswordHash(string password)
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);
            byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hashBytes = SHA256.HashData(saltedPasswordBytes);
            string passwordHash = Convert.ToBase64String(hashBytes);
            return (passwordHash, salt);
        }

        private async Task ValidateAsync(UserDTO user)
        {
            IEnumerable<User> list = await _unitOfWork.UserRepository.GetAll();
            if (list.Where(_ => _.Email == user.Email).Any())
                throw new InvalidDataException("El correo ingresado ya existe con otro usuario");
            if (user.PasswordHash != user.ConfirmPassword)
                throw new InvalidDataException("La contraeña y la confirmación de la contraseña no coinciden");
            if (user.Email != user.ConfirmEmail)
                throw new InvalidDataException("El correo y la confirmación del correo no coinciden");
        }
        #endregion
    }
}
