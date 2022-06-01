using RealSupervisor.Models;

namespace RealSupervisor.Interface
{
    public interface IClientService
    {
        public Task<List<Client>> GetAllClient();
    }
}
