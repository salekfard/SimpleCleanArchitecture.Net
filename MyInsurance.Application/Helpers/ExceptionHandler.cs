using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using MyInsurance.Application.Helpers.Exceptions;
using MyInsurance.Application.Models;
using MyInsurance.Domain.Resources;
using Newtonsoft.Json;

namespace MyInsurance.Application.Helpers
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _nextDelegate;

        public ExceptionHandler(RequestDelegate next)
        {
            _nextDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _nextDelegate(httpContext);
            }
            catch (GeneralException ex)
            {
                await ConfigFinalResponse(httpContext, (string.IsNullOrWhiteSpace(ex.Message)) ? Messages.GeneralException : ex.Message);
            }
            catch (Exception ex)
            {
                await ConfigFinalResponse(httpContext, Messages.GeneralException);
            }

        }

        private static async Task ConfigFinalResponse(HttpContext context, string message)
        {
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new GeneralResponseModel(false, message)));
        }
    }
}

