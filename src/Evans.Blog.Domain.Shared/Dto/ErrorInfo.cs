using System;
using System.Collections.Generic;

namespace Evans.Blog.Domain.Shared.Dto
{
    public class ErrorInfo
    {
        /// <summary>
        /// Error code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

    }
}