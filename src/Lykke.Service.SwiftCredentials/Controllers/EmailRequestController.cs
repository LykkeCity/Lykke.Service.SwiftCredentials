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
        private readonly IEventPublisher _eventPublisher;
        private readonly IPersonalDataService _personalDataService;
        private readonly IAssetsServiceWithCache _assetsService;
        private readonly ISwiftCredentialsService _swiftCredentialsService;
        
        public EmailRequestController(
            IEventPublisher eventPublisher,
            ISwiftCredentialsService swiftCredentialsService)
        {
            _eventPublisher = eventPublisher;
            _swiftCredentialsService = swiftCredentialsService;
        }
        
        [HttpPost]
        public async Task<IActionResult> EmailRequestAsync(EmailRequestCommand cmd)
        {
            var swiftCredentials = await _swiftCredentialsService.GetAsync(cmd.RegulationId, cmd.AssetId);

            var pd = await _personalDataService.GetAsync(cmd.ClientId);

            var asset = await _assetsService.TryGetAssetAsync(cmd.AssetId);
            
            _eventPublisher.PublishEvent(new SwiftCredentialsRequestedEvent
            {
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
                PurposeOfPaymentTemplate = swiftCredentials.PurposeOfPayment,
                RegulatorId = swiftCredentials.RegulatorId
            });

            return Ok();
        }
    }
}
