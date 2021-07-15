using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Service.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        #region EXTENSION METHODS

        public static string GetUserGraphDisplayName(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.FindFirstValue(GraphClaimTypes.DisplayName);

        public static string GetUserGraphEmail(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.FindFirstValue(GraphClaimTypes.Email);

        public static Guid GetUserGraphTenant(this ClaimsPrincipal claimsPrincipal)
        {
            var tid = claimsPrincipal.FindFirstValue(GraphClaimTypes.Tenant);
            Guid.TryParse(tid, out var tenantId);
            return tenantId;
        }

        #endregion
    }
}
