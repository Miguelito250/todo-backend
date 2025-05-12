using System.ComponentModel.DataAnnotations;

namespace todo_backend.DTOS
{
    /// <summary>
    /// Los  de datos son clases que representan la estructura de los datos que se reciben a través de la API.
    /// que requieren de una estructura unica
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
