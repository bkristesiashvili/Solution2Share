using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Service
{
    public sealed class GraphAuthProvider : IAuthenticationProvider
    {
        #region PRIVATE FIELDS

        private string Scheme = "Bearer";

        private readonly Func<Task<string>> _acquireAccessToken;

        #endregion

        #region CTOR

        public GraphAuthProvider(Func<Task<string>> accessTokenCallBack)
        {
            _acquireAccessToken = accessTokenCallBack;
        }

        #endregion

        #region IMPLEMENTED AuthenticateRequestAsync METHOD

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var token = await _acquireAccessToken.Invoke();

            request.Headers.Authorization = new AuthenticationHeaderValue(Scheme, token);
        }

        #endregion
    }
}
