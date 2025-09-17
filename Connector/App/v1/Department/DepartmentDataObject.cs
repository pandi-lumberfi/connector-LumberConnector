namespace Connector.App.v1.Department;

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
public class DepartmentDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("ID of the company associated with the department")]
    [Required]
    public required string CompanyId { get; init; }

    [JsonPropertyName("department_code")]
    [Description("Department code of the department")]
    [Required]
    public required string DepartmentCode { get; init; }

    [JsonPropertyName("department_name")]
    [Description("Name of the department")]
    [Required]
    public required string DepartmentName { get; init; }

    [JsonPropertyName("description")]
    [Description("Description of the department")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("active")]
    [Description("Is department active?")]
    [Required]
    public bool Active { get; set; }

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; }
}
