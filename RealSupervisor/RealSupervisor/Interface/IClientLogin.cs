using RealSupervisor.Models;

namespace RealSupervisor.Interface
{
    public interface IClientLogin
    {
        Task<string> LogClient(ClientLogin clientLogin);
    }
}
