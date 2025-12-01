using BugTracker.DTOs;

namespace BugTracker.Services
{
    public interface IBugService
    {
        Task<IEnumerable<DTOs.BugReadDto>> GetAllBugsAsync();
        Task<DTOs.BugReadDto?> GetBugByIdAsync(int id);
        Task<DTOs.BugReadDto> CreateBugAsync(BugCreateDto dto);
        Task<DTOs.BugReadDto> UpdateBugAsync(int id, BugUpdateDto dto);
        Task<bool> DeleteBugAsync(int id);
    }
}
