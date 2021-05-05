using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evans.Blog.Domain.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Volo.Abp;
using Volo.Abp.ExceptionHandling;

namespace Evans.Blog.Filters
{
    public class CustomExceptionFilter : BusinessException,IExceptionFilter
    {
        public async void OnException(ExceptionContext context)
        {
            Log.Logger.Error(context.Exception,context.Exception.Message);

            await ExceptionHandlerAsync(context.HttpContext, Code, Message);
        }

        private async Task ExceptionHandlerAsync(HttpContext context, string errorCode, string errorMessage)
        {
            context.Response.ContentType = "application/json;charset=utf-8";

            var result = new ServiceResult<string>();

            var errorInfo = new ErrorInfo
            {
                Code = errorCode,
                Message = errorMessage
            };

            result.IsFailure(null, errorInfo);

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
