namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class EmployeeClass
{
    [JsonPropertyName("id")]
    [Description("ID of the employee class")]
    [Required]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("employee_class_name")]
    [Description("Name of the employee class")]
    [Nullable(true)]
    public string? EmployeeClassName { get; set; } = string.Empty;

    [JsonPropertyName("employee_class_code")]
    [Description("Code of the employee class")]
    [Nullable(true)]
    public string? EmployeeClassCode { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    [Description("Description of the employee class")]
    [Nullable(true)]
    public string? Description { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    [Description("Is the employee class active?")]
    [Nullable(true)]
    public bool? Active { get; set; } = true;
}
