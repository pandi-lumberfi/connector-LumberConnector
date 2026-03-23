namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class LeaveBalance
{
    [JsonPropertyName("company_user_id")]
    [Description("Company user id")]
    [Nullable(true)]
    public string? CompanyUserId { get; set; } = string.Empty;

    [JsonPropertyName("employee_code")]
    [Description("Employee code")]
    [Nullable(true)]
    public string? EmployeeCode { get; set; } = string.Empty;

    [JsonPropertyName("leave_request_id")]
    [Description("Leave request id")]
    [Nullable(true)]
    public string? LeaveRequestId { get; set; } = string.Empty;

    [JsonPropertyName("leave_config_id")]
    [Description("Leave configuration id")]
    [Nullable(true)]
    public string? LeaveConfigId { get; set; } = string.Empty;

    [JsonPropertyName("accounted_leaves")]
    [Description("Accounted leaves")]
    [Nullable(true)]
    public float AccountedLeaves { get; set; }

    [JsonPropertyName("period_start_date")]
    [Description("Period start date")]
    [Nullable(true)]
    public string? PeriodStartDate { get; set; }

    [JsonPropertyName("period_end_date")]
    [Description("Period end date")]
    [Nullable(true)]
    public string? PeriodEndDate { get; set; }

    [JsonPropertyName("leave_accounted_type")]
    [Description("Leave accounted type")]
    [Nullable(true)]
    public string? LeaveAccountedType { get; set; }

    [JsonPropertyName("leave_type")]
    [Description("Leave type")]
    [Nullable(true)]
    public string? LeaveType { get; set; }

    [JsonPropertyName("comments")]
    [Description("Comments")]
    [Nullable(true)]
    public string? Comments { get; set; } = string.Empty;

    [JsonPropertyName("carry_over_expiration_date")]
    [Description("Carry over expiration date")]
    [Nullable(true)]
    public string? CarryOverExpirationDate { get; set; }
}