namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;
using System.Collections.Generic;

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
public class EmployeesDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("source_system")]
    [Description("Source system of the employee data")]
    [Nullable(true)]
    public string? SourceSystem { get; init; }

    [JsonPropertyName("source_system_id")]
    [Description("Identifier from the source system")]
    [Nullable(true)]
    public string? SourceSystemId { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Company ID")]
    [Required]
    public required string CompanyId { get; init; }

    [JsonPropertyName("user")]
    [Description("User details")]
    [Required]
    public required UserData User { get; init; }

    [JsonPropertyName("employee_id")]
    [Description("Employee ID")]
    [Nullable(true)]
    public string? EmployeeId { get; init; }

    [JsonPropertyName("company_user_type")]
    [Description("Company user type")]
    [Required]
    public required string CompanyUserType { get; init; }

    [JsonPropertyName("employment_type")]
    [Description("Employment type")]
    [Required]
    public required string EmploymentType { get; init; }

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
    public required string UserStatus { get; init; }

    [JsonPropertyName("start_date")]
    [Description("Start date of employment")]
    [Nullable(true)]
    public required DateTime? StartDate { get; init; }

    [JsonPropertyName("end_date")]
    [Description("End date of employment")]
    [Nullable(true)]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("department")]
    [Description("Department")]
    [Nullable(true)]
    public string? Department { get; init; }

    [JsonPropertyName("branch")]
    [Description("Branch")]
    [Nullable(true)]
    public string? Branch { get; init; }

    [JsonPropertyName("comp_code")]
    [Description("Comp Code")]
    [Nullable(true)]
    public string? CompCode { get; init; }

    [JsonPropertyName("compensation_type")]
    [Description("Compensation Type")]
    [Nullable(true)]
    public string? CompensationType { get; init; }

    [JsonPropertyName("pay_rate")]
    [Description("Pay Rate")]
    [Nullable(true)]
    [WriteOnly]
    public double? PayRate { get; init; }

    [JsonPropertyName("pay_frequency")]
    [Description("Pay Frequency")]
    [Nullable(true)]
    [WriteOnly]
    public string? PayFrequency { get; init; }
    
    [JsonPropertyName("user_benefits")]
    [Description("List of user benefits")]
    [Nullable(true)]
    public List<UserBenefit>? UserBenefits { get; set; } = new List<UserBenefit>();

    [JsonPropertyName("bank_accounts")]
    [Description("List of bank accounts")]
    [Nullable(true)]
    public List<BankAccount>? BankAccounts { get; set; } = new List<BankAccount>();

    [JsonPropertyName("user_pay_rates")]
    [Description("List of user pay rates")]
    [Nullable(true)]
    public List<UserPayRate>? UserPayRates { get; set; } = new List<UserPayRate>();

    [JsonPropertyName("user_tax_with_holdings")]
    [Description("List of user tax with holdings")]
    [Nullable(true)]
    public List<UserTaxWithHolding>? UserTaxWithHoldings { get; set; } = new List<UserTaxWithHolding>();

    [JsonPropertyName("user_leave_balance")]
    [Description("User leave balance")]
    [Nullable(true)]
    public UserLeaveBalance? UserLeaveBalance { get; set; }

    [JsonPropertyName("active")]
    [Description("Is the employee active?")]
    [Required]
    public required bool Active { get; init; }
    
    [JsonPropertyName("payroll_enabled")]
    [Description("Is the employee payroll enable?")]
    [Required]
    public required bool PayrollEnabled { get; init; }

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
    public DateTime? WorkStartDate { get; init; }

    [JsonPropertyName("rehire_date")]
    [Description("Rehire Date of the user")]
    [Nullable(true)]
    public DateTime? RehireDate { get; init; }

    [JsonPropertyName("rehire_enable")]
    [Description("Rehire Enable of the user")]
    [Nullable(true)]
    public bool RehireEnable { get; init; } = true;

    [JsonPropertyName("hiring_status")]
    [Description("Hiring Status of the user")]
    [Nullable(true)]
    public string? HiringStatus { get; init; }
}

public class UserData
{
    [JsonPropertyName("first_name")]
    [Description("First name of the Employee")]
    [Required]
    [WriteOnly]
    public required string FirstName { get; init; }

