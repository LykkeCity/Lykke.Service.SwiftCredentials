using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.SwiftCredentials.Client.AutorestClient;
using Lykke.Service.SwiftCredentials.Client.Exceptions;
using Lykke.Service.SwiftCredentials.Client.Models;

namespace Lykke.Service.SwiftCredentials.Client
{
    /// <summary>
    /// Contains methods for work with swift credentials service.
    /// </summary>
    public class SwiftCredentialsClient : ISwiftCredentialsClient, IDisposable
    {
        private SwiftCredentialsAPI _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwiftCredentialsClient"/> class.
        /// </summary>
        /// <param name="settings">The service settings.</param>
        public SwiftCredentialsClient(SwiftCredentialsServiceClientSettings settings)
        {
            _service = new SwiftCredentialsAPI(new Uri(settings.ServiceUrl));
        }

        /// <summary>
        /// Returns all swift credentials.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SwiftCredentialsModel>> GetAllAsync()
        {
            IEnumerable<AutorestClient.Models.SwiftCredentialsModel> swiftCredentials =
                await _service.SwiftCredentialsGetAllAsync();

            return swiftCredentials.Select(o => o.Map());
        }

        /// <summary>
        /// Returns swift credentials by regulation and asset.
        /// </summary>
        /// <param name="regulationId">The regulation id.</param>
        /// <param name="assetId">The asset id.</param>
        /// <returns>The <see cref="SwiftCredentialsModel"/>.</returns>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an unexpected response received.</exception>
        public async Task<SwiftCredentialsModel> GetAsync(string regulationId, string assetId)
        {
            object result = await _service.SwiftCredentialsGetAsync(regulationId, assetId);

            if (result is AutorestClient.Models.SwiftCredentialsModel regulationModel)
                return regulationModel.Map();

            if (result is AutorestClient.Models.ErrorResponse errorResponse)
                throw new ErrorResponseException(errorResponse.ErrorMessage);

            throw new InvalidOperationException($"Unexpected response type: {result?.GetType()}");
        }

        /// <summary>
        /// Adds swift credentials.
        /// </summary>
        /// <param name="model">The model that describe a swift credentials.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task AddAsync(SwiftCredentialsModel model)
        {
            AutorestClient.Models.ErrorResponse errorResponse =
                await _service.SwiftCredentialsAddAsync(model.Map());

            if (errorResponse != null)
                throw new ErrorResponseException(errorResponse.ErrorMessage);
        }

        /// <summary>
        /// Updates swift credentials.
        /// </summary>
        /// <param name="model">The model that describe a swift credentials.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task UpdateAsync(SwiftCredentialsModel model)
        {
            AutorestClient.Models.ErrorResponse errorResponse =
                await _service.SwiftCredentialsUpdateAsync(model.Map());

            if (errorResponse != null)
                throw new ErrorResponseException(errorResponse.ErrorMessage);
        }

        /// <summary>
        /// Deletes swift credentials.
        /// </summary>
        /// <param name="regulationId">The regulation id.</param>
        /// <param name="assetId">The asset id.</param>
        public async Task DeleteAsync(string regulationId, string assetId)
        {
            await _service.SwiftCredentialsDeleteAsync(regulationId, assetId);
        }

        /// <summary>
        /// Releases resources.
        /// </summary>
        public void Dispose()
        {
            if (_service == null)
                return;
            _service.Dispose();
            _service = null;
        }
    }
}
