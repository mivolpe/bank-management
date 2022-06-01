using Supervisor.Models;

namespace Bank.Interfaces
{
    public interface IAccountService
    {
        public Task<Account> GetAccountById(int id);

        public Task<List<Account>> GetAllAccount();

        public Task<Account> UpdateAccount(int id, decimal amount, string type);

    }
}
