using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    public class Account
    {
        [Key]
        public string? NIK { get; set; }
       
        public string? Password { get; set; }

        // Relation
        [JsonIgnore]
        public Employee? Employee { get; set; }

        [JsonIgnore]
        public ICollection<AccountRole>? AccountRoles { get; set; }
    }
}
