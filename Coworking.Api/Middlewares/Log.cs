using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Coworking.Api.Middlewares
{
    public class Log
    {

        private readonly RequestDelegate _next;
        private readonly TelemetryClient _telemetryClient;

        public Log(RequestDelegate next, TelemetryClient telemetryClient)
        {
            _next = next;
            _telemetryClient = telemetryClient;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            await _next(context);

            context.Request.Body = originalRequestBody;

            Tracerequest(requestBodyText, url, context.Request.Method);

        }

        private void Tracerequest(string payload, string url, string method)
        {

            var telemetry = new TraceTelemetry(url);

            telemetry.Properties.Add("Body", payload);
            telemetry.Properties.Add("Method", method);
            _telemetryClient.TrackTrace(telemetry);
        }


    }
}
