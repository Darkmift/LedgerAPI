using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LedgerAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [NotMapped,JsonIgnore]
        public string Fullname => $"{Firstname} {Lastname}";
    }
}
