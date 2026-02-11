using SUS.Atomic.Base.Interfaces;
using SUS.AtomicAssets.Client;
using Xunit;

namespace SUS.Atomic.Tests.Extensions
{
    /// <summary>
    /// Tests for extension methods.
    /// </summary>
    public class ExtensionMethodsTests
    {
        private class TestLimitable : ILimitable<TestLimitable>, SUS.Atomic.Base.Interfaces.IQueryable
        {
            private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();

            public void AddQuery(string name, string value)
            {
                _queries[name] = value;
            }

            public void AddMultiArgQuery(string name, List<string> values)
            {
                _queries[name] = string.Join(",", values);
            }

            public string GetURI()
            {
                return "test?" + string.Join("&", _queries.Select(q => $"{q.Key}={q.Value}"));
            }

            public string GetQueryValue(string key)
            {
                return _queries.TryGetValue(key, out var value) ? value : string.Empty;
            }
        }

        private class TestOrderable : IOrderable<TestOrderable>, SUS.Atomic.Base.Interfaces.IQueryable
        {
            private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();

            public void AddQuery(string name, string value)
            {
                _queries[name] = value;
            }

            public void AddMultiArgQuery(string name, List<string> values)
            {
                _queries[name] = string.Join(",", values);
            }

            public string GetURI()
            {
                return "test?" + string.Join("&", _queries.Select(q => $"{q.Key}={q.Value}"));
            }

            public string GetQueryValue(string key)
            {
                return _queries.TryGetValue(key, out var value) ? value : string.Empty;
            }
        }

        private class TestPageable : IPageable<TestPageable>, SUS.Atomic.Base.Interfaces.IQueryable
        {
            private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();

            public void AddQuery(string name, string value)
            {
                _queries[name] = value;
            }

            public void AddMultiArgQuery(string name, List<string> values)
            {
                _queries[name] = string.Join(",", values);
            }

            public string GetURI()
            {
                return "test?" + string.Join("&", _queries.Select(q => $"{q.Key}={q.Value}"));
            }

            public string GetQueryValue(string key)
            {
                return _queries.TryGetValue(key, out var value) ? value : string.Empty;
            }
        }

        [Fact]
        public void Limit_SetsLimitParameter()
        {
            // Arrange
            var limitable = new TestLimitable();

            // Act
            var result = limitable.Limit(50);

            // Assert
            Assert.Equal("50", result.GetQueryValue("limit"));
        }

        [Fact]
        public void Order_Ascending_SetsOrderToAsc()
        {
            // Arrange
            var orderable = new TestOrderable();

            // Act
            var result = orderable.Order(ascending: true);

            // Assert
            Assert.Equal("asc", result.GetQueryValue("order"));
        }

        [Fact]
        public void Order_Descending_SetsOrderToDesc()
        {
            // Arrange
            var orderable = new TestOrderable();

            // Act
            var result = orderable.Order(ascending: false);

            // Assert
            Assert.Equal("desc", result.GetQueryValue("order"));
        }

        [Fact]
        public void Page_SetsPageParameter()
        {
            // Arrange
            var pageable = new TestPageable();

            // Act
            var result = pageable.Page(3);

            // Assert
            Assert.Equal("3", result.GetQueryValue("page"));
        }

        [Fact]
        public void Limit_ReturnsFluentInterface()
        {
            // Arrange
            var limitable = new TestLimitable();

            // Act
            var result = limitable.Limit(10);

            // Assert
            Assert.Same(limitable, result);
        }

        [Fact]
        public void Order_ReturnsFluentInterface()
        {
            // Arrange
            var orderable = new TestOrderable();

            // Act
            var result = orderable.Order(true);

            // Assert
            Assert.Same(orderable, result);
        }

        [Fact]
        public void Page_ReturnsFluentInterface()
        {
            // Arrange
            var pageable = new TestPageable();

            // Act
            var result = pageable.Page(1);

            // Assert
            Assert.Same(pageable, result);
        }
    }
}
