using Bank.Context;
using Bank.Interfaces;
using Bank.Models;
using Microsoft.EntityFrameworkCore;
using Supervisor.Models;

namespace Bank.Repository
{
    public class ClientRepository : IClientRepository
    {

        private readonly BankContext _context;

        public ClientRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<Client> Get(ClientLogin ClientLogin)
        {
            return await  _context.Clients.FirstOrDefaultAsync(u =>
                    u.Email.Equals(ClientLogin.Email) &&
                    u.Password.Equals(ClientLogin.Password));
        }

        public async Task<List<Client>> GetAllClient()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
