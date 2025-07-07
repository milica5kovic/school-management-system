using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Helpers;
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
                .ToListAsync();

            return View(enrollments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enrollment == null) return NotFound();

            return View(enrollment);
        }

        public IActionResult Create()
        {
            ViewBag.Students = new SelectList(_context.Students.OrderBy(s => s.LastName), "Id", "FullName");
            ViewBag.GradeLevels = new SelectList(Enum.GetValues(typeof(GradeLevel)).Cast<GradeLevel>());
            ViewBag.AcademicYear = $"{DateTime.Now.Year}/{DateTime.Now.Year + 1}";

            return View(new Enrollment
            {
                AcademicYear = ViewBag.AcademicYear,
                EnrollmentDate = DateTime.Now
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,GradeLevel,AcademicYear,EnrollmentDate,ClassGroup,IsRepeating,Notes")] Enrollment enrollment)
        {
            
            if (!ModelState.IsValid)
            {
                // Debug ispisi validacione greške
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                foreach (var error in errors)
                {
                    Console.WriteLine("Validation error: " + error);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Students = new SelectList(_context.Students.OrderBy(s => s.LastName), "Id", "FullName", enrollment.StudentId);
            ViewBag.GradeLevels = new SelectList(Enum.GetValues(typeof(GradeLevel)).Cast<GradeLevel>(), enrollment.GradeLevel);
            return View(enrollment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null) return NotFound();

            ViewBag.Students = new SelectList(_context.Students.OrderBy(s => s.LastName), "Id", "FullName", enrollment.StudentId);
            ViewBag.GradeLevels = new SelectList(Enum.GetValues(typeof(GradeLevel)).Cast<GradeLevel>(), enrollment.GradeLevel);

            return View(enrollment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,GradeLevel,AcademicYear,EnrollmentDate,ClassGroup,IsRepeating,Notes")] Enrollment enrollment)
        {
            if (id != enrollment.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Enrollments.Any(e => e.Id == enrollment.Id))
                        return NotFound();
                    throw;
                }
            }

            ViewBag.Students = new SelectList(_context.Students.OrderBy(s => s.LastName), "Id", "FullName", enrollment.StudentId);
            ViewBag.GradeLevels = new SelectList(Enum.GetValues(typeof(GradeLevel)).Cast<GradeLevel>(), enrollment.GradeLevel);

            return View(enrollment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enrollment == null) return NotFound();

            return View(enrollment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null) return NotFound();

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
