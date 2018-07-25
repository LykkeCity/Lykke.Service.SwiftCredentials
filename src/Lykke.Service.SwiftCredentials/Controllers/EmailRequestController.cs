using System;
using System.Threading.Tasks;
using Lykke.Cqrs;
using Lykke.Service.Assets.Client;
using Lykke.Service.Assets.Client.Models;
using Lykke.Service.PersonalData.Contract;
using Lykke.Service.SwiftCredentials.Contracts;
using Lykke.Service.SwiftCredentials.Core.Services;
using Lykke.Service.SwiftCredentials.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.SwiftCredentials.Controllers
{
    [Route("api/[controller]")]
    public class EmailRequestController : Controller
    {
        private readonly ICqrsEngine _cqrsEngine;
        private readonly IPersonalDataService _personalDataService;
        private readonly IAssetsServiceWithCache _assetsService;
        private readonly ISwiftCredentialsService _swiftCredentialsService;
        
        public EmailRequestController(
            ICqrsEngine cqrsEngine,
            IPersonalDataService personalDataService,
            IAssetsServiceWithCache assetsServiceWithCache,
            ISwiftCredentialsService swiftCredentialsService)
        {
            _cqrsEngine = cqrsEngine;
            _personalDataService = personalDataService;
            _assetsService = assetsServiceWithCache;
            _swiftCredentialsService = swiftCredentialsService;
        }
        
        [HttpPost]
        public async Task<IActionResult> EmailRequestAsync(EmailRequestCommand cmd)
        {
            var swiftCredentials = await _swiftCredentialsService.GetAsync(cmd.RegulationId, cmd.AssetId);

            var pd = await _personalDataService.GetAsync(cmd.ClientId);

            var asset = await _assetsService.TryGetAssetAsync(cmd.AssetId);
            
            var assetTitle = asset.DisplayId ?? cmd.AssetId;

            var clientIdentity = pd.Email != null ? pd.Email.Replace("@", ".") : "{1}";
            var purposeOfPayment = string.Format(swiftCredentials.PurposeOfPayment, assetTitle, clientIdentity);

            if (!purposeOfPayment.Contains(cmd.AssetId) && !purposeOfPayment.Contains(assetTitle))
                purposeOfPayment += assetTitle;

            if (!purposeOfPayment.Contains(clientIdentity))
                purposeOfPayment += clientIdentity;
            
            _cqrsEngine.PublishEvent(new SwiftCredentialsRequestedEvent
            {
                Email = pd.Email,
                ClientName = pd.FullName,
                Amount = cmd.Amount,
                Year = DateTime.UtcNow.Year.ToString(),
                AccountName = swiftCredentials.AccountName,
                AccountNumber = swiftCredentials.AccountNumber,
                AssetId = swiftCredentials.AssetId,
                AssetSymbol = asset.Symbol ?? asset.DisplayId,
                BankAddress = swiftCredentials.BankAddress,
                Bic = swiftCredentials.BIC,
                CompanyAddress = swiftCredentials.CompanyAddress,
                CorrespondentAccount = swiftCredentials.CorrespondentAccount,
                PurposeOfPayment = purposeOfPayment,
                RegulatorId = swiftCredentials.RegulatorId
            }, SwiftCredentialsBoundedContext.Name);

            return Ok();
        }
    }
}
