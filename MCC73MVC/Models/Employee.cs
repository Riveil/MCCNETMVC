using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models;

public class Employee
{
    [Key]
    public string? NIK { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public Gender Gender { get; set; }

    public string? Email { get; set; }

    public int DepartementId { get; set; }

    //Relasi 
    [JsonIgnore]
    public Account? Account { get; set; }
    [JsonIgnore]

    [ForeignKey("DepartementId")]
    public Department? Departments { get; set; }
}
   



public enum Gender
{
Male,
Female
}
