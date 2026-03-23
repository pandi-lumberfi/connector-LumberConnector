namespace Connector.App.v1.EquipmentTimeEntry;

using Json.Schema.Generation;
using System;
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
public class EquipmentTimeEntryDataObject
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
    
    [JsonPropertyName("equipment_id")]
    [Description("Identifier for the equipment")]
    [Nullable(true)]
    public string? EquipmentId { get; set; }

    [JsonPropertyName("equipment_code")]
    [Description("Code for the equipment")]
    [Nullable(true)]
    public string? EquipmentCode { get; set; }
    
    [JsonPropertyName("equipment_name")]
    [Description("Name of the equipment")]
    [Nullable(true)]
    public string? EquipmentName { get; set; }
    
    [JsonPropertyName("project_id")]
    [Description("Identifier for the project")]
    [Nullable(true)]
    public string? ProjectId { get; set; }

    [JsonPropertyName("project_code")]
    [Description("Code for the project")]
    [Nullable(true)]
    public string? ProjectCode { get; set; }

    [JsonPropertyName("project_name")]
    [Description("Name of the project")]
    [Nullable(true)]
    public string? ProjectName { get; set; }
    
    [JsonPropertyName("project_type")]
    [Description("Type of the project")]
    [Nullable(true)]
    public string? ProjectType { get; set; }

    [JsonPropertyName("project_status")]
    [Description("Status of the project")]
    [Nullable(true)]
    public string? ProjectStatus { get; set; }
    
    [JsonPropertyName("task_id")]
    [Description("Identifier for the task")]
    [Nullable(true)]
    public string? TaskId { get; set; }

    [JsonPropertyName("task_code")]
    [Description("Code for the task")]
    [Nullable(true)]
    public string? TaskCode { get; set; }

    [JsonPropertyName("task_name")]
    [Description("Name of the task")]
    [Nullable(true)]
    public string? TaskName { get; set; }
    
    [JsonPropertyName("date_worked")]
    [Description("Date worked")]
    [Nullable(true)]
    public string? DateWorked { get; set; }

    [JsonPropertyName("start_time")]
    [Description("Start time")]
    [Nullable(true)]
    public string? StartTime { get; set; }
    
    
    [JsonPropertyName("end_time")]
    [Description("End time")]
    [Nullable(true)]
    public string? EndTime { get; set; }

    [JsonPropertyName("work_duration")]
    [Description("Work duration")]
    [Nullable(true)]
    public string? WorkDuration { get; set; }
    
    [JsonPropertyName("work_duration_in_secs")]
    [Description("Work duration in seconds")]
    [Nullable(true)]
    public string? WorkDurationInSecs { get; set; }

    [JsonPropertyName("status")]
    [Description("Status")]
    [Nullable(true)]
    public string? Status { get; set; }
    
    [JsonPropertyName("processed")]
    [Description("Processed")]
    [Nullable(true)]
    public bool? Processed { get; set; }
}