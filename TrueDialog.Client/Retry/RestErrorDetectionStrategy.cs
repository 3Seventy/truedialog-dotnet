using System;
using System.Web;

using TrueDialog.Exceptions;

namespace TrueDialog.Retry
{
    /// <summary>
    /// Detection strategy for figuring out if we should retry or rest request or not.
    /// </summary>
    class RestErrorDetectionStrategy : IRetryDetectionStrategy
    {
        /// <summary>
        /// Checks to see if the supplied exception is a transient error.
        /// </summary>
        /// <param name="ex">The exception to check.</param>
        /// <returns>True if this is a transient fault, false if not.</returns>
        public bool IsTransient(Exception ex)
        {
            var httpEx = ex as HttpException;

            if (httpEx != null)
            {
                int errCode = httpEx.GetHttpCode();

                // Only retry on 500 type errors, all other errors we pass on to the caller.
                return (errCode >= 500);
            }

            // Retry on network errors only, all other exceptions we pass on to the caller.
            return (ex is NetworkException);
        }
    }
}
