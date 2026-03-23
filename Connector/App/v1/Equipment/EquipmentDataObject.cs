namespace Connector.App.v1.Equipment;

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
public class EquipmentDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Identifier for the company")]
    [Nullable(true)]
    public string? CompanyId { get; set; }

    [JsonPropertyName("company_name")]
    [Description("Name of the company")]
    [Nullable(true)]
    public string? CompanyName { get; set; }

    [JsonPropertyName("equipment_code")]
    [Description("Code for the equipment")]
    [Nullable(true)]
    public string? EquipmentCode { get; set; }

    [JsonPropertyName("equipment_name")]
    [Description("Name of the equipment")]
    [Nullable(true)]
    public string? EquipmentName { get; set; }

    [JsonPropertyName("model")]
    [Description("Model of the equipment")]
    [Nullable(true)]
    public string? Model { get; set; }

    [JsonPropertyName("make")]
    [Description("Make of the equipment")]
    [Nullable(true)]
    public string? Make { get; set; }

    [JsonPropertyName("make_id")]
    [Description("Identifier for the make")]
    [Nullable(true)]
    public string? MakeId { get; set; }

    [JsonPropertyName("class_code")]
    [Description("Code for the class")]
    [Nullable(true)]
    public string? ClassCode { get; set; }

    [JsonPropertyName("equipment_class_code_id")]
    [Description("Identifier for the equipment class code")]
    [Nullable(true)]
    public string? EquipmentClassCodeId { get; set; }
    [JsonPropertyName("status")]
    [Description("Status of the equipment")]
    [Nullable(true)]
    public string? Status { get; set; }

    [JsonPropertyName("category")]
    [Description("Category of the equipment")]
    [Nullable(true)]
    public string? Category { get; set; }   

    [JsonPropertyName("category_id")]
    [Description("Identifier for the category")]
    [Nullable(true)]
    public string? CategoryId { get; set; }

    [JsonPropertyName("hour_meter")]
    [Description("Hour meter of the equipment")]
    [Nullable(true)]
    public double? HourMeter { get; set; }

    [JsonPropertyName("unit_of_usage")]
    [Description("Unit of usage of the equipment")]
    [Nullable(true)]
    public string? UnitOfUsage { get; set; }

    [JsonPropertyName("last_service_date")]
    [Description("Last service date of the equipment")]
    [Nullable(true)]
    public string? LastServiceDate { get; set; }

    [JsonPropertyName("source_system_links")]
    [Description("Source system links of the equipment")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; } = new List<SourceSystemLink>();

}