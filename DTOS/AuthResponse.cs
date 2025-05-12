namespace todo_backend.DTOS
{
    /// <summary>
    /// Los  de datos son clases que representan la estructura de los datos que se reciben a través de la API.
    /// que requieren de una estructura unica
    public class AuthResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
