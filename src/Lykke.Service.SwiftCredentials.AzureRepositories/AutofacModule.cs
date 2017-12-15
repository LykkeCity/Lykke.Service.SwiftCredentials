using Autofac;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Service.SwiftCredentials.Core.Repositories;
using Lykke.SettingsReader;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.SwiftCredentials.AzureRepositories
{
    public class AutofacModule : Module
    {
        private const string TableName = "SwiftCredentials";

        private readonly IReloadingManager<string> _connectionString;
        private readonly ILog _log;

        public AutofacModule(IReloadingManager<string> connectionString, ILog log)
        {
            _connectionString = connectionString;
            _log = log;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SwiftCredentialsRepository(CreateTable<SwiftCredentialsEntity>()))
                .As<ISwiftCredentialsRepository>();
        }

        private INoSQLTableStorage<T> CreateTable<T>() where T : TableEntity, new()
        {
            return AzureTableStorage<T>.Create(_connectionString, TableName, _log);
        }
    }
}
