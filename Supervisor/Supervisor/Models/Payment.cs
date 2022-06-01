using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supervisor.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public virtual Account Transmitter { get; set; }

        public int TransmitterId { get; set; }

        public virtual Account Receiver { get; set; }

        public int ReceiverId { get; set; }


        public DateTime DateTime { get; set; }

        public string? freeOrStructuredCommunication { get; set; } = string.Empty;

    }
}
