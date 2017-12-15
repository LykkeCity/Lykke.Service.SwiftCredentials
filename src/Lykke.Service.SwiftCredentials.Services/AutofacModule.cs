using Autofac;
using Lykke.Service.SwiftCredentials.Core.Services;

namespace Lykke.Service.SwiftCredentials.Services
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            builder.RegisterType<SwiftCredentialsService>()
                .As<ISwiftCredentialsService>();
        }
    }
}
