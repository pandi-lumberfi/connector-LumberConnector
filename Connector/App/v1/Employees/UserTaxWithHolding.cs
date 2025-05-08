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

    [JsonPropertyName("tax_code")]
    [Description("Tax code")]
    [Nullable(true)]
    public string? TaxCode { get; set; } = string.Empty;

    [JsonPropertyName("subjectToTax")]
    [Description("Taxable")]
    [Nullable(true)]
    public string? SubjectToTax { get; set; } = string.Empty;
    
    [JsonPropertyName("fica")]
    [Description("FICA")]
    [Nullable(true)]
    public string? Fica { get; set; } = string.Empty;

    [JsonPropertyName("fica_value")]
    [Description("FICA value")]
    [Nullable(true)]
    public string? FicaValue { get; set; } = string.Empty;

    [JsonPropertyName("medicare")]
    [Description("Medicare")]
    [Nullable(true)]
    public string? Medicare { get; set; } = string.Empty;    

    [JsonPropertyName("medicare_value")]
    [Description("Medicare value")]
    [Nullable(true)]
    public string? MedicareValue { get; set; } = string.Empty;           
    
    [JsonPropertyName("income_tax")]    
    [Description("Income tax")]
    [Nullable(true)]
    public string? IncomeTax { get; set; } = string.Empty;

    [JsonPropertyName("income_tax_value")]  
    [Description("Income tax value")]   
    [Nullable(true)]
    public string? IncomeTaxValue { get; set; } = string.Empty;

    [JsonPropertyName("insurance")]
    [Description("Insurance")]
    [Nullable(true)]  
    public string? Insurance { get; set; } = string.Empty;

    [JsonPropertyName("unemployment_tax")]
    [Description("Unemployment tax")]
    [Nullable(true)]
    public string? UnemploymentTax { get; set; } = string.Empty;

    [JsonPropertyName("unemployment_tax_value")]
    [Description("Unemployment tax value")]
    [Nullable(true)]
    public string? UnemploymentTaxValue { get; set; } = string.Empty;
    
    [JsonPropertyName("filing_status")]
    [Description("Filing status")]
    [Nullable(true)]
    public string? FilingStatus { get; set; } = string.Empty;
    
    [JsonPropertyName("tax_override")]
    [Description("Tax override")]
    [Nullable(true)]
    public string? TaxOverride { get; set; } = string.Empty;
    
    [JsonPropertyName("tax_override_type")]
    [Description("Tax override type")]
    [Nullable(true)]
    public string? TaxOverrideType { get; set; } = string.Empty;
    
    [JsonPropertyName("tax_override_value")]
    [Description("Tax override value")]
    [Nullable(true)]
    public string? TaxOverrideValue { get; set; } = string.Empty;    
}              