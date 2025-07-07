using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Helpers;

public enum GradeLevel
{
    [Display(Name = "1. razred osnovne")]
    Elementary1 = 1,
    [Display(Name = "2. razred osnovne")]
    Elementary2 = 2,
    [Display(Name = "3. razred osnovne")]
    Elementary3 = 3,
    [Display(Name = "4. razred osnovne")]
    Elementary4 = 4,
    [Display(Name = "5. razred osnovne")]
    Elementary5 = 5,
    [Display(Name = "6. razred osnovne")]
    Elementary6 = 6,
    [Display(Name = "7. razred osnovne")]
    Elementary7 = 7,
    [Display(Name = "8. razred osnovne")]
    Elementary8 = 8,
    [Display(Name = "1. razred srednje")]
    HighSchool1 = 9,
    [Display(Name = "2. razred srednje")]
    HighSchool2 = 10,
    [Display(Name = "3. razred srednje")]
    HighSchool3 = 11,
    [Display(Name = "4. razred srednje")]
    HighSchool4 = 12
}