using System;

namespace SUS.Atomic.Base.Exceptions
{
    /// <summary>
    /// Exception thrown when there is a client-side error while calling the Atomic API.
    /// </summary>
    public class AtomicClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicClientException"/> class.
        /// </summary>
        public AtomicClientException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicClientException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AtomicClientException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicClientException"/> class with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public AtomicClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
