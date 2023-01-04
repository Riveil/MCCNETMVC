using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    public class Division
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        // Relation
        [JsonIgnore]
        public ICollection<Department>? Departments { get; set; }
    }
}
