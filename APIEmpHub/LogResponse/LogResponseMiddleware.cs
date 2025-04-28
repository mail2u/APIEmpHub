using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEmpHub.LogResponse
{
    public class LogResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogResponseMiddleware> _logger;
        private Func<string, Exception, string> _defaultFormatter = (state, exception) => state;

        public LogResponseMiddleware(RequestDelegate next, ILogger<LogResponseMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            StringBuilder consoleOutputStringBuilder = new StringBuilder();

            // _logger.LogInformation($"\n=={DateTime.Now.ToString()} =====LogResponseMiddleware start=========================");
            consoleOutputStringBuilder.Append($"\n┌==1.{DateTime.Now.ToString()} =====LogResponseMiddleware start=========================┐");

            var url = UriHelper.GetDisplayUrl(context.Request);
            // _logger.LogInformation($"\n{DateTime.Now.ToString()} Request url: {url},\nRequest Method: {context.Request.Method},Request Schem: {context.Request.Scheme}, UserAgent: {context.Request.Headers[HeaderNames.UserAgent].ToString()}");
            consoleOutputStringBuilder.Append($"\n{DateTime.Now.ToString()} Request url: {url},\nRequest Method: {context.Request.Method},Request Schem: {context.Request.Scheme}, UserAgent: {context.Request.Headers[HeaderNames.UserAgent].ToString()}");

            //Header
            string allkeypair = "";
            IHeaderDictionary headers = context.Response.Headers;

            foreach (var headerValuePair in headers)
            {
                allkeypair += "\n" + headerValuePair.Key + "：" + headerValuePair.Value;

            }



            // this._logger.LogInformation($"\n{DateTime.Now.ToString()} Response.Headers:{0}\n" , allkeypair.ToString());

            consoleOutputStringBuilder.Append($"\n{DateTime.Now.ToString()}Response.Headers:\n" + allkeypair.ToString());

            // _logger.LogInformation($"\n|--{DateTime.Now.ToString()} -----LogResponseMiddleware Response.Headers end-----|");

            consoleOutputStringBuilder.Append($"\n|--{DateTime.Now.ToString()} 2.-----LogRequestMiddleware Response.Headers end-----|");


            var bodyStream = context.Response.Body;

            var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;

            await _next(context);

            responseBodyStream.Seek(0, SeekOrigin.Begin);
            var responseBody = new StreamReader(responseBodyStream).ReadToEnd();
            // _logger.Log(LogLevel.Information, 1, $"RESPONSE LOG: {responseBody}", null, _defaultFormatter);

            // this._logger.LogInformation($"\n{DateTime.Now.ToString()} response Body:{responseBody}\n");
            consoleOutputStringBuilder.Append($"\n{DateTime.Now.ToString()} response Body:{responseBody}\n");

            // _logger.LogInformation($"\n=={DateTime.Now.ToString()} =====LogResponseMiddleware end=========================");
            consoleOutputStringBuilder.Append($"\n└=={DateTime.Now.ToString()}   ──=====LogResponseMiddleware end=========================┘");

            _logger.LogInformation(consoleOutputStringBuilder.ToString());

            responseBodyStream.Seek(0, SeekOrigin.Begin);
            await responseBodyStream.CopyToAsync(bodyStream);
        }
    }
}
