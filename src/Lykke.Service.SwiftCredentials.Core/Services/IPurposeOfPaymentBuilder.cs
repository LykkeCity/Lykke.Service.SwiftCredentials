using System.Threading.Tasks;

namespace Lykke.Service.SwiftCredentials.Core.Services
{
    public interface IPurposeOfPaymentBuilder
    {
        Task<string> Build(string template, string clientId, string assetId);
    }
}
