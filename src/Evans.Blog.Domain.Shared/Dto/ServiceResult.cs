using System;
using System.Collections.Generic;
using Volo.Abp.Identity;

namespace Evans.Blog.Domain.Shared.Dto
{
    /// <summary>
    /// The response entity of application service layer.
    /// </summary>
    public class ServiceResult<T> where T : class
    {
        public const string ServerError = "500";

        public const string ServerErrorText = "Server Error!";

        /// <summary>
        /// The result of success or not
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Return data
        /// </summary>
        public T Data { get; set; }
        
        /// <summary>
        /// Error message
        /// </summary>
        public IList<ErrorInfo> Errors { get; set; }

        /// <summary>
        /// Current unix timestamp(milliseconds format)
        /// </summary>
        public long TimeStamp { get; } = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

        /// <summary>
        /// Response Successful
        /// </summary>
        /// <param name="data">Return data</param>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        public ServiceResult<T> IsSuccess(T data, string errorCode, string errorMessage)
        {
            Success = true;
            Data = data;
            Errors = new List<ErrorInfo>
            {
                new(){Code = errorCode,Message = errorMessage}
            };

            return this;
        }

        /// <summary>
        /// Response successful
        /// </summary>
        /// <param name="data">Return data</param>
        /// <param name="errorInfo">Error information</param>
        // public ServiceResult<T> IsSuccess(T data = null, ErrorInfo errorInfo = null)
        // {
        //     return IsSuccess(data,errorInfo?.Code,errorInfo?.Message);
        // }

        /// <summary>
        /// Response successful
        /// </summary>
        /// <param name="data">Return data</param>
        /// <param name="errorInfos">Error information collections</param>
        public ServiceResult<T> IsSuccess(T data = null, IList<ErrorInfo> errorInfos = null)
        {
            Success = true;
            Data = data;
            Errors = errorInfos;

            return this;
        }

        /// <summary>
        /// Response Successful
        /// </summary>
        /// <param name="data">Return data</param>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        public ServiceResult<T> IsFailure(T data = null, string errorCode = null, string errorMessage = null)
        {
            Success = true;
            Data = data;
            Errors = new List<ErrorInfo>
            {
                new(){Code = errorCode,Message = errorMessage}
            };

            return this;
        }

        /// <summary>
        /// Response successful
        /// </summary>
        /// <param name="data">Return data</param>
        /// <param name="errorInfo">Error information</param>
        public ServiceResult<T> IsFailure(T data = null, ErrorInfo errorInfo = null)
        {
            return IsFailure(data,errorInfo?.Code,errorInfo?.Message);
        }

        /// <summary>
        /// Response successful
        /// </summary>
        /// <param name="data">Return data</param>
        /// <param name="errorInfos">Error information collections</param>
        public ServiceResult<T> IsFailure(T data = null, IList<ErrorInfo> errorInfos = null)
        {
            Success = true;
            Data = data;
            Errors = errorInfos;

            return this;
        }
    }
}
