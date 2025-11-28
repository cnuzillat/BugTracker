using System.ComponentModel.DataAnnotations;

namespace BugTracker.DTOs
{
    public class BugUpdateDto
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = null!;
        
        [MaxLength(2000)]
        public string? Description { get; set; }
        
        [MaxLength(50)]
        public string? Status { get; set; }
    }
}
