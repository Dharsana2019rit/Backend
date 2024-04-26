using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;

namespace cafemanagement.Aspects
{
    public static class ExceptionHandler
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var errorContext = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorContext != null)
                    {
                        var exception = errorContext.Error;
                        var statusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.StatusCode = statusCode;
                        var response = new { StatusCode = statusCode, Message = exception.Message };
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                });
            });
        }
    }
}
