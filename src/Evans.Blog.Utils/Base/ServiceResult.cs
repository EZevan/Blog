using System;
using Evans.Blog.Utils.Base.Enums;

namespace Evans.Blog.Utils.Base
{
    /// <summary>
    /// The response entity of application service layer.
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Response code
        /// </summary>
        public ServiceResultCode Code { get; set; }

        /// <summary>
        /// Response message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Current unix timestamp(milliseconds)
        /// </summary>
        public long TimeStamp { get; } = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

        /// <summary>
        /// Successful
        /// </summary>
        public bool Success => Code == ServiceResultCode.Success;

        /// <summary>
        /// Response successful
        /// </summary>
        /// <param name="message"></param>
        public void IsSuccess(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Success;
        }

        /// <summary>
        /// Response failed
        /// </summary>
        /// <param name="message"></param>
        public void IsFailure(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Failure;
        }

        /// <summary>
        /// Response failed
        /// </summary>
        /// <param name="e"></param>
        public void IsFailure(Exception e)
        {
            Message = e.InnerException?.StackTrace;
            Code = ServiceResultCode.Failure;
        }
    }
}
