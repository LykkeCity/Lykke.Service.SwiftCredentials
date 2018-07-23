using System;
using Autofac;
using Common.Log;
using Lykke.Service.Assets.Client;
using Lykke.Service.PersonalData;
using Lykke.Service.PersonalData.Client;
using Lykke.Service.PersonalData.Contract;
using Lykke.Service.SwiftCredentials.Settings;

namespace Lykke.Service.SwiftCredentials
{
    public class ClientsModule : Module
    {
        private readonly ILog _log;
        private readonly AppSettings _settings;
        
        public ClientsModule(
            AppSettings settings,
            ILog log)
        {
            _log = log;
            _settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssetsClient(
                AssetServiceSettings.Create(
                    new Uri(_settings.AssetsServiceClient.ServiceUrl),
                    TimeSpan.FromMinutes(5)));
            
            builder.RegisterType<PersonalDataService>()
                .As<IPersonalDataService>()
                .WithParameter(TypedParameter.From(_settings.PersonalDataServiceClient));
        }
    }
}
