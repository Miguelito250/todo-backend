using todo_backend.Models;
using todo_backend.Utils.Reponses;

namespace todo_backend.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<Response> CreateUserAsync(User user);
    }
}
