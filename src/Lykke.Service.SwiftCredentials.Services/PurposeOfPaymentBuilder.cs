using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.Assets.Client;
using Lykke.Service.PersonalData.Contract;
using Lykke.Service.SwiftCredentials.Core.Services;

namespace Lykke.Service.SwiftCredentials.Services
{
    [UsedImplicitly]
    public class PurposeOfPaymentBuilder : IPurposeOfPaymentBuilder
    {
        private readonly IPersonalDataService _personalDataService;
        private readonly IAssetsServiceWithCache _assetsService;

        public PurposeOfPaymentBuilder(
            IPersonalDataService personalDataService,
            IAssetsServiceWithCache assetsService)
        {
            _personalDataService = personalDataService;
            _assetsService = assetsService;
        }
        
        public async Task<string> Build(string template, string clientId, string assetId)
        {
            var pd = await _personalDataService.GetAsync(clientId);

            var asset = await _assetsService.TryGetAssetAsync(assetId);
            
            var assetTitle = asset.DisplayId ?? assetId;
            
            var clientIdentity = pd.Email != null ? pd.Email.Replace("@", ".") : "{1}";
            var purposeOfPayment = string.Format(template, assetTitle, clientIdentity);

            if (!purposeOfPayment.Contains(assetId) && !purposeOfPayment.Contains(assetTitle))
                purposeOfPayment += assetTitle;

            if (!purposeOfPayment.Contains(clientIdentity))
                purposeOfPayment += clientIdentity;

            return purposeOfPayment;
        }
    }
}
