using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Evans.Blog.Domain.Shared.Dto;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Volo.Abp;
using Volo.Abp.ExceptionHandling;

namespace Evans.Blog.Filters
{
    public class CustomExceptionMiddleware : BusinessException
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await ExceptionHandlerAsync(context, Code, e.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                if (statusCode != StatusCodes.Status200OK)
                {
                    //Enum.TryParse(typeof(HttpStatusCode), statusCode.ToString(), out var message);
                    await ExceptionHandlerAsync(context, Code, Message);
                }
            }
        }

        private async Task ExceptionHandlerAsync(HttpContext context, string errorCode, object errorMessage)
        {
            context.Response.ContentType = "application/json;charset=utf-8";

            var result = new ServiceResult<string>();

            var errorInfo = new ErrorInfo
            {
                Code = errorCode,
                Message = (string)errorMessage
            };

            result.IsFailure(null, errorInfo);

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
