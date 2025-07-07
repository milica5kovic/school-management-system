using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Helpers;

public class Course
{
    public int Id { get; set; }

    [Display(Name = "Naziv predmeta")]
    [Required(ErrorMessage = "Naziv kursa je obavezan.")]
    public string Title { get; set; }

    [Display(Name = "Šifra")]
    public string? Code { get; set; }

    [Display(Name = "Opis")]
    public string? Description { get; set; }

    [Display(Name = "Broj ESPB / poena")]
    public ESPB? ESPB { get; set; }

    [Display(Name = "Razred")]
    public GradeLevel? GradeLevel { get; set; }

    [Display(Name = "Semestar")]
    public int? Semester { get; set; }

    [Display(Name = "Izborni")]
    public bool IsElective { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();
}