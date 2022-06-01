using Microsoft.EntityFrameworkCore;
using Supervisor.Models;

namespace Bank.Context
{
    public class BankContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public BankContext()
        {
        }

        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>()
                .HasOne(x => x.Transmitter)
                .WithMany(x => x.SentPayments)
                .HasForeignKey(x => x.TransmitterId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Payment>()
                .HasOne(x => x.Receiver)
                .WithMany(x => x.ReceivedPayments)
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Account>()
                .HasOne(x => x.Client)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
