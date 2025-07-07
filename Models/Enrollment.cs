using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SchoolManagementSystem.Helpers;

public class Enrollment
{
    public int Id { get; set; }

    [Required]
    public int StudentId { get; set; }
    
    [ValidateNever]
    public Student Student { get; set; }

    [Display(Name="Šk. godina")]
    [Required]
    [RegularExpression(@"^\d{4}/\d{4}$",
        ErrorMessage = "Format mora biti npr. 2024/2025")]
    public string AcademicYear { get; set; }

    [Display(Name="Razred")]
    [Required]
    public GradeLevel GradeLevel { get; set; }

    [Display(Name="Datum upisa")]
    [DataType(DataType.Date)]
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;

    [Display(Name="Odeljenje")]
    public string? ClassGroup { get; set; }

    [Display(Name="Ponavlja razred")]
    public bool IsRepeating { get; set; }

    public string? Notes { get; set; }
}
