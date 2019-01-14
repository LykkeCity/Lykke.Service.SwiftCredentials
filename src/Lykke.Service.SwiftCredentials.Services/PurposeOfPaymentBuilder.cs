using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.Assets.Client;
using Lykke.Service.ClientAccount.Client;
using Lykke.Service.SwiftCredentials.Core.Services;

namespace Lykke.Service.SwiftCredentials.Services
{
    [UsedImplicitly]
    public class PurposeOfPaymentBuilder : IPurposeOfPaymentBuilder
    {
        private readonly IClientAccountClient _clientAccountClient;
        private readonly IAssetsServiceWithCache _assetsService;

        public PurposeOfPaymentBuilder(
            IClientAccountClient clientAccountClient,
            IAssetsServiceWithCache assetsService)
        {
            _clientAccountClient = clientAccountClient;
            _assetsService = assetsService;
        }
        
        public async Task<string> Build(string template, string clientId, string assetId)
        {
            var client = await _clientAccountClient.GetByIdAsync(clientId);

            var asset = await _assetsService.TryGetAssetAsync(assetId);
            
            var assetTitle = asset.DisplayId ?? assetId;
            
            return string.Format(template, assetTitle, client.ExternalId);
        }
    }
}
