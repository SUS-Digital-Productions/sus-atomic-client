using SUS.Atomic.Base.Interfaces;
using System;
using System.Collections.Generic;

namespace SUS.Atomic.Base
{
    /// <summary>
    /// Base class for all Atomic API endpoint implementations.
    /// Provides query parameter management and URI generation.
    /// </summary>
    public abstract class BaseEndpoint : IQueryable
    {
        /// <summary>
        /// The base endpoint URL.
        /// </summary>
        protected string _endpoint;

        /// <summary>
        /// Collection of query parameters to be appended to the endpoint URL.
        /// </summary>
        protected Dictionary<string, string> queryPairs = new Dictionary<string, string>();

        /// <summary>
        /// Adds a multi-value query parameter by joining the values with commas.
        /// </summary>
        /// <param name="name">The name of the query parameter.</param>
        /// <param name="values">The list of values to be joined.</param>
        public void AddMultiArgQuery(string name, List<string> values)
        {
            string value = string.Join(",", values);
            AddQuery(name, value);
        }

        /// <summary>
        /// Adds a single query parameter.
        /// </summary>
        /// <param name="name">The name of the query parameter.</param>
        /// <param name="value">The value of the query parameter.</param>
        public void AddQuery(string name, string value)
        {
            queryPairs.Add(name, value);
        }

        /// <summary>
        /// Generates the complete URI with all query parameters.
        /// </summary>
        /// <returns>The complete URI string.</returns>
        public string GetURI()
        {
            string query = string.Empty;
            query = "?";
            foreach (var pair in queryPairs)
            {
                query += $"{pair.Key}={pair.Value}&";
            }
            query = query.Remove(query.Length - 1);
            if (string.IsNullOrEmpty(query))
                return _endpoint;
            var endpoint = _endpoint + query;
            return endpoint;
        }
    }
}