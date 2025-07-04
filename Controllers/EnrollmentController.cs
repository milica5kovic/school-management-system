using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly SchoolContext _context;

        public EnrollmentController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();

            return View(enrollments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enrollment == null) return NotFound();

            return View(enrollment);
        }

        public IActionResult Create()
        {
            ViewData["Students"] = new SelectList(_context.Students, "Id", "FullName");
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Title");
            return View(new Enrollment { EnrolledOn = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId,EnrolledOn")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine(">>> ModelState nije validan!");
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Polje: {key}, Greška: {error.ErrorMessage}");
                    }
                }
            }


            ViewData["Students"] = new SelectList(_context.Students, "Id", "FullName", enrollment.StudentId);
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Title", enrollment.CourseId);
            return View(enrollment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null) return NotFound();

            ViewData["Students"] = new SelectList(_context.Students, "Id", "FullName", enrollment.StudentId);
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Title", enrollment.CourseId);
            return View(enrollment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId,EnrolledOn")] Enrollment enrollment)
        {
            if (id != enrollment.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Enrollments.Any(e => e.Id == id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Students"] = new SelectList(_context.Students, "Id", "FullName", enrollment.StudentId);
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Title", enrollment.CourseId);
            return View(enrollment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (enrollment == null) return NotFound();

            return View(enrollment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
