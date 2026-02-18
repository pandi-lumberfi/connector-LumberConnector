namespace Connector.App.v1.CostType;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class CostTypeObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public string?  Id { get; init; }

    [JsonPropertyName("company_id")] 
    [Description("ID of the company associated with the cost code")]
    [Required]
    public string? CompanyId { get; init; }

    [JsonPropertyName("name")]
    [Description("Name of the cost type")]
    [Required]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    [Description("Description of the cost type")]
    [Nullable(true)]
    public string? Description { get; init; }

    [JsonPropertyName("active")]
    [Description("Flag indicating if the cost type is active")]
    public bool Active { get; init; } = true;

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; }
}
