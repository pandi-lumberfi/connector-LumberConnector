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
    [Nullable(true)]
    public string? CompanyId { get; set; }

    [JsonPropertyName("employee_id")]
    [Description("Identifier for the employee")]
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
    public DateTime? DateWorked { get; set; }

    [JsonPropertyName("scheduled_start_time")]
    [Description("Scheduled start time for the work")]
    [Nullable(true)]
    public DateTimeOffset? ScheduledStartTime { get; set; }

    [JsonPropertyName("scheduled_end_time")]
    [Description("Scheduled end time for the work")]
    [Nullable(true)]
    public DateTimeOffset? ScheduledEndTime { get; set; }

    [JsonPropertyName("actual_start_time")]
    [Description("Actual start time for the work")]
    [Nullable(true)]
    public DateTimeOffset? ActualStartTime { get; set; }

    [JsonPropertyName("actual_end_time")]
    [Description("Actual end time for the work")]
    [Nullable(true)]
    public DateTimeOffset? ActualEndTime { get; set; }

    [JsonPropertyName("total_work_duration")]
    [Description("Total duration of work")]
    [Nullable(true)]
    public string? TotalWorkDuration { get; set; }

    [JsonPropertyName("regular_work_duration")]
    [Description("Duration of regular work")]
    [Nullable(true)]
    public string? RegularWorkDuration { get; set; }

    [JsonPropertyName("overtime_duration")]
    [Description("Duration of overtime work")]
    [Nullable(true)]
    public string? OvertimeDuration { get; set; }

    [JsonPropertyName("double_overtime_duration")]
    [Description("Duration of double overtime work")]
    [Nullable(true)]
    public string? DoubleOvertimeDuration { get; set; }

    [JsonPropertyName("meal_break_duration")]
    [Description("Duration of meal break")]
    [Nullable(true)]
    public string? MealBreakDuration { get; set; }

    [JsonPropertyName("break_duration")]
    [Description("Total duration of breaks")]
    [Nullable(true)]
    public string? BreakDuration { get; set; }

    [JsonPropertyName("paid_break_duration")]
    [Description("Duration of paid breaks")]
    [Nullable(true)]
    public string? PaidBreakDuration { get; set; }

    [JsonPropertyName("unpaid_break_duration")]
    [Description("Duration of unpaid breaks")]
    [Nullable(true)]
    public string? UnpaidBreakDuration { get; set; }

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
    public string? TravelDuration { get; set; }

    [JsonPropertyName("clockin_geofencing_distance")]
    [Description("Distance from geofence when clocking in")]
    [Nullable(true)]
    public string? ClockinGeofencingDistance { get; set; }

    [JsonPropertyName("clockout_geofencing_distance")]
    [Description("Distance from geofence when clocking out")]
    [Nullable(true)]
    public string? ClockoutGeofencingDistance { get; set; }

    [JsonPropertyName("project_geofencing_distance")]
    [Description("Distance from project geofence")]
    [Nullable(true)]
    public string? ProjectGeofencingDistance { get; set; }

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

    [JsonPropertyName("lodging")]
    [Description("Indicates if lodging applies")]
    [Nullable(true)]
    public bool? Lodging { get; set; }

    [JsonPropertyName("injury")]
    [Description("Indicates if injury occurred")]
    [Nullable(true)]
    public bool? Injury { get; set; }

    [JsonPropertyName("has_signature")]
    [Description("Indicates if signature is present")]
    [Nullable(true)]
    public bool? HasSignature { get; set; }

    [JsonPropertyName("has_face_id")]
    [Description("Indicates if face ID is present")]
    [Nullable(true)]
    public bool? HasFaceId { get; set; }

    [JsonPropertyName("has_flagged_face_id")]
    [Description("Indicates if flagged face ID is present")]
    [Nullable(true)]
    public bool? HasFlaggedFaceId { get; set; }

    [JsonPropertyName("processed")]
    [Description("Indicates if the entry has been processed")]
    [Nullable(true)]
    public bool? Processed { get; set; }

    [JsonPropertyName("has_notes")]
    [Description("Indicates if notes are present")]
    [Nullable(true)]
    public bool? HasNotes { get; set; }

    [JsonPropertyName("note_files_count")]
    [Description("Count of note files")]
    [Nullable(true)]
    public int? NoteFilesCount { get; set; }

    [JsonPropertyName("created_mode")]
    [Description("Mode in which the entry was created")]
    [Nullable(true)]
    public string? CreatedMode { get; set; }

    [JsonPropertyName("created_on")]
    [Description("Timestamp when the timesheet entry was created")]
    [Nullable(true)]
    public DateTimeOffset? CreatedOn { get; set; }

    [JsonPropertyName("modified_on")]
    [Description("Timestamp when the timesheet entry was last modified")]
    [Nullable(true)]
    public DateTimeOffset? ModifiedOn { get; set; }
}