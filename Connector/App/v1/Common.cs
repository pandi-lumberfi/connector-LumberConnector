using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;

public class SourceSystemLink
{
    [JsonPropertyName("source_system")]
    [Description("Source system")]
    [Required]
    public required string SourceSystem { get; init; }

    [JsonPropertyName("source_system_id")]
    [Description("Source system ID")]
    [Required]
    public required string SourceSystemId { get; init; }

    [JsonPropertyName("secondary_source_system_id")]
    [Description("Secondary source system ID")]
    [Nullable(true)]
    public string? SecondarySourceSystemId { get; init; }
}