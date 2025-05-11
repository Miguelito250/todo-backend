using System.ComponentModel.DataAnnotations;

namespace todo_backend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string PasswordHash { get; set; } = null!;

        // Navegación
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    }
}
