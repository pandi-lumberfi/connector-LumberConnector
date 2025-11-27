namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class JobClassification
{
    [JsonPropertyName("id")]
    [Description("ID of the job classification")]
    [Required]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    [Description("Name of the job classification")]
    [Nullable(true)]
    public string? Name { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    [Description("Description of the job classification")]
    [Nullable(true)]
    public string? Description { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    [Description("Is the job classification active?")]
    [Nullable(true)]
    public bool? Active { get; set; } = true;

    [JsonPropertyName("alternate_name")]
    [Description("Alternate name of the job classification")]
    [Nullable(true)]
    public string? AlternateName { get; set; } = string.Empty;
}