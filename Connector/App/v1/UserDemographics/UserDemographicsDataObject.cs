namespace Connector.App.v1.UserDemographics;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;
using Connector.App.v1.Employees;

/// <summary>
/// Data object that will represent an object in the Xchange system. This will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[PrimaryKey("id", nameof(Id))]
[Description("User demographics data object representing employee information.")]
public class UserDemographicsDataObject
{
    [JsonPropertyName("id")]
    [Description("Primary key of the object")]
    [Nullable(true)]
    public Guid? Id { get; init; }

    [JsonPropertyName("first_name")]
    [Description("First name of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? FirstName { get; init; }

    [JsonPropertyName("middle_name")]
    [Description("Middle name of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? MiddleName { get; init; }

    [JsonPropertyName("last_name")]
    [Description("Last name of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? LastName { get; init; }

    [JsonPropertyName("gender")]
    [Description("Gender of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? Gender { get; init; }

    [JsonPropertyName("job_title")]
    [Description("Job title of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? JobTitle { get; init; }

    [JsonPropertyName("user_status")]
    [Description("Current status of the user")]
    [Nullable(true)]
    public string? UserStatus { get; init; }

    [JsonPropertyName("hiring_status")]
    [Description("Hiring status of the employee")]
    [Nullable(true)]
    public string? HiringStatus { get; init; }

    [JsonPropertyName("ethnicity")]
    [Description("Ethnicity of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? Ethnicity { get; init; }

    [JsonPropertyName("race")]
    [Description("Race of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? Race { get; init; }

    [JsonPropertyName("eeoc_job_classification_type")]
    [Description("EEOC job classification type")]
    [Nullable(true)]
    [WriteOnly]
    public string? EeocJobClassificationType { get; init; }

    [JsonPropertyName("veteran_status")]
    [Description("Veteran status of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? VeteranStatus { get; init; }

    [JsonPropertyName("disability_status")]
    [Description("Disability status of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? DisabilityStatus { get; init; }

    [JsonPropertyName("active")]
    [Description("Whether the employee is active")]
    [Nullable(true)]
    public bool? Active { get; init; }

    [JsonPropertyName("payroll_enabled")]
    [Description("Whether payroll is enabled for the employee")]
    [Nullable(true)]
    public bool? PayrollEnabled { get; init; }

    [JsonPropertyName("date_of_birth")]
    [Description("Date of birth of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? DateOfBirth { get; init; }

    [JsonPropertyName("hire_date")]
    [Description("Hire date of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? HireDate { get; init; }

    [JsonPropertyName("start_date")]
    [Description("Start date of the employee")]
    [Nullable(true)]
    public string? StartDate { get; init; }

    [JsonPropertyName("rehire_date")]
    [Description("Rehire date of the employee")]
    [Nullable(true)]
    public string? RehireDate { get; init; }

    [JsonPropertyName("termination_date")]
    [Description("Termination date of the employee")]
    [Nullable(true)]
    public string? TerminationDate { get; init; }

    [JsonPropertyName("employee_code")]
    [Description("Employee code")]
    [Nullable(true)]
    public string? EmployeeCode { get; init; }

    [JsonPropertyName("lumber_role")]
    [Description("Lumber role/company user type")]
    [Nullable(true)]
    public string? LumberRole { get; init; }

    [JsonPropertyName("marital_status")]
    [Description("Marital status of the employee")]
    [Nullable(true)]
    public string? MaritalStatus { get; init; }

    [JsonPropertyName("employment_type")]
    [Description("Employment type")]
    [Nullable(true)]
    [WriteOnly]
    public string? EmploymentType { get; init; }

    [JsonPropertyName("employment_category")]
    [Description("Employment category")]
    [Nullable(true)]
    public string? EmploymentCategory { get; init; }

    [JsonPropertyName("email")]
    [Description("Email address of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? Email { get; init; }

    [JsonPropertyName("phone_number")]
    [Description("Phone number of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("address")]
    [Description("Address of the employee")]
    [Nullable(true)]
    public string? Address { get; init; }

    [JsonPropertyName("workplaces")]
    [Description("Workplaces of the employee")]
    [Nullable(true)]
    public string? Workplaces { get; init; }

    [JsonPropertyName("emergency_contact_name")]
    [Description("Emergency contact name")]
    [Nullable(true)]
    public string? EmergencyContactName { get; init; }

    [JsonPropertyName("emergency_contact_phone_number")]
    [Description("Emergency contact phone number")]
    [Nullable(true)]
    [WriteOnly]
    public string? EmergencyContactPhoneNumber { get; init; }

    [JsonPropertyName("emergency_contact_relation")]
    [Description("Emergency contact relation")]
    [Nullable(true)]
    [WriteOnly]
    public string? EmergencyContactRelation { get; init; }

    [JsonPropertyName("primary_workplace")]
    [Description("Primary workplace")]
    [Nullable(true)]
    [WriteOnly]
    public string? PrimaryWorkplace { get; init; }

    [JsonPropertyName("department")]
    [Description("Department of the employee")]
    [Nullable(true)]
    public string? Department { get; init; }

    [JsonPropertyName("branch")]
    [Description("Branch of the employee")]
    [Nullable(true)]
    public string? Branch { get; init; }

    [JsonPropertyName("employee_class")]
    [Description("Employee class")]
    [Nullable(true)]
    public string? EmployeeClass { get; init; }

    [JsonPropertyName("short_ssn")]
    [Description("Short SSN")]
    [Nullable(true)]
    [WriteOnly]
    public string? ShortSsn { get; init; }

    [JsonPropertyName("compensation_type")]
    [Description("Compensation type")]
    [Nullable(true)]
    public string? CompensationType { get; init; }

    [JsonPropertyName("pay_frequency")]
    [Description("Pay frequency")]
    [Nullable(true)]
    public string? PayFrequency { get; init; }

    [JsonPropertyName("is_non_overtime_employee")]
    [Description("Whether the employee is non-overtime")]
    [Nullable(true)]
    public bool? IsNonOvertimeEmployee { get; init; }

    [JsonPropertyName("is_auto_assign_workplace_by_state")]
    [Description("Whether to auto-assign workplace by state")]
    [Nullable(true)]
    public bool? IsAutoAssignWorkplaceByState { get; init; }

    [JsonPropertyName("pay_rate_effective_from")]
    [Description("Pay rate effective from")]
    [Nullable(true)]
    public string? PayRateEffectiveFrom { get; init; }

    [JsonPropertyName("pay_rate_effective_end")]
    [Description("Pay rate effective end")]
    [Nullable(true)]
    public string? PayRateEffectiveEnd { get; init; }

    [JsonPropertyName("base_pay_rate")]
    [Description("Base pay rate")]
    [Nullable(true)]
    public double? BasePayRate { get; init; }

    [JsonPropertyName("overtime_pay_rate")]
    [Description("Overtime pay rate")]
    [Nullable(true)]
    [WriteOnly]
    public double? OvertimePayRate { get; init; }

    [JsonPropertyName("double_overtime_pay_rate")]
    [Description("Double overtime pay rate")]
    [Nullable(true)]
    [WriteOnly]
    public double? DoubleOvertimePayRate { get; init; }

    [JsonPropertyName("additional_compensation_rate")]
    [Description("Additional compensation rate")]
    [Nullable(true)]
    [WriteOnly]
    public double? AdditionalCompensationRate { get; init; }

    [JsonPropertyName("union_name")]
    [Description("Union name")]
    [Nullable(true)]
    public string? UnionName { get; init; }

    [JsonPropertyName("trades")]
    [Description("Trades")]
    [Nullable(true)]
    public string? Trades { get; init; }

    [JsonPropertyName("job_level")]
    [Description("Job level")]
    [Nullable(true)]
    public string? JobLevel { get; init; }

    [JsonPropertyName("job_classification")]
    [Description("Job classification")]
    [Nullable(true)]
    public string? JobClassification { get; init; }

    [JsonPropertyName("bank_accounts")]
    [Description("Bank accounts of the employee")]
    [Nullable(true)]
    [WriteOnly]
    public List<BankAccount>? BankAccounts { get; init; }

    [JsonPropertyName("tax_with_holdings")]
    [Description("Tax withholdings")]
    [Nullable(true)]
    public Dictionary<string, string>? TaxWithHoldings { get; init; }

    [JsonPropertyName("account")]
    [Description("Account")]
    [Nullable(true)]
    [WriteOnly]
    public string? Account { get; init; }

    [JsonPropertyName("sub_account")]
    [Description("Sub account")]
    [Nullable(true)]
    [WriteOnly]
    public string? SubAccount { get; init; }
}