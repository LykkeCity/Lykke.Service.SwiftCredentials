using Lykke.Service.Assets.Client;
using Lykke.Service.PersonalData.Settings;
using Lykke.Service.SwiftCredentials.Settings.ServiceSettings;
using Lykke.Service.SwiftCredentials.Settings.SlackNotifications;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.SwiftCredentials.Settings
{
    public class AppSettings
    {
        public SwiftCredentialsSettings SwiftCredentialsService { get; set; }
        public SagasRabbitMq SagasRabbitMq { get; set; }
        public PersonalDataServiceClientSettings PersonalDataServiceClient { get; set; }
        public AssetsSettings AssetsServiceClient { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
    
    public class SagasRabbitMq
    {
        [AmqpCheck]
        public string RabbitConnectionString { get; set; }
        public string RetryDelay { get; set; }
    }
    
    public class AssetsSettings
    {
        [HttpCheck("/api/isalive")]
        public string ServiceUrl { get; set; }
    }
}
