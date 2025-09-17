namespace Connector.App.v1.CostCode;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class CostCodeObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public string?  Id { get; init; }

    [JsonPropertyName("company_id")] 
    [Description("ID of the company associated with the cost code")]
    [Required]
    public string? CompanyId { get; init; }

    [JsonPropertyName("code")]
    [Description("Code of the cost code")]
    [Required]
    public string? Code { get; init; }

    [JsonPropertyName("cost_code_name")]
    [Description("Name of the cost code")]
    [Required]
    public string? CostCodeName { get; init; } 

    [JsonPropertyName("cost_code_description")]
    [Description("Description of the cost code")]
    [Nullable(true)]
    public string? CostCodeDescription { get; init; }

    [JsonPropertyName("active")]
    [Description("Flag indicating if the cost code is active")]
    public bool Active { get; init; } = true;

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; }
}
