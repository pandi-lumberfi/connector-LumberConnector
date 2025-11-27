namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class Union
{
    [JsonPropertyName("id")]
    [Description("ID of the union")]
    [Required]
    public string? Id { get; set; }

    [JsonPropertyName("union_name")]
    [Description("Name of the union")]
    [Nullable(true)]
    public string? UnionName { get; set; } 
    
    [JsonPropertyName("union_code")]
    [Description("Code of the union")]
    [Nullable(true)]
    public string? UnionCode { get; set; }

    [JsonPropertyName("active")]
    [Description("Is the union active?")]
    [Nullable(true)]
    public bool? Active { get; set; }

}