    [JsonPropertyName("middle_name")]
    [Description("Middle name of the Employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? MiddleName { get; init; }

    [JsonPropertyName("last_name")]
    [Description("Last name of the Employee")]
    [Required]
    [WriteOnly]
    public required string LastName { get; init; }

    [JsonPropertyName("gender")]
    [Description("Gender of the Employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? Gender { get; init; }

    [JsonPropertyName("date_of_birth")]
    [Description("Date of Birth of the Employee")]
    [Nullable(true)]
    [WriteOnly]
    public DateTime? DateOfBirth { get; init; }

    [JsonPropertyName("phone")]
    [Description("Phone number of the Employee")]
    [Required]
    [WriteOnly]
    public required string? Phone { get; init; }

    [JsonPropertyName("email")]
    [Description("Email address of the Employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? Email { get; init; }

    [JsonPropertyName("address")]
    [Description("Address details of the Employee")]
    [Nullable(true)]
    public AddressData? Address { get; init; }

    [JsonPropertyName("user_type")]
    [Description("User type")]
    [Nullable(true)]
    public string? UserType { get; init; }

    [JsonPropertyName("short_ssn")]
    [Description("Short SSN")]
    [Nullable(true)]
    [WriteOnly]
    public string? ShortSsn { get; init; }

    [JsonPropertyName("ssn")]
    [Description("SSN")]
    [Nullable(true)]
    [WriteOnly] 
    public string? Ssn { get; init; }

    [JsonPropertyName("job_title")]
    [Description("Job title")]
    [Nullable(true)]
    [WriteOnly]
    public string? JobTitle { get; init; }

    [JsonPropertyName("secondary_email")]
    [Description("Secondary Email of the user")]
    [Nullable(true)]
    [WriteOnly]
    public string? SecondaryEmail { get; init; }

    [JsonPropertyName("emergency_contact_name")]
    [Description("Emergency Contact Name of the user")]
    [Nullable(true)]
    public string? EmergencyContactName { get; init; }

    [JsonPropertyName("emergency_contact_phone")]
    [Description("Emergency Contact Phone of the user")]
    [Nullable(true)]
    public string? EmergencyContactPhone { get; init; }

    [JsonPropertyName("emergency_contact_relation")]
    [Description("Emergency Contact Relation of the user")]
    [Nullable(true)]
    public string? EmergencyContactRelation { get; init; }

    [JsonPropertyName("veteran_status")]
    [Description("Veteran Status of the user")]
    [Nullable(true)]
    public string? VeteranStatus { get; init; }

    [JsonPropertyName("disability_status")]
    [Description("Disability Status of the user")]
    [Nullable(true)]
    public string? DisabilityStatus { get; init; }

    [JsonPropertyName("birth_place_address")]
    [Description("Birth Place Address of the user")]
    [Nullable(true)]
    public string? BirthPlaceAddress { get; init; }

    [JsonPropertyName("minority")]
    [Description("Minority of the user")]
    [Nullable(true)]
    public string? Minority { get; init; }

    [JsonPropertyName("marital_status")]
    [Description("Marital Status of the user")]
    [Nullable(true)]
    public string? MaritalStatus { get; init; }

    [JsonPropertyName("ethnicity")]
    [Description("Ethnicity of the user")]
    [Nullable(true)]
    public string? Ethnicity { get; init; }

    [JsonPropertyName("driver_license")]
    [Description("Driver License of the user")]
    [Nullable(true)]
    [WriteOnly]
    public string? DriverLicense { get; init; }
}

public class AddressData
{
    [JsonPropertyName("street_line1")]
    [Description("Street address line 1")]
    [Nullable(true)]
    [WriteOnly] 
    public string? StreetLine1 { get; init; }

    [JsonPropertyName("street_line2")]
    [Description("Street address line 2")]
    [Nullable(true)]
    [WriteOnly] 
    public string? StreetLine2 { get; init; }

    [JsonPropertyName("city")]
    [Description("City name")]
    [Nullable(true)]
    [WriteOnly] 
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("State or region")]
    [Nullable(true)]
    [WriteOnly] 
    public string? State { get; init; }

    [JsonPropertyName("country")]
    [Description("Country code")]
    public string? Country { get; init; }

    [JsonPropertyName("postal_code")]
    [Description("Postal code")]
    public string? PostalCode { get; init; }

    [JsonPropertyName("latitude")]
    [Description("Latitude coordinate")]
    [Nullable(true)]
    public double? Latitude { get; init; }

    [JsonPropertyName("longitude")]
    [Description("Longitude coordinate")]
    [Nullable(true)]
    public double? Longitude { get; init; }
}
