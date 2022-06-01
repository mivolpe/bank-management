using Supervisor.Models;

namespace Bank.Interfaces
{
    public interface IAccountRepository
    {
        public Task<Account> GetAccountById(int id);

        public Task<List<Account>> GetAllAccount();

        public Task<Account> UpdateAccount(Account account);

    }
}
