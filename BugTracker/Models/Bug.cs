using BugTracker.Enums;

namespace BugTracker.Models
{
    public class Bug
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; } = BugStatus.Open; // default
        public BugPriority Priority { get; set; } = BugPriority.Medium; // default
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
