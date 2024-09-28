﻿using AndresAlarcon.TaskManager.Application.Security;

namespace AndresAlarcon.TaskManager.Application.DTOs
{
    public class TokenDTO : UserDTO
    {
        public int? Id { get; set; }
        public string? Token { get; set; } = string.Empty;
        public bool IsSucceeded { get; set; }
        public string User { get; set; } = string.Empty;
        public IOAuth2Response Result
        {
            get
            {
                if (IsSucceeded)
                {
                    OAuth2SuccessResponse result = new()
                    {
                        IsSucceeded = true,
                        Access_token = Token!,
                        Refresh_token = Token!,
                        Token_type = TokenType,
                        Expires_in = ExpiresIn,
                        User = User
                    };
                    return result;
                }
                else
                {
                    OAuth2ErrorResponse result = new()
                    {
                        Error = "Unauthorized",
                        IsSucceeded = false,
                        ErrorDescription = "Usuario o contraseña incorrectos"
                    };
                    return result;
                }
            }
        }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; } = string.Empty;
    }
}
