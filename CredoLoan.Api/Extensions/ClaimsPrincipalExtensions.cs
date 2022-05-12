using System.Security.Claims;

namespace REaDConnect.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetClientId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
