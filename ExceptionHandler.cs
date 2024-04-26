using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using cafemanagement.Exceptions;

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

                        string message;

                        if (exception is CustomerAlreadyExistException)
                        {
                            message = "Customer already exists.";
                        }
                        else if (exception is CustomerNotFoundException)
                        {
                            message = "Customer not found.";
                        }
                        else if (exception is MenuItemAlreadyExistsException)
                        {
                            message = "Menu item already exists.";
                        }
                        else if (exception is MenuItemNotFoundException)
                        {
                            message = "Menu item not found.";
                        }
                        else if (exception is OrderNotFoundException)
                        {
                            message = "Order not found.";
                        }
                        else if (exception is TableBookingNotFoundException)
                        {
                            message = "Table booking not found.";
                        }
                        else
                        {
                            message = "An error occurred.";
                        }

                        var response = new { StatusCode = statusCode, Message = message };
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                });
            });
        }
    }
}
