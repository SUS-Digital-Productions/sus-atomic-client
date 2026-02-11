using SUS.Atomic.Base.Exceptions;
using Xunit;

namespace SUS.Atomic.Tests.Base
{
    /// <summary>
    /// Tests for custom exception types.
    /// </summary>
    public class ExceptionTests
    {
        [Fact]
        public void AtomicApiException_CanBeCreatedWithMessage()
        {
            // Arrange
            var message = "API returned an error";

            // Act
            var exception = new AtomicApiException(message);

            // Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void AtomicApiException_CanBeCreatedWithMessageAndInnerException()
        {
            // Arrange
            var message = "API returned an error";
            var innerException = new Exception("Inner error");

            // Act
            var exception = new AtomicApiException(message, innerException);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        [Fact]
        public void AtomicClientException_CanBeCreatedWithMessage()
        {
            // Arrange
            var message = "Client error occurred";

            // Act
            var exception = new AtomicClientException(message);

            // Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void AtomicClientException_CanBeCreatedWithMessageAndInnerException()
        {
            // Arrange
            var message = "Client error occurred";
            var innerException = new Exception("Inner error");

            // Act
            var exception = new AtomicClientException(message, innerException);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        [Fact]
        public void AtomicApiException_IsException()
        {
            // Arrange & Act
            var exception = new AtomicApiException("Test");

            // Assert
            Assert.IsAssignableFrom<Exception>(exception);
        }

        [Fact]
        public void AtomicClientException_IsException()
        {
            // Arrange & Act
            var exception = new AtomicClientException("Test");

            // Assert
            Assert.IsAssignableFrom<Exception>(exception);
        }
    }
}
