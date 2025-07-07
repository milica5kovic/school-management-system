using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Helpers;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var attr = enumValue.GetType()
            .GetField(enumValue.ToString())
            .GetCustomAttributes(typeof(DisplayAttribute), false)
            .FirstOrDefault() as DisplayAttribute;

        return attr != null ? attr.Name : enumValue.ToString();
    }
}
