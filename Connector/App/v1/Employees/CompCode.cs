namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class CompCode
{

    [JsonPropertyName("id")]
    [Description("ID of the comp code")]
    [Required]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("short_name")]
    [Description("Short name of the comp code")]
    [Nullable(true)]
    public string? ShortName { get; set; } = string.Empty;

    [JsonPropertyName("state_code")]
    [Description("State code of the comp code")]
    [Nullable(true)]
    public string? StateCode { get; set; } = string.Empty;
    
    [JsonPropertyName("class_code")]
    [Description("Class code of the comp code")]
    [Nullable(true)]
    public string? ClassCode { get; set; } = string.Empty;

    [JsonPropertyName("work_description")]
    [Description("Work description of the comp code")]
    [Nullable(true)]
    public string? WorkDescription { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    [Description("Description of the comp code")]
    [Nullable(true)]
    public string? Description { get; set; } = string.Empty;

    [JsonPropertyName("risk_rate")]
    [Description("Risk rate of the comp code")]
    [Nullable(true)]
    public double? RiskRate { get; set; } = 0;
    
    [JsonPropertyName("work_year")]
    [Description("Work year of the comp code")]
    [Nullable(true)]
    public int? WorkYear { get; set; } = 2025;

    [JsonPropertyName("code")]
    [Description("Code of the comp code")]
    [Nullable(true)]
    public string? Code { get; set; } = string.Empty;

    [JsonPropertyName("cost_code_name")]
    [Description("Cost code name of the comp code")]
    [Nullable(true)]
    public string? CostCodeName { get; set; } = string.Empty;
    [JsonPropertyName("cost_code_description")]
    [Description("Cost code description of the comp code")]
    [Nullable(true)]
    public string? CostCodeDescription { get; set; } = string.Empty;

    [JsonPropertyName("comp_code_id")]
    [Description("Comp code ID of the comp code")]
    [Nullable(true)]
    public string? CompCodeId { get; set; } = string.Empty;

    [JsonPropertyName("comp_code_class_code")]
    [Description("Comp code class code of the comp code")]
    [Nullable(true)]
    public string? CompCodeClassCode { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    [Description("Is the comp code active?")]
    [Nullable(true)]
    public bool? Active { get; set; } = true;
}