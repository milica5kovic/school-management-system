using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models;

public class HomeController : Controller
{
    private readonly SchoolContext _context;

    public HomeController(SchoolContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeViewModel
        {
            StudentCount = await _context.Students.CountAsync(),
            CourseCount = await _context.Courses.CountAsync(),
            TeacherCount = await _context.Teachers.CountAsync(),
            EnrollmentCount = await _context.Enrollments.CountAsync(),

            LatestStudents = await _context.Students
                .OrderByDescending(s => s.Id)
                .Take(5)
                .ToListAsync()
        };

        return View(model);
    }
}
