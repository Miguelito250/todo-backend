using todo_backend.Data.Repository.Interfaces;
using todo_backend.Models;
using todo_backend.Services.Interfaces;
using todo_backend.Utils.JWT;
using todo_backend.Utils.Reponses;

namespace todo_backend.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly Jwt _jwt;

        public UserService(IUserRepository userRepository, Jwt jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<Response> CreateUserAsync(User user)
        {
            User? isEmailExists = await _userRepository.GetUserByEmailAsync(user.Email);

            if (isEmailExists != null) return new Response(false, "Email in use");

            string accessToken = _jwt.GenerateToken([], 1);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            User newUser = await _userRepository.AddUserAsync(user);

            return newUser != null
                ? new Response(true, "Ok", accessToken)
                : new Response(false, "Error creating user");
        }
    }
}
