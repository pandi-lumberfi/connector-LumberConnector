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
    [Description("Unique identifier for the timesheet record")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("user_id")]
    [Description("Unique identifier for the user")]
    [Nullable(true)]
    public string? UserId { get; set; }

    [JsonPropertyName("username")]
    [Description("Username/email of the user")]
    [Nullable(true)]
    public string? Username { get; set; }

    [JsonPropertyName("first_name")] 
    [Description("User's first name")]
    [Nullable(true)]
    public string? FirstName { get; set; }

    [JsonPropertyName("middle_name")]
    [Description("User's middle name")]
    [Nullable(true)]
    public string? MiddleName { get; set; }

    [JsonPropertyName("last_name")]
    [Description("User's last name")]
    [Nullable(true)]
    public string? LastName { get; set; }

    [JsonPropertyName("user_active")]
    [Description("Whether the user is active")]
    [Nullable(true)]
    public bool? UserActive { get; set; }

    [JsonPropertyName("phone")]
    [Description("User's phone number")]
    [Nullable(true)]
    public string? Phone { get; set; }

    [JsonPropertyName("email")]
    [Description("User's email address")]
    [Nullable(true)]
    public string? Email { get; set; }

    [JsonPropertyName("employment_type")]
    [Description("Type of employment (e.g. EMPLOYEE)")]
    [Nullable(true)]
    public string? EmploymentType { get; set; }

    [JsonPropertyName("company_user_start_date")]
    [Description("Date when user started with company")]
    [Nullable(true)]
    public string? CompanyUserStartDate { get; set; }

    [JsonPropertyName("company_user_end_date")]
    [Description("Date when user ended with company")]
    [Nullable(true)]
    public string? CompanyUserEndDate { get; set; }

    [JsonPropertyName("base_pay_rate")]
    [Description("Base pay rate for the user")]
    [Nullable(true)]
    public double? BasePayRate { get; set; }

    [JsonPropertyName("date_worked")]
    [Description("Date the work was performed")]
    [Nullable(true)]
    public string? DateWorked { get; set; }

    [JsonPropertyName("clockin_time")]
    [Description("Time user clocked in")]
    [Nullable(true)]
    public string? ClockInTime { get; set; }

    [JsonPropertyName("clockout_time")]
    [Description("Time user clocked out")]
    [Nullable(true)]
    public string? ClockOutTime { get; set; }

    [JsonPropertyName("travelled")]
    [Description("Whether travel was involved")]
    [Nullable(true)]
    public bool? Travelled { get; set; }

    [JsonPropertyName("travel_duration")]
    [Description("Duration of travel in seconds")]
    [Nullable(true)]
    public double? TravelDuration { get; set; }

    [JsonPropertyName("work_duration")]
    [Description("Total duration of work in seconds")]
    [Nullable(true)]
    public double? WorkDuration { get; set; }

    [JsonPropertyName("regular_work_duration")]
    [Description("Duration of regular work hours in seconds")]
    [Nullable(true)]
    public double? RegularWorkDuration { get; set; }

    [JsonPropertyName("overtime_duration")]
    [Description("Duration of overtime in seconds")]
    [Nullable(true)]
    public double? OvertimeDuration { get; set; }

    [JsonPropertyName("double_overtime_duration")]
    [Description("Duration of double overtime in seconds")]
    [Nullable(true)]
    public double? DoubleOvertimeDuration { get; set; }

    [JsonPropertyName("meal_break_duration")]
    [Description("Duration of meal breaks in seconds")]
    [Nullable(true)]
    public double? MealBreakDuration { get; set; }

    [JsonPropertyName("break_duration")]
    [Description("Total duration of breaks in seconds")]
    [Nullable(true)]
    public double? BreakDuration { get; set; }

    [JsonPropertyName("paid_break_duration")]
    [Description("Duration of paid breaks in seconds")]
    [Nullable(true)]
    public double? PaidBreakDuration { get; set; }

    [JsonPropertyName("unpaid_break_duration")]
    [Description("Duration of unpaid breaks in seconds")]
    [Nullable(true)]
    public double? UnpaidBreakDuration { get; set; }

    [JsonPropertyName("miles_travelled")]
    [Description("Miles travelled for work")]
    [Nullable(true)]
    public double? MilesTravelled { get; set; }

    [JsonPropertyName("injury")]
    [Description("Whether an injury occurred")]
    [Nullable(true)]
    public bool? Injury { get; set; }

    [JsonPropertyName("status")]
    [Description("Current status (e.g. CLOCKED_OUT)")]
    [Nullable(true)]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    [Description("Type of timesheet (e.g. REGULAR)")]
    [Nullable(true)]
    public string? Type { get; set; }

    [JsonPropertyName("processed")]
    [Description("Whether timesheet has been processed")]
    [Nullable(true)]
    public bool? Processed { get; set; }

    [JsonPropertyName("project_id")]
    [Description("Unique identifier for the project")]
    [Nullable(true)]
    public string? ProjectId { get; set; }

    [JsonPropertyName("project_name")]
    [Description("Name of the project")]
    [Nullable(true)]
    public string? ProjectName { get; set; }

    [JsonPropertyName("budget")]
    [Description("Project budget")]
    [Nullable(true)]
    public double? Budget { get; set; }

    [JsonPropertyName("project_start_date")]
    [Description("Project start date")]
    [Nullable(true)]
    public string? ProjectStartDate { get; set; }

    [JsonPropertyName("project_end_date")]
    [Description("Project end date")]
    [Nullable(true)]
    public string? ProjectEndDate { get; set; }

    [JsonPropertyName("project_description")]
    [Description("Description of the project")]
    [Nullable(true)]
    public string? ProjectDescription { get; set; }

    [JsonPropertyName("project_active")]
    [Description("Whether project is active")]
    [Nullable(true)]
    public bool? ProjectActive { get; set; }

    [JsonPropertyName("project_code")]
    [Description("Project code identifier")]
    [Nullable(true)]
    public string? ProjectCode { get; set; }

    [JsonPropertyName("company_id")]
    [Description("Unique identifier for the company")]
    [Nullable(true)]
    public string? CompanyId { get; set; }

    [JsonPropertyName("company_legal_name")]
    [Description("Legal name of the company")]
    [Nullable(true)]
    public string? CompanyLegalName { get; set; }

    [JsonPropertyName("company_trade_name")]
    [Description("Trade name of the company")]
    [Nullable(true)]
    public string? CompanyTradeName { get; set; }

    [JsonPropertyName("company_company_name")]
    [Description("Company name")]
    [Nullable(true)]
    public string? CompanyCompanyName { get; set; }

    [JsonPropertyName("has_notes")]
    [Description("Whether timesheet has notes")]
    [Nullable(true)]
    public bool? HasNotes { get; set; }

    [JsonPropertyName("note_files_count")]
    [Description("Number of note files")]
    [Nullable(true)]
    public int? NoteFilesCount { get; set; }

    [JsonPropertyName("create_change_request")]
    [Description("Whether to create change request")]
    [Nullable(true)]
    public bool? CreateChangeRequest { get; set; }

    [JsonPropertyName("created_by_user_id")]
    [Description("ID of user who created the record")]
    [Nullable(true)]
    public string? CreatedByUserId { get; set; }

    [JsonPropertyName("created_by_username")]
    [Description("Username of user who created the record")]
    [Nullable(true)]
    public string? CreatedByUsername { get; set; }

    [JsonPropertyName("modified_by_user_id")]
    [Description("ID of user who last modified the record")]
    [Nullable(true)]
    public string? ModifiedByUserId { get; set; }

    [JsonPropertyName("modified_by_username")]
    [Description("Username of user who last modified the record")]
    [Nullable(true)]
    public string? ModifiedByUsername { get; set; }

    [JsonPropertyName("modified_by_first_name")]
    [Description("First name of user who last modified the record")]
    [Nullable(true)]
    public string? ModifiedByFirstName { get; set; }

    [JsonPropertyName("per_diem")]
    [Description("Whether per diem applies")]
    [Nullable(true)]
    public bool? PerDiem { get; set; }

    [JsonPropertyName("lodging")]
    [Description("Whether lodging is included")]
    [Nullable(true)]
    public bool? Lodging { get; set; }

    [JsonPropertyName("employee_id")]
    [Description("Employee identifier")]
    [Nullable(true)]
    public string? EmployeeId { get; set; }

    [JsonPropertyName("manual_time_card")]
    [Description("Whether timecard was entered manually")]
    [Nullable(true)]
    public bool? ManualTimeCard { get; set; }

    [JsonPropertyName("allocation_done")]
    [Description("Whether allocation is complete")]
    [Nullable(true)]
    public bool? AllocationDone { get; set; }
}