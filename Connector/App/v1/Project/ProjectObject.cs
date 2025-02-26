namespace Connector.App.v1.Project;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
public class ProjectObject
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public string? Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Id of the company to which the Project belongs")]
    [Required]
    public string? CompanyId { get; set; }

    [JsonPropertyName("project_name")]
    [Description("Name of the project")]
    [Required]
    public string? ProjectName { get; set; }

    [JsonPropertyName("project_code")]
    [Description("Code for the project")]
    [Nullable(true)]
    public string? ProjectCode { get; set; }

    [JsonPropertyName("project_number")]
    [Description("Project Number")]
    [Nullable(true)]
    public string? ProjectNumber { get; set; }

    [JsonPropertyName("address")]
    [Description("Address of the project")]
    [Nullable(true)]
    public Address? Address { get; set; }

    [JsonPropertyName("description")]
    [Description("Description of the project")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("budget")]
    [Description("Budget of the project")]
    [Nullable(true)]
    public double? Budget { get; set; }

    [JsonPropertyName("start_date")]
    [Description("Start date of the project")]
    [Nullable(true)]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    [Description("End date of the project")]
    [Nullable(true)]
    public string? EndDate { get; set; }

    [JsonPropertyName("status")]
    [Description("Status of the project")]
    [Nullable(true)]
    public string? Status { get; set; }

    [JsonPropertyName("prevailing_wage_project")]
    [Description("Is prevailing wage project?")]
    public bool? PrevailingWageProject { get; set; } = false;

    [JsonPropertyName("contract_type")]
    [Description("Type of project contract")]
    [Nullable(true)]
    public string? ContractType { get; set; }

    [JsonPropertyName("active")]
    [Description("Is project active?")]
    [Required]
    public bool Active { get; set; } = true;

    [JsonPropertyName("allow_only_assigned_crews")]
    [Description("Is allow only assigned crew to clock in")]
    [Required]
    public bool AllowOnlyAssignedCrews { get; set; } = false;
}