using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Helpers;
using SchoolManagementSystem.Models;

public class Teacher
{
    public int Id { get; set; }

    [Display(Name = "Ime")]
    public string FirstName { get; set; }

    [Display(Name = "Prezime")]
    public string LastName { get; set; }

    [Display(Name = "Datum rođenja")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "E‑pošta")]
    public string Email { get; set; }

    [Display(Name = "Telefon")]
    public string Phone { get; set; }

    [Display(Name = "Radno vreme")]
    public EmploymentType EmploymentType { get; set; }

    [Display(Name = "Datum zaposlenja")]
    [DataType(DataType.Date)]
    public DateTime? HiredOn { get; set; }

    // READ‑ONLY za prikaz u view‑ovima (nije u bazi)
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    public ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();
}