//public class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public decimal Salary { get; set; }
//    public string Department { get; set; }
//}
using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Required]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Name can only contain letters, spaces, apostrophes, and hyphens.")]
    public string Name { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
    public decimal Salary { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Department can only contain letters, spaces, apostrophes, and hyphens.")]
    public string Department { get; set; }
}