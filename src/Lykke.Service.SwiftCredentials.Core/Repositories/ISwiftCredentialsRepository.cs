using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.SwiftCredentials.Core.Domain;

namespace Lykke.Service.SwiftCredentials.Core.Repositories
{
    public interface ISwiftCredentialsRepository
    {
        Task<IEnumerable<ISwiftCredentials>> GetAllAsync();
        Task<ISwiftCredentials> GetAsync(string regulationId, string assetId);
        Task InsertAsync(ISwiftCredentials swiftCredentials);
        Task<bool> UpdateAsync(ISwiftCredentials swiftCredentials);
        Task DeleteAsync(string regulationId, string assetId);
    }
}
