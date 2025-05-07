namespace Connector.App.v1.Task;

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
public class TaskDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("project_id")]
    [Description("Unique identifier for the project")]
    [Required]
    public required string ProjectId { get; init; }

    [JsonPropertyName("job_code_id")]
    [Description("Unique identifier for the job code")]
    [Nullable(true)]
    public string? JobCodeId { get; init; }

    [JsonPropertyName("comp_code_id")]
    [Description("Unique identifier for the comp code")]
    [Nullable(true)]
    public string? CompCodeId { get; init; }

    [JsonPropertyName("cost_code_id")]
    [Description("Unique identifier for the cost code")]
    [Nullable(true)]
    public string? CostCodeId { get; init; }

    [JsonPropertyName("name")]
    [Description("Name of the task")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("task_code")]
    [Description("Task code")]
    [Required]
    public required string TaskCode { get; init; }

    [JsonPropertyName("description")]
    [Description("Description of the task")]
    [Nullable(true)]
    public string? Description { get; init; }

    [JsonPropertyName("status")]
    [Description("Status of the task")]
    [Required]
    public required string Status { get; init; }

    [JsonPropertyName("allow_placed_task_on_weekend")]
    [Description("Flag indicating if the task can be placed on the weekend")]
    [Nullable(true)]
    public bool? AllowPlacedTaskOnWeekend { get; init; } = false;

    [JsonPropertyName("planned_start_date")]
    [Description("Planned start date of the task")]
    [Nullable(true)]
    public string? PlannedStartDate { get; init; } = string.Empty;

    [JsonPropertyName("planned_end_date")]
    [Description("Planned end date of the task")]
    [Nullable(true)]
    public string? PlannedEndDate { get; init; }

    [JsonPropertyName("planned_start_time")]
    [Description("Planned start time of the task")]
    [Nullable(true)]
    public string? PlannedStartTime { get; init; }

    [JsonPropertyName("planned_end_time")]
    [Description("Planned end time of the task")]
    [Nullable(true)]
    public string? PlannedEndTime { get; init; }

    [JsonPropertyName("actual_end_date_time")]
    [Description("Actual end date and time of the task")]
    [Nullable(true)]
    public string? ActualEndDateTime { get; init; }
}