using System;
using System.Security.Claims;

namespace Papyrus.Api.Extesnsions
{
    public static class ClaimsPrincipleExtensions
    {
        public static bool CheckAuthorization(this System.Security.Claims.ClaimsPrincipal user, Guid memberId)
        {

            if (user == null)
                return false;

            if (user.FindFirst(ClaimTypes.NameIdentifier) == null)
                return false;

            if (memberId != Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return false;
            }

            return true;
        }
    }
}