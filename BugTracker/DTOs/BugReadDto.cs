using BugTracker.Enums;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.DTOs
{
    public class BugReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public BugStatus? Status { get; set; }

        public BugPriority? Priority { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
