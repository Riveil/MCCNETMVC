using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        // Relation
        [JsonIgnore]
        public ICollection<AccountRole>? AccountRoles { get; set; }
    }
}
