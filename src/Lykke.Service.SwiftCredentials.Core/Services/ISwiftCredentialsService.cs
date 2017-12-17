using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.SwiftCredentials.Core.Domain;

namespace Lykke.Service.SwiftCredentials.Core.Services
{
    public interface ISwiftCredentialsService
    {
        Task<IEnumerable<ISwiftCredentials>> GetAllAsync();
        Task<ISwiftCredentials> GetAsync(string regulationId, string assetId);
        Task InsertAsync(ISwiftCredentials swiftCredentials);
        Task UpdateAsync(ISwiftCredentials swiftCredentials);
        Task DeleteAsync(string regulationId, string assetId);
    }
}
