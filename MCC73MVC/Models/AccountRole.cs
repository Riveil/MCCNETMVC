using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }

        public string? AccountNIK { get; set; }

        public int RoleId { get; set; }


        // Relation
        [JsonIgnore]
        [ForeignKey("AccountNIK")]
        public Account? Account { get; set; }

        [JsonIgnore]
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
    }
}
