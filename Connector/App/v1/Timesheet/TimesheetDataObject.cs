namespace Connector.App.v1.Timesheet;

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
public class TimesheetDataObject
{
    [JsonPropertyName("id")]
    [Description("Unique identifier for the timesheet entry")]
    public required Guid Id { get; set; }

    [JsonPropertyName("company_id")]
    [Description("Identifier for the company")]
    public string? CompanyId { get; set; }

    [JsonPropertyName("employee_id")]
    [Description("Identifier for the employee")]
    public string? EmployeeId { get; set; }

    [JsonPropertyName("employee_code")]
    [Description("Code for the employee")]
    public string? EmployeeCode { get; set; }

    [JsonPropertyName("department_id")]
    [Description("Identifier for the department")]
    public string? DepartmentId { get; set; }

    [JsonPropertyName("department_code")]
    [Description("Code for the department")]
    public string? DepartmentCode { get; set; }

    [JsonPropertyName("project_group_id")]
    [Description("Identifier for the project group")]
    public string? ProjectGroupId { get; set; }

    [JsonPropertyName("project_group_code")]
    [Description("Code for the project group")]
    public string? ProjectGroupCode { get; set; }

    [JsonPropertyName("project_id")]
    [Description("Identifier for the project")]
    public string? ProjectId { get; set; }

    [JsonPropertyName("project_code")]
    [Description("Code for the project")]
    public string? ProjectCode { get; set; }

    [JsonPropertyName("project_type")]
    [Description("Type of project")]
    public string? ProjectType { get; set; }

    [JsonPropertyName("sub_project_id")]
    [Description("Identifier for the sub-project")]
    public string? SubProjectId { get; set; }

    [JsonPropertyName("sub_project_name")]
    [Description("Name of the sub-project")]
    public string? SubProjectName { get; set; }

    [JsonPropertyName("task_id")]
    [Description("Identifier for the task")]
    public string? TaskId { get; set; }

    [JsonPropertyName("task_code")]
    [Description("Code for the task")]
    public string? TaskCode { get; set; }

    [JsonPropertyName("cost_code_id")]
    [Description("Identifier for the cost code")]
    public string? CostCodeId { get; set; }

    [JsonPropertyName("cost_code_code")]
    [Description("Code for the cost code")]
    public string? CostCodeCode { get; set; }

    [JsonPropertyName("cost_type_id")]
    [Description("Identifier for the cost type")]
    public string? CostTypeId { get; set; }

    [JsonPropertyName("cost_type_name")]
    [Description("Name of the cost type")]
    public string? CostTypeName { get; set; }

    [JsonPropertyName("service_order_type_id")]
    [Description("Identifier for the service order type")]
    public string? ServiceOrderTypeId { get; set; }

    [JsonPropertyName("service_order_type_code")]
    [Description("Code for the service order type")]
    public string? ServiceOrderTypeCode { get; set; }

    [JsonPropertyName("service_order_id")]
    [Description("Identifier for the service order")]
    public string? ServiceOrderId { get; set; }

    [JsonPropertyName("service_order_code")]
    [Description("Code for the service order")]
    public string? ServiceOrderCode { get; set; }

    [JsonPropertyName("appointment_id")]
    [Description("Identifier for the appointment")]
    public string? AppointmentId { get; set; }

    [JsonPropertyName("appointment_code")]
    [Description("Code for the appointment")]
    public string? AppointmentCode { get; set; }

    [JsonPropertyName("equipment_id")]
    [Description("Identifier for the equipment")]
    public string? EquipmentId { get; set; }

    [JsonPropertyName("equipment_code")]
    [Description("Code for the equipment")]
    public string? EquipmentCode { get; set; }

    [JsonPropertyName("inventory_item_id")]
    [Description("Identifier for the inventory item")]
    public string? InventoryItemId { get; set; }

    [JsonPropertyName("inventory_item_code")]
    [Description("Code for the inventory item")]
    public string? InventoryItemCode { get; set; }

    [JsonPropertyName("worker_comp_code_id")]
    [Description("Identifier for the worker compensation code")]
    public string? WorkerCompCodeId { get; set; }

    [JsonPropertyName("worker_comp_code_code")]
    [Description("Code for the worker compensation code")]
    public string? WorkerCompCodeCode { get; set; }

    [JsonPropertyName("job_code_id")]
    [Description("Identifier for the job code")]
    public string? JobCodeId { get; set; }

    [JsonPropertyName("job_code_code")]
    [Description("Code for the job code")]
    public string? JobCodeCode { get; set; }

    [JsonPropertyName("job_level_id")]
    [Description("Identifier for the job level")]
    public string? JobLevelId { get; set; }

    [JsonPropertyName("job_level_name")]
    [Description("Name of the job level")]
    public string? JobLevelName { get; set; }

    [JsonPropertyName("classification_id")]
    [Description("Identifier for the classification")]
    public string? ClassificationId { get; set; }

    [JsonPropertyName("classification_name")]
    [Description("Name of the classification")]
    public string? ClassificationName { get; set; }

