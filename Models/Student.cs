using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ime i prezime su obavezni.")]
    [StringLength(100, ErrorMessage = "Ime i prezime ne sme biti duže od 100 karaktera.")]
    [Display(Name = "Ime i prezime")]
    public string FullName { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
