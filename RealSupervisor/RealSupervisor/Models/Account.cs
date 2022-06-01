namespace RealSupervisor.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string IBAN { get; set; }

        public decimal amount { get; set; } 

        public Client Client { get; set; }

        public int ClientId { get; set; }   

        public List<Payment> SentPayments { get; set; } = new();

        public List<Payment> ReceivedPayments { get; set; } = new();

    }
}
