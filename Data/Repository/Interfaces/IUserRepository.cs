using todo_backend.Models;

namespace todo_backend.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
    }
}
