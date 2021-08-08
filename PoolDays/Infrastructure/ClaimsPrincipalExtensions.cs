using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
