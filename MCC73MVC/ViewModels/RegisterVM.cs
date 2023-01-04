using MCC73MVC.Models;

namespace MCC73MVC.ViewModels;

public class RegisterVM
{
    public string? NIK { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender Gender { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? DepartmentName { get; set; }
    public string? DivisionName { get; set; }

}
