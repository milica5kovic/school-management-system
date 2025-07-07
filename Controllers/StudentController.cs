using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Student
        // GET: Student
        public async Task<IActionResult> Index(string searchString, string sortOrder,
            int page = 1, int pageSize = 5)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"]   = sortOrder;
            ViewData["NameSortParm"]  = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var students = _context.Students.AsQueryable();

            // PRETRAGA
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                students = students.Where(s =>
                    (s.FirstName + " " + s.LastName).Contains(searchString) ||
                    (s.LastName  + " " + s.FirstName).Contains(searchString) ||
                    s.Jmbg.Contains(searchString));
            }

            // SORTIRANJE
            students = sortOrder == "name_desc"
                ? students.OrderByDescending(s => s.LastName)
                    .ThenByDescending(s => s.FirstName)
                : students.OrderBy(s => s.LastName)
                    .ThenBy(s => s.FirstName);

            // PAGING
            var count = await students.CountAsync();
            var items = await students.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var pagedList = new PagedList<Student>(items, count, page, pageSize);
            return View(pagedList);
        }


        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Jmbg,FirstName,LastName,Phone,Email,EmergencyContactName,EmergencyContactPhone")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Jmbg,FirstName,LastName,Phone,Email,EmergencyContactName,EmergencyContactPhone")] Student student)
        {
            if (id != student.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
