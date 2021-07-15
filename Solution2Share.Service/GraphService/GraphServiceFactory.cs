using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Service
{
    public static class GraphServiceFactory
    {
        #region STATIC METHODS

        public static GraphServiceClient GetAuthenticatedClient(Func<Task<string>> accessToken,
            string apiBaseUrl)
            => new(apiBaseUrl, new GraphAuthProvider(accessToken));

        #endregion
    }
}
