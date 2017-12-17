using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.SwiftCredentials.Core.Domain;
using Lykke.Service.SwiftCredentials.Core.Exceptions;
using Lykke.Service.SwiftCredentials.Core.Repositories;
using Lykke.Service.SwiftCredentials.Core.Services;

namespace Lykke.Service.SwiftCredentials.Services
{
    public class SwiftCredentialsService : ISwiftCredentialsService
    {
        private readonly ISwiftCredentialsRepository _swiftCredentialsRepository;

        public SwiftCredentialsService(ISwiftCredentialsRepository swiftCredentialsRepository)
        {
            _swiftCredentialsRepository = swiftCredentialsRepository;
        }

        public async Task<IEnumerable<ISwiftCredentials>> GetAllAsync()
        {
            return await _swiftCredentialsRepository.GetAllAsync();
        }

        public async Task<ISwiftCredentials> GetAsync(string regulationId, string assetId)
        {
            ISwiftCredentials swiftCredentials = await _swiftCredentialsRepository.GetAsync(regulationId, assetId);

            if (swiftCredentials == null)
            {
                throw new SwiftCredentialsNotFoundException("Swift credentials not found")
                {
                    RegulationId = regulationId,
                    AssetId = assetId
                };
            }

            return swiftCredentials;
        }

        public async Task InsertAsync(ISwiftCredentials swiftCredentials)
        {
            await _swiftCredentialsRepository.InsertAsync(swiftCredentials);
        }

        public async Task UpdateAsync(ISwiftCredentials swiftCredentials)
        {
            bool updated = await _swiftCredentialsRepository.UpdateAsync(swiftCredentials);

            if (!updated)
            {
                throw new SwiftCredentialsNotFoundException("Swift credentials not found")
                {
                    RegulationId = swiftCredentials.RegulationId,
                    AssetId = swiftCredentials.AssetId
                };
            }
        }

        public async Task DeleteAsync(string regulationId, string assetId)
        {
            await _swiftCredentialsRepository.DeleteAsync(regulationId, assetId);
        }
    }
}
