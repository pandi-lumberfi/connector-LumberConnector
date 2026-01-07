namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

public class EmployeeObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public string? Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Company ID")]
    [Nullable(true)]
    public string? CompanyId { get; init; }

    [JsonPropertyName("user")]
    [Description("User details")]
    [Nullable(true)]
    public UserData? User { get; init; }

    [JsonPropertyName("employee_code")]
    [Description("Employee Code")]
    [Nullable(true)]
    public string? EmployeeCode { get; init; }

    [JsonPropertyName("employee_type")]
    [Description("Employee type")]
    [Nullable(true)]
    public string? EmployeeType { get; init; }

    [JsonPropertyName("employment_type")]
    [Description("Employment type")]
    [Nullable(true)]
    public string? EmploymentType { get; init; }

    [JsonPropertyName("contract_employee_type")]
    [Description("Contract Employee Type")]
    [Nullable(true)]
    public string? ContractEmployeeType { get; init; }

    [JsonPropertyName("contract_employee_business_name")]
    [Description("Business name of the contract employee")]
    [Nullable(true)]
    public string? ContractEmployeeBusinessName { get; init; }

    [JsonPropertyName("user_status")]
    [Description("Current status of the user")]
    [Required]
    public string? UserStatus { get; init; }

    [JsonPropertyName("start_date")]
    [Description("Start date of employment")]
    [Nullable(true)]
    public string? StartDate { get; init; }

    [JsonPropertyName("end_date")]
    [Description("End date of employment")]
    [Nullable(true)]
    public string? EndDate { get; init; }

    [JsonPropertyName("department_id")]
    [Description("Department ID")]
    [Nullable(true)]
    public string? DepartmentId { get; set; }

    [JsonPropertyName("department_code")]
    [Description("Department Code")]
    [Nullable(true)]
    public string? DepartmentCode { get; set; }

    [JsonPropertyName("branch_id")]
    [Description("Branch ID")]
    [Nullable(true)]
    public string? BranchId { get; set; }

    [JsonPropertyName("branch_code")]
    [Description("Branch code")]
    [Nullable(true)]
    public string? BranchCode { get; set; }

    [JsonPropertyName("employee_class_id")]
    [Description("Employee Class ID")]
    [Nullable(true)]
    public string? EmployeeClassId { get; set; }

    [JsonPropertyName("employee_class_code")]
    [Description("Employee Class Code")]
    [Nullable(true)]
    public string? EmployeeClassCode { get; set; }

    [JsonPropertyName("job_classification_id")]
    [Description("Job Classification ID")]
    [Nullable(true)]
    public string? JobClassificationId { get; set; }

    [JsonPropertyName("job_classification_code")]
    [Description("Job Classification Code")]
    [Nullable(true)]
    public string? JobClassificationCode { get; set; }

    [JsonPropertyName("compensation_type")]
    [Description("Compensation Type")]
    [Nullable(true)]
    public string? CompensationType { get; init; }

    [JsonPropertyName("pay_rate")]
    [Description("Pay Rate")]
    [Nullable(true)]
    public string? PayRate { get; init; }

    [JsonPropertyName("pay_frequency")]
    [Description("Pay Frequency")]
    [Nullable(true)]
    public string? PayFrequency { get; init; }
    
    [JsonPropertyName("active")]
    [Description("Is the employee active?")]
    [Required]
    public bool? Active { get; init; }
    
    [JsonPropertyName("payroll_enabled")]
    [Description("Is the employee payroll enable?")]
    [Required]
    public bool? PayrollEnabled { get; init; }

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; } = new List<SourceSystemLink>();

    [JsonPropertyName("secondary_employee_id")]
    [Description("Secondary Employee Id of the user")]
    [Nullable(true)]
    public string? SecondaryEmployeeId { get; init; }

    [JsonPropertyName("employment_category")]
    [Description("Employment Category of the user")]
    [Nullable(true)]
    public string? EmploymentCategory { get; init; }

    [JsonPropertyName("work_start_date")]
    [Description("Work Start Date of the user")]
    [Nullable(true)]
    public string? WorkStartDate { get; init; }

    [JsonPropertyName("rehire_date")]
    [Description("Rehire Date of the user")]
    [Nullable(true)]
    public string? RehireDate { get; init; }

    [JsonPropertyName("rehire_enable")]
    [Description("Rehire Enable of the user")]
    [Nullable(true)]
    public bool? RehireEnable { get; init; } = true;

    [JsonPropertyName("hiring_status")]
    [Description("Hiring Status of the user")]
    [Nullable(true)]
    public string? HiringStatus { get; init; }
}