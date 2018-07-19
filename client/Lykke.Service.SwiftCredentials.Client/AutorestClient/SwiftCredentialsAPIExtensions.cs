// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.SwiftCredentials.Client.AutorestClient
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for SwiftCredentialsAPI.
    /// </summary>
    public static partial class SwiftCredentialsAPIExtensions
    {
            /// <summary>
            /// Checks service is alive
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static object IsAlive(this ISwiftCredentialsAPI operations)
            {
                return operations.IsAliveAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Checks service is alive
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> IsAliveAsync(this ISwiftCredentialsAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.IsAliveWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns all swift credentials.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<SwiftCredentialsModel> SwiftCredentialsGetAll(this ISwiftCredentialsAPI operations)
            {
                return operations.SwiftCredentialsGetAllAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns all swift credentials.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<SwiftCredentialsModel>> SwiftCredentialsGetAllAsync(this ISwiftCredentialsAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SwiftCredentialsGetAllWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates swift credentials.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='model'>
            /// The model that describe a swift credentials.
            /// </param>
            public static ErrorResponse SwiftCredentialsUpdate(this ISwiftCredentialsAPI operations, SwiftCredentialsModel model = default(SwiftCredentialsModel))
            {
                return operations.SwiftCredentialsUpdateAsync(model).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates swift credentials.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='model'>
            /// The model that describe a swift credentials.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ErrorResponse> SwiftCredentialsUpdateAsync(this ISwiftCredentialsAPI operations, SwiftCredentialsModel model = default(SwiftCredentialsModel), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SwiftCredentialsUpdateWithHttpMessagesAsync(model, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Adds swift credentials.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='model'>
            /// The model that describe a swift credentials.
            /// </param>
            public static ErrorResponse SwiftCredentialsAdd(this ISwiftCredentialsAPI operations, SwiftCredentialsModel model = default(SwiftCredentialsModel))
            {
                return operations.SwiftCredentialsAddAsync(model).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Adds swift credentials.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='model'>
            /// The model that describe a swift credentials.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ErrorResponse> SwiftCredentialsAddAsync(this ISwiftCredentialsAPI operations, SwiftCredentialsModel model = default(SwiftCredentialsModel), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SwiftCredentialsAddWithHttpMessagesAsync(model, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns swift credentials by regulation and asset.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='regulationId'>
            /// The regulation id.
            /// </param>
            /// <param name='assetId'>
            /// The asset id.
            /// </param>
            public static object SwiftCredentialsGet(this ISwiftCredentialsAPI operations, string regulationId, string assetId)
            {
                return operations.SwiftCredentialsGetAsync(regulationId, assetId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns swift credentials by regulation and asset.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='regulationId'>
            /// The regulation id.
            /// </param>
            /// <param name='assetId'>
            /// The asset id.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> SwiftCredentialsGetAsync(this ISwiftCredentialsAPI operations, string regulationId, string assetId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SwiftCredentialsGetWithHttpMessagesAsync(regulationId, assetId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes swift credentials.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='regulationId'>
            /// The regulation id.
            /// </param>
            /// <param name='assetId'>
            /// The asset id.
            /// </param>
            public static void SwiftCredentialsDelete(this ISwiftCredentialsAPI operations, string regulationId, string assetId)
            {
                operations.SwiftCredentialsDeleteAsync(regulationId, assetId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes swift credentials.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='regulationId'>
            /// The regulation id.
            /// </param>
            /// <param name='assetId'>
            /// The asset id.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task SwiftCredentialsDeleteAsync(this ISwiftCredentialsAPI operations, string regulationId, string assetId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.SwiftCredentialsDeleteWithHttpMessagesAsync(regulationId, assetId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}