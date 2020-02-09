using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static Guid GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            var strUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Guid userId;
            if (Guid.TryParse(strUserId, out userId))
                return userId;

            throw new UnauthorizedAccessException();

        }
    }
}