using System;
using Autofac;
using Common.Log;

namespace Lykke.Service.SwiftCredentials.Client
{
    public static class AutofacExtension
    {
        public static void RegisterSwiftCredentialsClient(this ContainerBuilder builder, string serviceUrl, ILog log)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (log == null) throw new ArgumentNullException(nameof(log));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterType<SwiftCredentialsClient>()
                .WithParameter("serviceUrl", serviceUrl)
                .As<ISwiftCredentialsClient>()
                .SingleInstance();
        }

        public static void RegisterSwiftCredentialsClient(this ContainerBuilder builder, SwiftCredentialsServiceClientSettings settings, ILog log)
        {
            builder.RegisterSwiftCredentialsClient(settings?.ServiceUrl, log);
        }
    }
}
