using Microsoft.AspNetCore.Builder;
using APIEmpHub.LogResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEmpHub.LogRequest
{
    public static class LogRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseiAspNetcoreLogRequest(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogRequestMiddleware>();
        }
    }
}
