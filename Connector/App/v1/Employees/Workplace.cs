namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class Workplace
{
    [JsonPropertyName("id")]
    [Description("ID of the workplace")]
    [Required]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("workplace_name")]
    [Description("Name of the workplace")]
    [Nullable(true)]
    public string? WorkplaceName { get; set; } = string.Empty;

    [JsonPropertyName("headquarters")]
    [Description("Is the workplace the headquarter?")]
    [Nullable(true)]
    public bool? Headquarters { get; set; } = false;
}