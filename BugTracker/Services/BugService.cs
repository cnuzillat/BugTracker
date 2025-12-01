using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.DTOs;

namespace BugTracker.Services
{
    public class BugService : IBugService
    {
        private readonly BugContext _context;

        public BugService(BugContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DTOs.BugReadDto>> GetAllBugsAsync()
        {
            return await _context.Bugs
                .AsNoTracking()
                .Select(b => new DTOs.BugReadDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Status = b.Status,
                    Priority = b.Priority,
                    CreatedAt = b.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<DTOs.BugReadDto?> GetBugByIdAsync(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null) return null;
            return ToDto(bug);
        }
        
        public async Task<DTOs.BugReadDto> CreateBugAsync(DTOs.BugCreateDto dto)
        {
            var bug = new Models.Bug
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status ?? Enums.BugStatus.Open,
                Priority = dto.Priority ?? Enums.BugPriority.Medium,
                CreatedAt = DateTime.UtcNow
            };
            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();
            return ToDto(bug);
        }

        public async Task<DTOs.BugReadDto?> UpdateBugAsync(int id, DTOs.BugUpdateDto dto)
        {
            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null) return null;
            bug.Title = dto.Title ?? bug.Title;
            bug.Description = dto.Description ?? bug.Description;
            bug.Status = dto.Status ?? bug.Status;
            bug.Priority = dto.Priority ?? bug.Priority;
            await _context.SaveChangesAsync();
            return ToDto(bug);
        }

        public async Task<bool> DeleteBugAsync(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null) return false;
            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();
            return true;
        }

        private static BugReadDto ToDto(Models.Bug bug) => new BugReadDto
        {
            Id = bug.Id,
            Title = bug.Title,
            Description = bug.Description,
            Status = bug.Status,
            Priority = bug.Priority,
            CreatedAt = bug.CreatedAt
        };
    }
}
