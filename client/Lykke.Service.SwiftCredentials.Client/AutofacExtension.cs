using System;
using Autofac;

namespace Lykke.Service.SwiftCredentials.Client
{
    public static class AutofacExtension
    {
        public static void RegisterSwiftCredentialsClient(this ContainerBuilder builder, SwiftCredentialsServiceClientSettings settings)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(settings.ServiceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(settings.ServiceUrl));

            builder.RegisterType<SwiftCredentialsClient>()
                .WithParameter(TypedParameter.From(settings))
                .As<ISwiftCredentialsClient>()
                .SingleInstance();
        }
    }
}
