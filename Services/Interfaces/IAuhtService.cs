using todo_backend.Utils.Reponses;

namespace todo_backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Response> AuthenticateUserAsync(string email, string password);
    }
}
