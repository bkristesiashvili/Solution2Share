using System;
using System.Security.Claims;

namespace Solution2Share.Service.Extensions;

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

    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var tid = claimsPrincipal.FindFirstValue(GraphClaimTypes.UserId);
        Guid.TryParse(tid, out var userId);
        return userId;
    }

    public static void AddUserId(this ClaimsPrincipal claimsPrincipal, Guid id)
    {
        var identity = claimsPrincipal.Identity as ClaimsIdentity;

        identity.AddClaim(new Claim(GraphClaimTypes.UserId, id.ToString()));
    }

    #endregion
}
