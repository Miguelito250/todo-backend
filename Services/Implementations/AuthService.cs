using todo_backend.Data.Repository.Interfaces;
using todo_backend.DTOS;
using todo_backend.Models;
using todo_backend.Services.Interfaces;
using todo_backend.Utils.JWT;
using todo_backend.Utils.Reponses;
namespace todo_backend.Services.Implementations
{
    /// <summary>
    /// Esta es la clase encargada de realizar la autenticación de los usuarios.
    /// la funcion valida si el usuario es el mismo que hay en la base de datos
    /// utilizando la lyave BCrypt para verificar la contraseña.
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly Jwt _jwt;
        public AuthService(IUserRepository userRepository, Jwt jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }
        public async Task<Response> AuthenticateUserAsync(string email, string password)
        {
            User? user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null) return new Response(false, "User not found");

            bool passwordIsValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (passwordIsValid == false) return new Response(false, "Incorrect Credentials");

            string accessToken = _jwt.GenerateToken([], 1);

            AuthResponse userInfo = new AuthResponse
            {
                AccessToken = accessToken,
                UserId= user.Id,
                FullName= user.FullName
            };
            return new Response(true, "Ok", userInfo);
        }
    }
}
