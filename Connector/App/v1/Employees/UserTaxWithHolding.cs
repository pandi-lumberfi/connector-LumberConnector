namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class UserTaxWithHolding
{    
    [JsonPropertyName("company_user_id")]
    [Description("Company user id")]
    [Nullable(true)]
    public string? CompanyUserId { get; set; } = string.Empty;

    [JsonPropertyName("employee_id")]
    [Description("Employee id")]
    [Nullable(true)]
    public string? EmployeeId { get; set; } = string.Empty;

    [JsonPropertyName("jurisdiction")]
    [Description("Jurisdiction")]
    [Nullable(true)]
    public string? Jurisdiction { get; set; } = string.Empty;

    [JsonPropertyName("medicare_tax_exempt")]
    [Description("Medicare tax exempt")]
    [Nullable(true)]
    public bool? MedicareTaxExempt { get; set; } = false;

    [JsonPropertyName("income_tax_exempt")]
    [Description("Income tax exempt")]
    [Nullable(true)]
    public bool? IncomeTaxExempt { get; set; } = false;

    [JsonPropertyName("un_employment_tax_exempt")]
    [Description("Unemployment tax exempt")]
    [Nullable(true)]
    public bool? UnemploymentTaxExempt { get; set; } = false;

    [JsonPropertyName("filing_status")]
    [Description("Filing status")]
    [Nullable(true)]
    public string? FilingStatus { get; set; } = string.Empty;

    [JsonPropertyName("tax_override")]
    [Description("Tax override")]
    [Nullable(true)]
    public double? TaxOverride { get; set; } = 0;

    [JsonPropertyName("tax_override_type")]
    [Description("Tax override type")]
    [Nullable(true)]
    public string? TaxOverrideType { get; set; } = string.Empty;  
}              