using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEmpHub.LogResponse
{
    public static class LogRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseiAspNetcoreLogResponse(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogResponseMiddleware>();
        }
    }
}
