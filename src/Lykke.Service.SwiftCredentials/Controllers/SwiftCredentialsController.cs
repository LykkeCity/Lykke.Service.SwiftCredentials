using System.Collections.Generic;
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
    public class SwiftCredentialsController : Controller
    {
        private readonly ISwiftCredentialsService _swiftCredentialsService;

        public SwiftCredentialsController(ISwiftCredentialsService swiftCredentialsService)
        {
            _swiftCredentialsService = swiftCredentialsService;
        }

        /// <summary>
        /// Returns all swift credentials.
        /// </summary>
        /// <response code="200">The collection of swift credentials.</response>
        [HttpGet]
        [SwaggerOperation("SwiftCredentialsGetAll")]
        [ProducesResponseType(typeof(IEnumerable<SwiftCredentialsModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ISwiftCredentials> swiftCredentials = await _swiftCredentialsService.GetAllAsync();

            var model = Mapper.Map<IEnumerable<SwiftCredentialsModel>>(swiftCredentials);

            return Ok(model);
        }

        /// <summary>
        /// Returns swift credentials by regulation and asset.
        /// </summary>
        /// <param name="regulationId">The regulation id.</param>
        /// <param name="assetId">The asset id.</param>
        /// <response code="200">The swift credentials.</response>
        /// <response code="404">The swift credentials not found.</response>
        [HttpGet]
        [Route("{regulationId}/{assetId}")]
        [SwaggerOperation("SwiftCredentialsGet")]
        [ProducesResponseType(typeof(SwiftCredentialsModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAsync(string regulationId, string assetId)
        {
            ISwiftCredentials swiftCredentials = await _swiftCredentialsService.GetAsync(regulationId, assetId);

            var model = Mapper.Map<SwiftCredentialsModel>(swiftCredentials);

            return Ok(model);
        }

        /// <summary>
        /// Adds swift credentials.
        /// </summary>
        /// <param name="model">The model that describe a swift credentials.</param>
        /// <response code="204">The swift credentials successfully added.</response>
        /// <response code="400">The swift credentials model is invalid.</response>
        /// <response code="409">The swift credentials already exists.</response>
        [HttpPost]
        [SwaggerOperation("SwiftCredentialsAdd")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> AddAsync([FromBody] SwiftCredentialsModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ErrorResponse.Create("Invalid model", ModelState));

            var swiftCredentials = Mapper.Map<Core.Domain.SwiftCredentials>(model);

            await _swiftCredentialsService.InsertAsync(swiftCredentials);

            return NoContent();
        }

        /// <summary>
        /// Updates swift credentials.
        /// </summary>
        /// <param name="model">The model that describe a swift credentials.</param>
        /// <response code="204">The swift credentials successfully updated.</response>
        /// <response code="400">The swift credentials model is invalid.</response>
        /// <response code="404">The swift credentials not found.</response>
        [HttpPut]
        [SwaggerOperation("SwiftCredentialsUpdate")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateAsync([FromBody] SwiftCredentialsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ErrorResponse.Create("Invalid model", ModelState));

            var swiftCredentials = Mapper.Map<Core.Domain.SwiftCredentials>(model);

            await _swiftCredentialsService.UpdateAsync(swiftCredentials);

            return NoContent();
        }

        /// <summary>
        /// Deletes swift credentials.
        /// </summary>
        /// <param name="regulationId">The regulation id.</param>
        /// <param name="assetId">The asset id.</param>
        /// <response code="204">The swift credentials successfully deleted.</response>
        [HttpDelete]
        [Route("{regulationId}/{assetId}")]
        [SwaggerOperation("SwiftCredentialsDelete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteAsync(string regulationId, string assetId)
        {
            await _swiftCredentialsService.DeleteAsync(regulationId, assetId);

            return NoContent();
        }
    }
}
