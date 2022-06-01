using RealSupervisor.Models;

namespace RealSupervisor.Interface
{
    public interface IBankAuthService
    {
        public Task<string?> RetrieveToken();
    }
}
