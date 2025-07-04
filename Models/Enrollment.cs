using System;
using System.ComponentModel.DataAnnotations;

public class Enrollment
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Student je obavezan.")]
    public int StudentId { get; set; }

    public Student? Student { get; set; }

    [Required(ErrorMessage = "Kurs je obavezan.")]
    public int CourseId { get; set; }

    public Course? Course { get; set; }

    [DataType(DataType.Date)]
    public DateTime EnrolledOn { get; set; }
}
