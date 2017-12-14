using Lykke.Service.SwiftCredentials.Settings.ServiceSettings;
using Lykke.Service.SwiftCredentials.Settings.SlackNotifications;

namespace Lykke.Service.SwiftCredentials.Settings
{
    public class AppSettings
    {
        public SwiftCredentialsSettings SwiftCredentialsService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
