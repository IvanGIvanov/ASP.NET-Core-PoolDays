using System.Security.Claims;

namespace PoolDays.Infrastructure
{
    using static WebConstants;

    public static class ClaimsPrincipalExtensions
    {  
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool isAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdministatorRoleName);
    }
}
