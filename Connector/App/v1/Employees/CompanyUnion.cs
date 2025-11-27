namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class CompanyUnion
{
    [JsonPropertyName("id")]
    [Description("ID of the company union")]
    [Required]
    public string Id { get; set; } = string.Empty;


    [JsonPropertyName("union_name")]
    [Description("Name of the union")]
    public string UnionName { get; set; } = string.Empty;   

    [JsonPropertyName("union_code")]
    [Description("Code of the union")]
    public string UnionCode { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    [Description("Is the union active?")]
    public bool Active { get; set; } = true;
}