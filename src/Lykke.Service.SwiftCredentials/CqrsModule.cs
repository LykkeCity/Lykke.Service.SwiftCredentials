using System.Collections.Generic;
using Autofac;
using Common.Log;
using JetBrains.Annotations;
using Lykke.Cqrs;
using Lykke.Cqrs.Configuration;
using Lykke.Messaging;
using Lykke.Messaging.RabbitMq;
using Lykke.Service.SwiftCredentials.Contracts;
using Lykke.Service.SwiftCredentials.Models;
using Lykke.Service.SwiftCredentials.Settings;

namespace Lykke.Service.SwiftCredentials
{
    [UsedImplicitly]
    public class CqrsModule : Module
    {
        private readonly ILog _log;
        private readonly AppSettings _settings;
        
        public CqrsModule(
            AppSettings settings,
            ILog log)
        {
            _log = log;
            _settings = settings;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            
            string selfRoute = "self";
            string commandsRoute = "commands";
            string eventsRoute = "events";
            Messaging.Serialization.MessagePackSerializerFactory.Defaults.FormatterResolver = MessagePack.Resolvers.ContractlessStandardResolver.Instance;
            var rabbitMqSagasSettings = new RabbitMQ.Client.ConnectionFactory { Uri = _settings.SagasRabbitMq.RabbitConnectionString };

            builder.Register(context => new AutofacDependencyResolver(context)).As<IDependencyResolver>();

            var messagingEngine = new MessagingEngine(_log,
                new TransportResolver(new Dictionary<string, TransportInfo>
                {
                    { "SagasRabbitMq", new TransportInfo(rabbitMqSagasSettings.Endpoint.ToString(), rabbitMqSagasSettings.UserName, rabbitMqSagasSettings.Password, "None", "RabbitMq") }
                }),
                new RabbitMqTransportFactory());
            
            var sagasEndpointResolver = new RabbitMqConventionEndpointResolver(
                "SagasRabbitMq",
                "messagepack",
                environment: "lykke",
                exclusiveQueuePostfix: "k8s");
            
            builder.Register(
                ctx => new CqrsEngine(
                    _log,
                    ctx.Resolve<IDependencyResolver>(),
                    messagingEngine,
                    new DefaultEndpointProvider(),
                    true,
                    Register.DefaultEndpointResolver(sagasEndpointResolver),
                    Register.BoundedContext(SwiftCredentialsBoundedContext.Name)
                        .PublishingEvents(typeof(SwiftCredentialsRequestedEvent))
                        .With(eventsRoute)))
            .As<ICqrsEngine>()
            .SingleInstance()
            .AutoActivate();
                    
                    
        }
    }
}
