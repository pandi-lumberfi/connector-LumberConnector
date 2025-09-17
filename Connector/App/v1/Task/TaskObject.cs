namespace Connector.App.v1.Task;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

public class TaskObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public string? Id { get; init; }

    [JsonPropertyName("name")]
    [Description("Name of the task")]
    [Required]
    public string? Name { get; init; }
    
    [JsonPropertyName("description")]
    [Description("Description of the task")]
    [Nullable(true)]
    public string? Description { get; init; }

    [JsonPropertyName("project_id")]
    [Description("Project ID")]
    [Required]
    public string? ProjectId { get; init; } 

    [JsonPropertyName("job_code_id")]
    [Description("Job code ID")]
    [Nullable(true)]
    public string? JobCodeId { get; init; } 

    [JsonPropertyName("comp_code_id")]
    [Description("Comp code ID")]
    [Nullable(true)]
    public string? CompCodeId { get; init; }    

    [JsonPropertyName("cost_code_id")]
    [Description("Cost code ID")]
    [Nullable(true)]
    public string? CostCodeId { get; init; }

    [JsonPropertyName("task_code")]
    [Description("Task code")]
    [Required]
    public string? TaskCode { get; init; }

    [JsonPropertyName("status")]    
    [Description("Status of the task")]
    [Required]
    public string? Status { get; init; }

    [JsonPropertyName("allow_placed_task_on_weekend")]
    [Description("Flag indicating if the task can be placed on the weekend")]
    [Nullable(true)]
    public bool? AllowPlacedTaskOnWeekend { get; init; } = false;

    [JsonPropertyName("planned_start_date")]
    [Description("Planned start date of the task")]
    [Nullable(true)]
    public string? PlannedStartDate { get; init; }

    [JsonPropertyName("planned_end_date")]
    [Description("Planned end date of the task")]
    [Nullable(true)]
    public string? PlannedEndDate { get; init; }   

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; }       
}