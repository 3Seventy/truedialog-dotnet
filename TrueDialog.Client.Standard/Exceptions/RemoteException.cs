using System;
using System.Collections.Generic;
using System.Net;

using TrueDialog.Model;

namespace TrueDialog.Exceptions
{
    /// <summary>
    /// An exception that is returned by the remote server when an error is detected..
    /// </summary>
    /// <remarks>
    /// RemoteException errors are often returned when the server returns a 400 or other
    /// HTTP error.
    /// </remarks>
    [Serializable]
    public class RemoteException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusCode">The status code that caused the exception.</param>
        /// <param name="errors">The list of errors found.</param>
        internal RemoteException(HttpStatusCode statusCode, IEnumerable<ErrorDetail> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        /// <summary>
        /// The HTTP status code that caused this exception to be thrown.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Contains a list of errors that was returned by the server.
        /// </summary>
        public IEnumerable<ErrorDetail> Errors { get; private set; }
    }
}
