namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class UserBenefit
{
    [JsonPropertyName("name")]
    [Description("Name of the benefit")]
    [Required]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("benefit_type")]
    [Description("Type of the benefit")]
    [Required]
    public string BenefitType { get; set; } = string.Empty;

    [JsonPropertyName("period")]
    [Description("Period of the benefit")]
    [Nullable(true)]
    public string? Period { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    [Description("Description of the benefit")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("effective_start")]
    [Description("Effective start date of the benefit")]
    [Required]
    public string? EffectiveStart { get; set; } = string.Empty;

    [JsonPropertyName("effective_end")]
    [Description("Effective end date of the benefit")]
    [Nullable(true)]
    public string? EffectiveEnd { get; set; } = string.Empty;

    [JsonPropertyName("company_contribution")]
    [Description("Company contribution")]
    [Nullable(true)]
    public double? CompanyContribution { get; set; }

    [JsonPropertyName("employee_contribution")]
    [Description("Employee contribution")]
    [Nullable(true)]
    public double? EmployeeContribution { get; set; }

    [JsonPropertyName("contribution_type")]
    [Description("Type of contribution")]
    [Nullable(true)]
    public string? ContributionType { get; set; }
}
             