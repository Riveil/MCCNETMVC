using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DivisionId { get; set; }


        [JsonIgnore]
        public ICollection<Employee>? Employee { get; set; }

        [JsonIgnore]
        [ForeignKey("DivisionId")]
        public Division? Division { get; set; }
    }
}
