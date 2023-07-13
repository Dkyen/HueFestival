using System;
using Microsoft.AspNetCore.Http;
namespace HueFestival.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext.Items["UserId"] as string ??
                throw new Exception("User ID not found in HttpContext.Items");
        }

    }
}