using Microsoft.EntityFrameworkCore;
using todo_backend.Data.Repository.Interfaces;
using todo_backend.Models;

namespace todo_backend.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksManagerContext _context;

        public UserRepository(TasksManagerContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
