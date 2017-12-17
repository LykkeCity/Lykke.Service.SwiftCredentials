using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AzureStorage;
using Lykke.Service.SwiftCredentials.Core.Domain;
using Lykke.Service.SwiftCredentials.Core.Exceptions;
using Lykke.Service.SwiftCredentials.Core.Repositories;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table.Protocol;

namespace Lykke.Service.SwiftCredentials.AzureRepositories
{
    public class SwiftCredentialsRepository : ISwiftCredentialsRepository
    {
        private readonly INoSQLTableStorage<SwiftCredentialsEntity> _storage;

        public SwiftCredentialsRepository(INoSQLTableStorage<SwiftCredentialsEntity> storage)
        {
            _storage = storage;
        }

        public async Task<IEnumerable<ISwiftCredentials>> GetAllAsync()
        {
            return await _storage.GetDataAsync();
        }

        public async Task<ISwiftCredentials> GetAsync(string regulationId, string assetId)
        {
            return await _storage.GetDataAsync(GetPartitionKey(regulationId), GetRowKey(assetId));
        }

        public async Task InsertAsync(ISwiftCredentials swiftCredentials)
        {
            var entity = new SwiftCredentialsEntity
            {
                PartitionKey = GetPartitionKey(swiftCredentials.RegulationId),
                RowKey = GetRowKey(swiftCredentials.AssetId)
            };

            Mapper.Map(swiftCredentials, entity);

            try
            {
                await _storage.InsertAsync(entity);
            }
            catch (StorageException exception)
            {
                if (exception.RequestInformation != null &&
                    exception.RequestInformation.HttpStatusCode == 409 &&
                    exception.RequestInformation.ExtendedErrorInformation.ErrorCode == TableErrorCodeStrings.EntityAlreadyExists)
                {
                    throw new SwiftCredentialsAlreadyExistsException("Already exists", exception)
                    {
                        RegulationId = swiftCredentials.RegulationId,
                        AssetId = swiftCredentials.AssetId
                    };
                }
            }
        }

        public async Task<bool> UpdateAsync(ISwiftCredentials swiftCredentials)
        {
            SwiftCredentialsEntity swiftCredentialsEntity = await _storage.MergeAsync(
                GetPartitionKey(swiftCredentials.RegulationId),
                GetRowKey(swiftCredentials.AssetId),
                entity =>
                {
                    Mapper.Map(swiftCredentials, entity);
                    return entity;
                });

            return swiftCredentialsEntity != null;
        }

        public async Task DeleteAsync(string regulationId, string assetId)
        {
            await _storage.DeleteAsync(GetPartitionKey(regulationId), GetRowKey(assetId));
        }

        private static string GetPartitionKey(string regulationId)
            => regulationId.ToLower().Trim();

        private static string GetRowKey(string assetId)
            => assetId.Trim().ToLower();
    }
}
