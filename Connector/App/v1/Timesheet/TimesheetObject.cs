namespace Connector.App.v1.Timesheet;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class TimesheetObject
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public string? Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Id of the company to which the Project belongs")]
    [Nullable(true)]
    public string? CompanyId { get; set; }

    [JsonPropertyName("employee_id")]
    [Description("Id of the employee to which the Timesheet belongs")]
    [Nullable(true)]
    public string? EmployeeId { get; set; }

    [JsonPropertyName("employee_code")]
    [Description("Code for the employee")]
    [Nullable(true)]
    public string? EmployeeCode { get; set; }

    [JsonPropertyName("department_id")]
    [Description("Identifier for the department")]
    [Nullable(true)]
    public string? DepartmentId { get; set; }

    [JsonPropertyName("department_code")]
    [Description("Code for the department")]
    [Nullable(true)]
    public string? DepartmentCode { get; set; }

    [JsonPropertyName("project_group_id")]
    [Description("Identifier for the project group")]
    [Nullable(true)]
    public string? ProjectGroupId { get; set; }

    [JsonPropertyName("project_group_code")]
    [Description("Code for the project group")]
    [Nullable(true)]
    public string? ProjectGroupCode { get; set; }

    [JsonPropertyName("project_id")]
    [Description("Identifier for the project")]
    [Nullable(true)]
    public string? ProjectId { get; set; }

    [JsonPropertyName("project_code")]
    [Description("Code for the project")]
    [Nullable(true)]
    public string? ProjectCode { get; set; }

    [JsonPropertyName("project_type")]
    [Description("Type of project")]
    [Nullable(true)]
    public string? ProjectType { get; set; }

    [JsonPropertyName("sub_project_id")]
    [Description("Identifier for the sub-project")]
    [Nullable(true)]
    public string? SubProjectId { get; set; }

    [JsonPropertyName("sub_project_name")]
    [Description("Name of the sub-project")]
    [Nullable(true)]
    public string? SubProjectName { get; set; }

    [JsonPropertyName("task_id")]
    [Description("Identifier for the task")]
    [Nullable(true)]
    public string? TaskId { get; set; }

    [JsonPropertyName("task_code")]
    [Description("Code for the task")]
    [Nullable(true)]
    public string? TaskCode { get; set; }

    [JsonPropertyName("cost_code_id")]
    [Description("Identifier for the cost code")]
    [Nullable(true)]
    public string? CostCodeId { get; set; }

    [JsonPropertyName("cost_code_code")]
    [Description("Code for the cost code")]
    [Nullable(true)]
    public string? CostCodeCode { get; set; }

    [JsonPropertyName("cost_type_id")]
    [Description("Identifier for the cost type")]
    [Nullable(true)]
    public string? CostTypeId { get; set; }

    [JsonPropertyName("cost_type_name")]
    [Description("Name of the cost type")]
    [Nullable(true)]
    public string? CostTypeName { get; set; }

    [JsonPropertyName("service_order_type_id")]
    [Description("Identifier for the service order type")]
    [Nullable(true)]
    public string? ServiceOrderTypeId { get; set; }

    [JsonPropertyName("service_order_type_code")]
    [Description("Code for the service order type")]
    [Nullable(true)]
    public string? ServiceOrderTypeCode { get; set; }

    [JsonPropertyName("service_order_id")]
    [Description("Identifier for the service order")]
    [Nullable(true)]
    public string? ServiceOrderId { get; set; }

    [JsonPropertyName("service_order_code")]
    [Description("Code for the service order")]
    [Nullable(true)]
    public string? ServiceOrderCode { get; set; }

    [JsonPropertyName("appointment_id")]
    [Description("Identifier for the appointment")]
    [Nullable(true)]
    public string? AppointmentId { get; set; }

    [JsonPropertyName("appointment_code")]
    [Description("Code for the appointment")]
    [Nullable(true)]
    public string? AppointmentCode { get; set; }

    [JsonPropertyName("equipment_id")]
    [Description("Identifier for the equipment")]
    [Nullable(true)]
    public string? EquipmentId { get; set; }

    [JsonPropertyName("equipment_code")]
    [Description("Code for the equipment")]
    [Nullable(true)]
    public string? EquipmentCode { get; set; }

    [JsonPropertyName("inventory_item_id")]
    [Description("Identifier for the inventory item")]
    [Nullable(true)]
    public string? InventoryItemId { get; set; }

    [JsonPropertyName("inventory_item_code")]
    [Description("Code for the inventory item")]
    [Nullable(true)]
    public string? InventoryItemCode { get; set; }

    [JsonPropertyName("worker_comp_code_id")]
    [Description("Identifier for the worker compensation code")]
    [Nullable(true)]
    public string? WorkerCompCodeId { get; set; }

    [JsonPropertyName("worker_comp_code_code")]
    [Description("Code for the worker compensation code")]
    [Nullable(true)]
    public string? WorkerCompCodeCode { get; set; }

    [JsonPropertyName("job_code_id")]
    [Description("Identifier for the job code")]
    [Nullable(true)]
    public string? JobCodeId { get; set; }

    [JsonPropertyName("job_code_code")]
    [Description("Code for the job code")]
    [Nullable(true)]
    public string? JobCodeCode { get; set; }

    [JsonPropertyName("job_level_id")]
    [Description("Identifier for the job level")]
    [Nullable(true)]
    public string? JobLevelId { get; set; }

    [JsonPropertyName("job_level_name")]
    [Description("Name of the job level")]
    [Nullable(true)]
    public string? JobLevelName { get; set; }

    [JsonPropertyName("classification_id")]
    [Description("Identifier for the classification")]
    [Nullable(true)]
    public string? ClassificationId { get; set; }

    [JsonPropertyName("classification_name")]
    [Description("Name of the classification")]
    [Nullable(true)]
    public string? ClassificationName { get; set; }

    [JsonPropertyName("shift_id")]
    [Description("Identifier for the shift")]
    [Nullable(true)]
    public string? ShiftId { get; set; }

    [JsonPropertyName("shift_name")]
    [Description("Name of the shift")]
    [Nullable(true)]
    public string? ShiftName { get; set; }

    [JsonPropertyName("date_worked")]
    [Description("Date when work was performed")]
    [Nullable(true)]
    public string? DateWorked { get; set; }

    [JsonPropertyName("scheduled_start_time")]
    [Description("Scheduled start time for the work")]
    [Nullable(true)]
    public string? ScheduledStartTime { get; set; }

    [JsonPropertyName("scheduled_end_time")]
    [Description("Scheduled end time for the work")]
    [Nullable(true)]
    public string? ScheduledEndTime { get; set; }

    [JsonPropertyName("actual_start_time")]
    [Description("Actual start time for the work")]
    [Nullable(true)]
    public string? ActualStartTime { get; set; }

    [JsonPropertyName("actual_end_time")]
    [Description("Actual end time for the work")]
    [Nullable(true)]
    public string? ActualEndTime { get; set; }

    [JsonPropertyName("total_work_duration")]
    [Description("Total duration of work")]
    [Nullable(true)]
    public decimal? TotalWorkDuration { get; set; }

    [JsonPropertyName("regular_work_duration")]
    [Description("Duration of regular work")]
    [Nullable(true)]
    public decimal? RegularWorkDuration { get; set; }

    [JsonPropertyName("overtime_duration")]
    [Description("Duration of overtime work")]
    [Nullable(true)]
    public decimal? OvertimeDuration { get; set; }

    [JsonPropertyName("total_work_duration_in_secs")]
    [Description("Total duration of work in seconds")]
    [Nullable(true)]
    public decimal? TotalWorkDurationInSecs { get; set; }

    [JsonPropertyName("regular_work_duration_in_secs")]
    [Description("Duration of regular work in seconds")]
    [Nullable(true)]
    public decimal? RegularWorkDurationInSecs { get; set; }

    [JsonPropertyName("overtime_duration_in_secs")]
    [Description("Duration of overtime work in seconds")]
    [Nullable(true)]
    public decimal? OvertimeDurationInSecs { get; set; }

    [JsonPropertyName("double_overtime_duration_in_secs")]
    [Description("Duration of double overtime work in seconds")]
    [Nullable(true)]
    public decimal? DoubleOvertimeDurationInSecs { get; set; }

    [JsonPropertyName("break_duration_in_secs")]
    [Description("Duration of break in seconds")]
    [Nullable(true)]
    public decimal? BreakDurationInSecs { get; set; }

    [JsonPropertyName("meal_break_duration_in_secs")]
    [Description("Duration of meal break in seconds")]
    [Nullable(true)]
    public decimal? MealBreakDurationInSecs { get; set; }

    [JsonPropertyName("travel_duration_in_secs")]
    [Description("Duration of travel time in seconds")]
    [Nullable(true)]
    public decimal? TravelDurationInSecs { get; set; }

    [JsonPropertyName("double_overtime_duration")]
    [Description("Duration of double overtime work")]
    [Nullable(true)]
    public decimal? DoubleOvertimeDuration { get; set; }

    [JsonPropertyName("meal_break_duration")]
    [Description("Duration of meal break")]
    [Nullable(true)]
    public decimal? MealBreakDuration { get; set; }

    [JsonPropertyName("break_duration")]
    [Description("Total duration of breaks")]
    [Nullable(true)]
    public decimal? BreakDuration { get; set; }

    [JsonPropertyName("paid_break_duration")]
    [Description("Duration of paid breaks")]
    [Nullable(true)]
    public decimal? PaidBreakDuration { get; set; }

    [JsonPropertyName("unpaid_break_duration")]
    [Description("Duration of unpaid breaks")]
    [Nullable(true)]
    public decimal? UnpaidBreakDuration { get; set; }

    [JsonPropertyName("travelled")]
    [Description("Indicates if travel occurred")]
    [Nullable(true)]
    public bool? Travelled { get; set; }

    [JsonPropertyName("miles_travelled")]
    [Description("Number of miles travelled")]
    [Nullable(true)]
    public decimal? MilesTravelled { get; set; }

    [JsonPropertyName("travel_duration")]
    [Description("Duration of travel time")]
    [Nullable(true)]
    public decimal? TravelDuration { get; set; }

    [JsonPropertyName("status")]
    [Description("Status of the timesheet entry")]
    [Nullable(true)]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    [Description("Type of timesheet entry")]
    [Nullable(true)]
    public string? Type { get; set; }

    [JsonPropertyName("per_diem")]
    [Description("Indicates if per diem applies")]
    [Nullable(true)]
    public bool? PerDiem { get; set; }
}
