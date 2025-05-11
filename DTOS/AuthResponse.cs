namespace todo_backend.DTOS
{
    public class AuthResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