    [JsonPropertyName("shift_id")]
    [Description("Identifier for the shift")]
    public string? ShiftId { get; set; }

    [JsonPropertyName("shift_name")]
    [Description("Name of the shift")]
    public string? ShiftName { get; set; }

    [JsonPropertyName("date_worked")]
    [Description("Date when work was performed")]
    public DateTime? DateWorked { get; set; }

    [JsonPropertyName("scheduled_start_time")]
    [Description("Scheduled start time for the work")]
    public DateTimeOffset? ScheduledStartTime { get; set; }

    [JsonPropertyName("scheduled_end_time")]
    [Description("Scheduled end time for the work")]
    public DateTimeOffset? ScheduledEndTime { get; set; }

    [JsonPropertyName("actual_start_time")]
    [Description("Actual start time for the work")]
    public DateTimeOffset? ActualStartTime { get; set; }

    [JsonPropertyName("actual_end_time")]
    [Description("Actual end time for the work")]
    public DateTimeOffset? ActualEndTime { get; set; }

    [JsonPropertyName("total_work_duration")]
    [Description("Total duration of work")]
    public decimal? TotalWorkDuration { get; set; }

    [JsonPropertyName("regular_work_duration")]
    [Description("Duration of regular work")]
    public decimal? RegularWorkDuration { get; set; }

    [JsonPropertyName("overtime_duration")]
    [Description("Duration of overtime work")]
    public decimal? OvertimeDuration { get; set; }

    [JsonPropertyName("double_overtime_duration")]
    [Description("Duration of double overtime work")]
    public decimal? DoubleOvertimeDuration { get; set; }

    [JsonPropertyName("meal_break_duration")]
    [Description("Duration of meal break")]
    public decimal? MealBreakDuration { get; set; }

    [JsonPropertyName("break_duration")]
    [Description("Total duration of breaks")]
    public decimal? BreakDuration { get; set; }

    [JsonPropertyName("paid_break_duration")]
    [Description("Duration of paid breaks")]
    public decimal? PaidBreakDuration { get; set; }

    [JsonPropertyName("unpaid_break_duration")]
    [Description("Duration of unpaid breaks")]
    public decimal? UnpaidBreakDuration { get; set; }

    [JsonPropertyName("travelled")]
    [Description("Indicates if travel occurred")]
    public bool? Travelled { get; set; }

    [JsonPropertyName("miles_travelled")]
    [Description("Number of miles travelled")]
    public decimal? MilesTravelled { get; set; }

    [JsonPropertyName("travel_duration")]
    [Description("Duration of travel time")]
    public decimal? TravelDuration { get; set; }

    [JsonPropertyName("clockin_geofencing_distance")]
    [Description("Distance from geofence when clocking in")]
    public decimal? ClockinGeofencingDistance { get; set; }

    [JsonPropertyName("clockout_geofencing_distance")]
    [Description("Distance from geofence when clocking out")]
    public decimal? ClockoutGeofencingDistance { get; set; }

    [JsonPropertyName("project_geofencing_distance")]
    [Description("Distance from project geofence")]
    public decimal? ProjectGeofencingDistance { get; set; }

    [JsonPropertyName("status")]
    [Description("Status of the timesheet entry")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    [Description("Type of timesheet entry")]
    public string? Type { get; set; }

    [JsonPropertyName("per_diem")]
    [Description("Indicates if per diem applies")]
    public bool? PerDiem { get; set; }

    [JsonPropertyName("lodging")]
    [Description("Indicates if lodging applies")]
    public bool? Lodging { get; set; }

    [JsonPropertyName("injury")]
    [Description("Indicates if injury occurred")]
    public bool? Injury { get; set; }

    [JsonPropertyName("has_signature")]
    [Description("Indicates if signature is present")]
    public bool? HasSignature { get; set; }

    [JsonPropertyName("has_face_id")]
    [Description("Indicates if face ID is present")]
    public bool? HasFaceId { get; set; }

    [JsonPropertyName("has_flagged_face_id")]
    [Description("Indicates if flagged face ID is present")]
    public bool? HasFlaggedFaceId { get; set; }

    [JsonPropertyName("processed")]
    [Description("Indicates if the entry has been processed")]
    public bool? Processed { get; set; }

    [JsonPropertyName("has_notes")]
    [Description("Indicates if notes are present")]
    public bool? HasNotes { get; set; }

    [JsonPropertyName("note_files_count")]
    [Description("Count of note files")]
    public int? NoteFilesCount { get; set; }

    [JsonPropertyName("created_mode")]
    [Description("Mode in which the entry was created")]
    public string? CreatedMode { get; set; }

    [JsonPropertyName("created_on")]
    [Description("Timestamp when the timesheet entry was created")]
    public DateTimeOffset? CreatedOn { get; set; }

    [JsonPropertyName("modified_on")]
    [Description("Timestamp when the timesheet entry was last modified")]
    public DateTimeOffset? ModifiedOn { get; set; }
}