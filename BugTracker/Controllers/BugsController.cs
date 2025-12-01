using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTracker.Models;
using BugTracker.Services;
using BugTracker.DTOs;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly IBugService _bugService;

        public BugsController(IBugService bugService)
        {
            _bugService = bugService;
        }

        // GET: api/Bugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugReadDto>>> GetBugs()
        {
            var bugs = await _bugService.GetAllBugsAsync();
            return Ok(bugs);
        }

        // GET: api/Bugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BugReadDto>> GetBug(int id)
        {
            var bug = await _bugService.GetBugByIdAsync(id);

            if (bug == null)
            {
                return NotFound();
            }

            return bug;
        }

        // PUT: api/Bugs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBug(int id, BugUpdateDto dto)
        {
            var updatedBug = await _bugService.UpdateBugAsync(id, dto);
            if (updatedBug == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Bugs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bug>> PostBug(BugCreateDto dto)
        {
            var createdBug = await _bugService.CreateBugAsync(dto);
            return CreatedAtAction("GetBug", new { id = createdBug.Id }, createdBug);
        }

        // DELETE: api/Bugs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBug(int id)
        {
            var success = await _bugService.DeleteBugAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool BugExists(int id)
        {
            var bug = _bugService.GetBugByIdAsync(id).Result;
            return bug != null;
        }
    }
}
