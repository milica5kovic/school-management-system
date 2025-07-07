using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id { get; set; }

    [Required, StringLength(15, MinimumLength = 10)]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "JMBG mora sadržati tačno 13 cifara.")]
    [Display(Name = "JMBG")]
    public string Jmbg { get; set; }

    [Required, StringLength(50), Display(Name = "Ime")]
    public string FirstName { get; set; }

    [Required, StringLength(50), Display(Name = "Prezime")]
    public string LastName { get; set; }

    [Display(Name = "Puno ime")]
    public string FullName => $"{FirstName} {LastName}";

    [Phone, Display(Name = "Telefon")]
    public string Phone { get; set; }

    [EmailAddress, Display(Name = "E‑pošta")]
    public string Email { get; set; }

    [Display(Name = "Kontakt za hitne slučajeve")]
    public string EmergencyContactName { get; set; }

    [Phone, Display(Name = "Telefon hitnog kontakta")]
    public string EmergencyContactPhone { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}