using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Security.Identification
{
    public static class UserIdentification
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static Guid UserId
        {
            get
            {
                _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

                return _httpContextAccessor.GetUserId();
            }

        }


    }
}