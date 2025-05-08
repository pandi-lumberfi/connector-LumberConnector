namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class UserPayRate
{
    [JsonPropertyName("id")]
    [Description("Id of the pay rate")]
    [Nullable(true)]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    [Description("Name of the pay rate")]
    [Nullable(true)]
    public string? Name { get; set; } = string.Empty;

    [JsonPropertyName("effective_start")]
    [Description("Effective start date")]
    [Nullable(true)]
    public DateTime? EffectiveStart { get; set; }

    [JsonPropertyName("effective_end")]
    [Description("Effective end date")]
    [Nullable(true)]
    public DateTime? EffectiveEnd { get; set; }

    [JsonPropertyName("compensation_type")]
    [Description("Compensation type")]
    [Nullable(true)]
    public string? CompensationType { get; set; } = string.Empty;

    [JsonPropertyName("state")] 
    [Description("State")]
    [Nullable(true)]
    public string? State { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    [Description("City")]
    [Nullable(true)]
    public string? City { get; set; } = string.Empty;

    [JsonPropertyName("standard_time_pay_rate")]
    [Description("Standard time pay rate")]
    [Nullable(true)]
    public double? StandardTimePayRate { get; set; }

    [JsonPropertyName("overtime_pay_rate")]
    [Description("Overtime pay rate")]
    [Nullable(true)]
    public double? OvertimePayRate { get; set; }

    [JsonPropertyName("double_overtime_pay_rate")]
    [Description("Double overtime pay rate")]
    [Nullable(true)]
    public double? DoubleOvertimePayRate { get; set; }

    [JsonPropertyName("travel_pay_rate")]
    [Description("Travel pay rate")]
    [Nullable(true)]
    public double? TravelPayRate { get; set; }

    [JsonPropertyName("active")]
    [Description("Active")]
    [Nullable(true)]
    public bool? Active { get; set; }
    
}