using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Log;
using Lykke.Service.Assets.Client;
using Lykke.Service.ClientAccount.Client;
using Lykke.Service.PersonalData.Client;
using Lykke.Service.PersonalData.Contract;
using Lykke.Service.SwiftCredentials.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.SwiftCredentials
{
    public class ClientsModule : Module
    {
        private readonly ILog _log;
        private readonly AppSettings _settings;
        private readonly ServiceCollection _services;
        
        public ClientsModule(
            AppSettings settings,
            ILog log)
        {
            _log = log;
            _settings = settings;
            
            _services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
            _services.RegisterAssetsClient(
                AssetServiceSettings.Create(
                    new Uri(_settings.AssetsServiceClient.ServiceUrl),
                    TimeSpan.FromMinutes(5)),
                    _log);
            
            builder.RegisterType<PersonalDataService>()
                .As<IPersonalDataService>()
                .WithParameter(TypedParameter.From(_settings.PersonalDataServiceClient));
            
            builder.RegisterLykkeServiceClient(_settings.ClientAccountServiceClient.ServiceUrl);
            
            builder.Populate(_services);
        }
    }
}
