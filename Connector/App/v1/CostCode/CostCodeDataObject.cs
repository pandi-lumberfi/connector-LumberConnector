namespace Connector.App.v1.CostCode;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;

/// <summary>
/// Data object that will represent an object in the Xchange system. This will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[PrimaryKey("id", nameof(Id))]
//[AlternateKey("alt-key-id", nameof(CompanyId), nameof(EquipmentNumber))]
[Description("Example description of the object.")]
public class CostCodeDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("ID of the company associated with the cost code")]
    [Required]
    public required string CompanyId { get; init; }

    [JsonPropertyName("code")]
    [Description("Code of the cost code")]
    [Required]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("cost_code_name")]
    [Description("Name of the cost code")]
    [Required]
    public string CostCodeName { get; init; } = string.Empty;

    [JsonPropertyName("cost_code_description")]
    [Description("Description of the cost code")]
    [Nullable(true)]
    public string? CostCodeDescription { get; init; }

    [JsonPropertyName("active")]
    [Description("Flag indicating if the cost code is active")]
    [Required]
    public bool Active { get; init; }
}
