namespace Connector.App.v1.CompCode;

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
public class CompCodeDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("ID of the company to which the Comp Code belongs")]
    [Required]
    public required string CompanyId { get; init; }

    [JsonPropertyName("short_name")]
    [Description("Short Name of the Comp Code")]
    [Required]
    public string ShortName { get; init; } = string.Empty;

    [JsonPropertyName("state_code")]
    [Description("State Code for the Comp Code")]
    [Required]
    public string StateCode { get; init; } = string.Empty;

    [JsonPropertyName("class_code")]
    [Description("Class Code for the Comp Code")]
    [Required]
    public string ClassCode { get; init; } = string.Empty;

    [JsonPropertyName("work_description")]
    [Description("Work Description for the Comp Code")]
    [Nullable(true)]
    public string WorkDescription { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    [Description("Description for the Comp Code")]
    [Nullable(true)]
    public string? Description { get; init; }

    [JsonPropertyName("risk_rate")]
    [Description("Risk Rate for the particular Comp Code")]
    [Nullable(true)]
    public float? RiskRate { get; init; }

    [JsonPropertyName("work_year")]
    [Description("Work Year for the Comp Code")]
    [Nullable(true)]
    public int? WorkYear { get; init; }

    [JsonPropertyName("active")]
    [Description("Is the Comp Code active?")]
    [Required]
    public bool Active { get; init; } = true;

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; }
}
