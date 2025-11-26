namespace BugTracker.Models
{
    public class Bug
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Open"; // default
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
