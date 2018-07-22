using System.Threading.Tasks;
using Lykke.Cqrs;
using Lykke.Service.SwiftCredentials.Contracts;
using Lykke.Service.SwiftCredentials.Core.Services;
using Lykke.Service.SwiftCredentials.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.SwiftCredentials.Controllers
{
    public class EmailRequestController : Controller
    {
        private readonly IEventPublisher _eventPublisher;
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
            
            _eventPublisher.PublishEvent(new SwiftCredentialsRequestedEvent
            {
                AccountName = swiftCredentials.AccountName,
                AccountNumber = swiftCredentials.AccountNumber,
                AssetId = swiftCredentials.AssetId,
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
