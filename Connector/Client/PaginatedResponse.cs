using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Connector.Client
{
    // Update this class to match the JSON response from the API.
    public class PaginatedResponse<TResult>
    {
        [JsonPropertyName("page")]
        public int Page { get; init; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; init; }

        [JsonPropertyName("total_records")]
        public int TotalRecords { get; init; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; init; }

        [JsonPropertyName("data")]
        public IEnumerable<TResult> Items { get; init; } = Array.Empty<TResult>();
    }
}