using SUS.Atomic.Base;
using SUS.Atomic.Base.Interfaces;
using Xunit;

namespace SUS.Atomic.Tests.Base
{
    /// <summary>
    /// Tests for BaseEndpoint functionality.
    /// </summary>
    public class BaseEndpointTests
    {
        private class TestEndpoint : BaseEndpoint
        {
            public TestEndpoint(string endpoint)
            {
                _endpoint = endpoint;
            }
        }

        [Fact]
        public void GetURI_WithNoQueryParameters_ReturnsBaseEndpoint()
        {
            // Arrange
            var endpoint = new TestEndpoint("https://api.example.com/v1/assets");

            // Act
            var uri = endpoint.GetURI();

            // Assert
            Assert.Equal("https://api.example.com/v1/assets", uri);
        }

        [Fact]
        public void GetURI_WithSingleQueryParameter_ReturnsCorrectURI()
        {
            // Arrange
            var endpoint = new TestEndpoint("https://api.example.com/v1/assets");
            endpoint.AddQuery("limit", "10");

            // Act
            var uri = endpoint.GetURI();

            // Assert
            Assert.Equal("https://api.example.com/v1/assets?limit=10", uri);
        }

        [Fact]
        public void GetURI_WithMultipleQueryParameters_ReturnsCorrectURI()
        {
            // Arrange
            var endpoint = new TestEndpoint("https://api.example.com/v1/assets");
            endpoint.AddQuery("limit", "10");
            endpoint.AddQuery("page", "1");
            endpoint.AddQuery("owner", "testuser");

            // Act
            var uri = endpoint.GetURI();

            // Assert
            Assert.Contains("limit=10", uri);
            Assert.Contains("page=1", uri);
            Assert.Contains("owner=testuser", uri);
            Assert.StartsWith("https://api.example.com/v1/assets?", uri);
        }

        [Fact]
        public void AddMultiArgQuery_WithMultipleValues_JoinsWithComma()
        {
            // Arrange
            var endpoint = new TestEndpoint("https://api.example.com/v1/assets");
            var values = new List<string> { "value1", "value2", "value3" };

            // Act
            endpoint.AddMultiArgQuery("ids", values);
            var uri = endpoint.GetURI();

            // Assert
            Assert.Contains("ids=value1,value2,value3", uri);
        }

        [Fact]
        public void AddQuery_WithEmptyKey_AddsToQueryPairs()
        {
            // Arrange
            var endpoint = new TestEndpoint("https://api.example.com/v1/assets");

            // Act
            endpoint.AddQuery("key", "");
            var uri = endpoint.GetURI();

            // Assert
            Assert.Contains("key=", uri);
        }
    }
}
