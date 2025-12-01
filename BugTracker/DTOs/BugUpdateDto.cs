using BugTracker.Enums;
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
        
        public BugStatus? Status { get; set; }

        public BugPriority? Priority { get; set; }
    }
}
