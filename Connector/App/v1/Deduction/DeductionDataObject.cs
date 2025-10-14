namespace Connector.App.v1.Deduction;

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
public class DeductionDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("ID of the company to which the deduction belongs")]
    [Required]
    public required string CompanyId { get; init; }

    [JsonPropertyName("employee_code")]
    [Description("Code of the employee to which the deduction belongs")]
    [Required]
    public required string EmployeeCode { get; init; }

    [JsonPropertyName("deduction_code")]
    [Description("Code of the deduction")]
    [Required]
    public required string DeductionCode { get; init; }

    [JsonPropertyName("deduction_type")]
    [Description("Type of the deduction")]
    [Required]
    public required string DeductionType { get; init; }

    [JsonPropertyName("formula_code")]
    [Description("Code of the formula")]
    [Nullable(true)]
    public string? FormulaCode { get; init; }

    [JsonPropertyName("formula_value")]
    [Description("Value of the formula")]
    [Nullable(true)]
    public string? FormulaValue { get; init; }

    [JsonPropertyName("amount")]
    [Description("Amount of the deduction")]
    [Nullable(true)]
    public double? Amount { get; init; }

    [JsonPropertyName("percentage")]
    [Description("Percentage of the deduction")]
    [Nullable(true)]
    public double? Percentage { get; init; }

    [JsonPropertyName("limit")]
    [Description("Limit of the deduction")]
    [Nullable(true)]
    public double? Limit { get; init; }

    [JsonPropertyName("monthly_limit")]
    [Description("Monthly limit of the deduction")]
    [Nullable(true)]
    public double? MonthlyLimit { get; init; }

    [JsonPropertyName("annual_limit")]
    [Description("Annual limit of the deduction")]
    [Nullable(true)]
    public double? AnnualLimit { get; init; }

    [JsonPropertyName("vendor_code")]
    [Description("Vendor code of the deduction")]
    [Nullable(true)]
    public string? VendorCode { get; init; }

    [JsonPropertyName("remark")]
    [Description("Remark of the deduction")]
    [Nullable(true)]
    public string? Remark { get; init; }

    [JsonPropertyName("uploaded")]
    [Description("Flag indicating if the deduction is uploaded")]
    [Nullable(true)]
    public bool? Uploaded { get; init; }

    [JsonPropertyName("upload_message")]
    [Description("Message of the upload")]
    [Nullable(true)]
    public string? UploadMessage { get; init; }
}