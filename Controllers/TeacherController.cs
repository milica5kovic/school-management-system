using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class TeacherController : Controller
{
    private readonly SchoolContext _context;
    public TeacherController(SchoolContext ctx) => _context = ctx;

    // INDEX
    public async Task<IActionResult> Index()
        => View(await _context.Teachers
                              .Include(t => t.CourseTeachers)
                              .ThenInclude(ct => ct.Course)
                              .ToListAsync());

    // DETAILS
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();

        var teacher = await _context.Teachers
            .Include(t => t.CourseTeachers).ThenInclude(ct => ct.Course)
            .FirstOrDefaultAsync(t => t.Id == id);

        return teacher is null ? NotFound() : View(teacher);
    }

    // CREATE (GET)
    public IActionResult Create()
        => View();

    // CREATE (POST)
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("FirstName,LastName,DateOfBirth,Email,Phone,EmploymentType,HiredOn")]
        Teacher teacher)
    {
        if (ModelState.IsValid)
        {
            _context.Add(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(teacher);
    }

    // EDIT (GET)
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        var teacher = await _context.Teachers.FindAsync(id);
        return teacher is null ? NotFound() : View(teacher);
    }

    // EDIT (POST)
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,FirstName,LastName,DateOfBirth,Email,Phone,EmploymentType,HiredOn")]
        Teacher teacher)
    {
        if (id != teacher.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(teacher);
    }

    // DELETE
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var teacher = await _context.Teachers.FindAsync(id);
        return teacher is null ? NotFound() : View(teacher);
    }

    // DELETE (POST)
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher is not null)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}

}
