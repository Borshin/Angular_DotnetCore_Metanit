using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathFinder.Exceptions
{
    /// <summary>
    /// Common Web API errors class.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Initialization.
        /// </summary>
        /// <param name="message">Error message.</param>
        public ApiError(string message)
        {
            this.Message = message;
        }
    }
}
