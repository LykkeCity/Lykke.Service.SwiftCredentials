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
        private readonly IPurposeOfPaymentBuilder _purposeOfPaymentBuilder;
        
        public EmailRequestController(
            ICqrsEngine cqrsEngine,
            IPersonalDataService personalDataService,
            IAssetsServiceWithCache assetsServiceWithCache,
            ISwiftCredentialsService swiftCredentialsService,
            IPurposeOfPaymentBuilder purposeOfPaymentBuilder)
        {
            _cqrsEngine = cqrsEngine;
            _personalDataService = personalDataService;
            _assetsService = assetsServiceWithCache;
            _swiftCredentialsService = swiftCredentialsService;
            _purposeOfPaymentBuilder = purposeOfPaymentBuilder;
        }
        
        [HttpPost]
        public async Task<IActionResult> EmailRequestAsync(EmailRequestCommand cmd)
        {
            var swiftCredentials = await _swiftCredentialsService.GetAsync(cmd.RegulationId, cmd.AssetId);

            var pd = await _personalDataService.GetAsync(cmd.ClientId);

            var asset = await _assetsService.TryGetAssetAsync(cmd.AssetId);
            
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
                PurposeOfPayment = await _purposeOfPaymentBuilder.Build(
                    swiftCredentials.PurposeOfPayment,
                    cmd.ClientId,
                    cmd.AssetId),
                RegulatorId = swiftCredentials.RegulatorId
            }, SwiftCredentialsBoundedContext.Name);

            return Ok();
        }
    }
}
