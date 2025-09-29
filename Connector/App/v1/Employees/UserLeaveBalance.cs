namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class UserLeaveBalance
{
    [JsonPropertyName("company_user_id")]
    [Description("Company user id")]
    [Nullable(true)]
    public string? CompanyUserId { get; set; } = string.Empty;

    [JsonPropertyName("employee_id")]
    [Description("Employee id")]
    [Nullable(true)]
    public string? EmployeeId { get; set; } = string.Empty;

    [JsonPropertyName("paid_time_off_balance")]
    [Description("Paid time off balance")]
    [Nullable(true)]
    public float PaidTimeOffBalance { get; set; }

    [JsonPropertyName("sick_leave_balance")]
    [Description("Sick leave balance")]
    [Nullable(true)]
    public float SickLeaveBalance { get; set; }

    [JsonPropertyName("other_paid_leave_balance")]
    [Description("Other paid leave balance")]
    [Nullable(true)]
    public float OtherPaidLeaveBalance { get; set; }

    [JsonPropertyName("unpaid_leave_balance")]
    [Description("Unpaid leave balance")]
    [Nullable(true)]
    public float UnpaidLeaveBalance { get; set; }
}