namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class JobCode
{

    [JsonPropertyName("id")]
    [Description("ID of the job code")]
    [Required]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    [Description("Name of the job code")]
    [Nullable(true)]
    public string? Name { get; set; } = string.Empty;

    [JsonPropertyName("code")]
    [Description("Code of the job code")]
    [Nullable(true)]
    public string? Code { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    [Description("Description of the job code")]
    [Nullable(true)]
    public string? Description { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    [Description("Is the job code active?")]
    [Nullable(true)]
    public bool? Active { get; set; } = true;

    
}