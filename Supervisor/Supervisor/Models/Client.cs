using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Supervisor.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        [JsonIgnore]
        public virtual List<Account> Accounts { get; set; } = new();
    }
}
