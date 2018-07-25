using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.SwiftCredentials.Core.Domain;
using Lykke.Service.SwiftCredentials.Core.Services;
using Lykke.Service.SwiftCredentials.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.SwiftCredentials.Controllers
{
    [Route("api/[controller]")]
    public class SwiftCredentialsForClientController : Controller
    {
        private readonly ISwiftCredentialsService _swiftCredentialsService;
        private readonly IPurposeOfPaymentBuilder _purposeOfPaymentBuilder;

        public SwiftCredentialsForClientController(
            ISwiftCredentialsService swiftCredentialsService,
            IPurposeOfPaymentBuilder purposeOfPaymentBuilder)
        {
            _swiftCredentialsService = swiftCredentialsService;
            _purposeOfPaymentBuilder = purposeOfPaymentBuilder;
        }
        
        [HttpGet]
        [Route("{clientId}/{regulationId}/{assetId}")]
        [SwaggerOperation("SwiftCredentialsForClientGet")]
        [ProducesResponseType(typeof(SwiftCredentialsModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAsync(string clientId, string regulationId, string assetId)
        {
            ISwiftCredentials swiftCredentials = await _swiftCredentialsService.GetAsync(regulationId, assetId);

            var model = Mapper.Map<SwiftCredentialsModel>(swiftCredentials);

            model.PurposeOfPayment =
                await _purposeOfPaymentBuilder.Build(
                    model.PurposeOfPayment,
                    clientId,
                    assetId);

            return Ok(model);
        }
    }
}
