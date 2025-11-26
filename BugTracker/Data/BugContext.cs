using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data
{
    public class BugContext : DbContext
    {
        public BugContext(DbContextOptions<BugContext> options)
            : base(options)
        {
        }

        public DbSet<Bug> Bugs { get; set; }
    }
}