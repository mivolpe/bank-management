using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealSupervisor.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal amount { get; set; }

        public Account Transmitter { get; set; }

        public int? TransmitterId { get; set; }

        public Account Receiver { get; set; }

        public int? ReceiverId { get; set; }


        public DateTime DateTime { get; set; }

        public string? freeOrStructuredCommunication { get; set; }

    }
}
