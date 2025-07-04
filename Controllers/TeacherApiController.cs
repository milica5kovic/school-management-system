using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SchoolManagementSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherApiController : ControllerBase
    {
        private readonly SchoolContext _context;

        public TeacherApiController(SchoolContext context)
        {
            _context = context;
        }

        // POST: api/TeacherApi
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Teacher teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return Ok(teacher);
        }

        // DELETE: api/TeacherApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return NotFound();

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
