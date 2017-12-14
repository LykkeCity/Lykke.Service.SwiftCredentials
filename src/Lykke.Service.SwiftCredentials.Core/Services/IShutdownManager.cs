using System.Threading.Tasks;

namespace Lykke.Service.SwiftCredentials.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}