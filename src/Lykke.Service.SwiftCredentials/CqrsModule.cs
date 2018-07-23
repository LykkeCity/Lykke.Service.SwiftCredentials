using System.Collections.Generic;
using Autofac;
using Castle.MicroKernel;
using Common.Log;
using JetBrains.Annotations;
using Lykke.Messaging;
using Lykke.Messaging.RabbitMq;

namespace Lykke.Service.SwiftCredentials
{
    [UsedImplicitly]
    public class CqrsModule : Module
    {
        private ILog _log;
        
        public CqrsModule(
            ILog log)
        {
            _log = log;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            /*
            string selfRoute = "self";
            string commandsRoute = "commands";
            string eventsRoute = "events";
            Messaging.Serialization.MessagePackSerializerFactory.Defaults.FormatterResolver = MessagePack.Resolvers.ContractlessStandardResolver.Instance;
            var rabbitMqSettings = new RabbitMQ.Client.ConnectionFactory { Uri = _settings.CurrentValue.MessagesJob.Transports.ClientRabbitMqConnectionString };
            var rabbitMqSagasSettings = new RabbitMQ.Client.ConnectionFactory { Uri = _settings.CurrentValue.SagasRabbitMq.RabbitConnectionString };

            builder.Register(context => new AutofacDependencyResolver(context)).As<IDependencyResolver>();

            var messagingEngine = new MessagingEngine(_log,
                new TransportResolver(new Dictionary<string, TransportInfo>
                {
                    { "SagasRabbitMq", new TransportInfo(rabbitMqSagasSettings.Endpoint.ToString(), rabbitMqSagasSettings.UserName, rabbitMqSagasSettings.Password, "None", "RabbitMq") },
                    { "ClientRabbitMq", new TransportInfo(rabbitMqSettings.Endpoint.ToString(), rabbitMqSettings.UserName, rabbitMqSettings.Password, "None", "RabbitMq") }
                }),
                new RabbitMqTransportFactory());
                */
        }
    }
}
