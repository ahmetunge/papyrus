using System;
using System.Net;
using System.Threading.Tasks;
using Core.Utilities.Errors;
using Microsoft.AspNetCore.Http;
using Papyrus.Business.Constants;

namespace Papyrus.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType="application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(new RestException
            {
                Message = Messages.InternalServerError,
                StatusCode = httpContext.Response.StatusCode
            }.ToString());
        }
    }
}