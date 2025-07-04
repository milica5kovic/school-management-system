using System.ComponentModel.DataAnnotations;

public class Course
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Naziv kursa je obavezan.")]
    public string Title { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();
}
