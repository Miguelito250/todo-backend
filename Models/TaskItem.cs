using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace todo_backend.Models
{
    public class TaskItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        [MaxLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relación con Usuario
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

    }
}
