using System;
using Common.Log;

namespace Lykke.Service.SwiftCredentials.Client
{
    public class SwiftCredentialsClient : ISwiftCredentialsClient, IDisposable
    {
        private readonly ILog _log;

        public SwiftCredentialsClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
