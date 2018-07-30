using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.SwiftCredentials.Client.Exceptions;
using Lykke.Service.SwiftCredentials.Client.Models;

namespace Lykke.Service.SwiftCredentials.Client
{
    /// <summary>
    /// Contains methods for work with swift credentials service.
    /// </summary>
    public interface ISwiftCredentialsClient
    {
        /// <summary>
        /// Returns all swift credentials.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SwiftCredentialsModel>> GetAllAsync();

        /// <summary>
        /// Returns swift credentials by regulation and asset.
        /// </summary>
        /// <param name="regulationId">The regulation id.</param>
        /// <param name="assetId">The asset id.</param>
        /// <returns>The <see cref="SwiftCredentialsModel"/>.</returns>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an unexpected response received.</exception>
        Task<SwiftCredentialsModel> GetAsync(string regulationId, string assetId);

        /// <summary>
        /// Adds swift credentials.
        /// </summary>
        /// <param name="model">The model that describe a swift credentials.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        Task AddAsync(SwiftCredentialsModel model);

        /// <summary>
        /// Updates swift credentials.
        /// </summary>
        /// <param name="model">The model that describe a swift credentials.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        Task UpdateAsync(SwiftCredentialsModel model);

        /// <summary>
        /// Deletes swift credentials.
        /// </summary>
        /// <param name="regulationId">The regulation id.</param>
        /// <param name="assetId">The asset id.</param>
        Task DeleteAsync(string regulationId, string assetId);
        
        /// <summary>
        /// Requests email with swift credentials.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="regulationId">The regulation id.</param>
        /// <param name="assetId">The asset id.</param>
        /// <param name="amount">Amount.</param>
        Task EmailRequest(string clientId, string regulationId, string assetId, double amount);

        /// <summary>
        /// Returns formatted swift credentials by client, regulation and asset.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="regulationId">The regulation id.</param>
        /// <param name="assetId">The asset id.</param>
        /// <returns>The <see cref="SwiftCredentialsModel"/>.</returns>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an unexpected response received.</exception>
        Task<SwiftCredentialsModel> GetForClientAsync(string clientId, string regulationId, string assetId);
    }
}
