using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Supervisor.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string IBAN { get; set; }

        [Column(TypeName = "decimal(14, 2)")]
        public decimal Amount { get; set; } 

        public virtual Client Client { get; set; }

        public int ClientId { get; set; }

        [JsonIgnore]
        public virtual List<Payment> SentPayments { get; set; } = new();

        [JsonIgnore]
        public virtual List<Payment> ReceivedPayments { get; set; } = new();

    }
}
