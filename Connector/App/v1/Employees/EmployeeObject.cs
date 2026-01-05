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

    [JsonPropertyName("source_system")]
    [Description("Source system of the employee data")]
    [Nullable(true)]
    public string? SourceSystem { get; init; }

    [JsonPropertyName("source_system_id")]
    [Description("Identifier from the source system")]
    [Nullable(true)]
    private string? SourceSystemId { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Company ID")]
    [Required]
    public string? CompanyId { get; init; }

    [JsonPropertyName("user")]
    [Description("User details")]
    public User? User { get; init; } = new User();

    [JsonPropertyName("employee_code")]
    [Description("Employee Code")]
    [Nullable(true)]
    public string? EmployeeCode { get; init; }

    [JsonPropertyName("company_user_type")]
    [Description("Company user type")]
    [Nullable(true)]
    public string? CompanyUserType { get; init; } = "WORKER";

    [JsonPropertyName("employment_type")]
    [Description("Employment type")]
    [Nullable(true)]
    public string? EmploymentType { get; init; } = "EMPLOYEE";

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
    public string UserStatus { get; init; } = "ENABLED";

    [JsonPropertyName("start_date")]
    [Description("Start date of employment")]
    [Nullable(true)]
    public string? StartDate { get; init; }

    [JsonPropertyName("end_date")]
    [Description("End date of employment")]
    [Nullable(true)]
    public string? EndDate { get; init; }

    [JsonPropertyName("active")]
    [Description("Is the employee active?")]
    [Required]
    public bool Active { get; init; } = true;

    [JsonPropertyName("payroll_enabled")]
    [Description("Is the employee payroll enable?")]
    [Required]
    public bool PayrollEnabled { get; init; } = true;

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; }

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

    [JsonPropertyName("compensation_type")]
    [Description("Compensation Type")]
    [Nullable(true)]
    public string? CompensationType { get; init; }

    [JsonPropertyName("pay_rate")]
    [Description("Pay Rate")]
    [Nullable(true)]
    [WriteOnly]
    public string? PayRate { get; init; }

    [JsonPropertyName("pay_frequency")]
    [Description("Pay Frequency")]
    [Nullable(true)]
    public string? PayFrequency { get; init; }

    [JsonPropertyName("department")]
    [Description("Department")]
    [Nullable(true)]
    public Department? Department { get; init; }

    [JsonPropertyName("job_classification")]
    [Description("Job Classification")]
    [Nullable(true)]
    public JobClassification? JobClassification { get; init; }

    [JsonPropertyName("job_level")]
    [Description("Job Level")]
    [Nullable(true)]
    public JobLevel? JobLevel { get; init; }

    [JsonPropertyName("union")]
    [Description("Union details")]
    [Nullable(true)]
    public Union? Union { get; init; }

    [JsonPropertyName("employee_class")]
    [Description("Employee Class")]
    [Nullable(true)]
    public EmployeeClass? EmployeeClass { get; init; }

    [JsonPropertyName("comp_codes")]
    [Description("Comp Code")]
    [Nullable(true)]
    public List<CompCode>? CompCodes { get; init; }

    [JsonPropertyName("job_codes")]
    [Description("Job Code")]
    [Nullable(true)]
    public List<JobCode>? JobCodes { get; init; }

    [JsonPropertyName("workplaces")]
    [Description("Workplace")]
    [Nullable(true)]
    public List<Workplace>? Workplaces { get; init; }
}

public class User
{
    [JsonPropertyName("first_name")]
    [Description("First name of the Employee")]
    [Required]
    public string? FirstName { get; init; }

    [JsonPropertyName("middle_name")]
    [Description("Middle name of the Employee")]
    [Nullable(true)]
    public string? MiddleName { get; init; }

    [JsonPropertyName("last_name")]
    [Description("Last name of the Employee")]
    [Required]
    public string? LastName { get; init; }

    [JsonPropertyName("gender")]
    [Description("Gender of the Employee")]
    [Nullable(true)]
    [WriteOnly]
    public string? Gender { get; init; }

    [JsonPropertyName("date_of_birth")]
    [Description("Date of Birth of the Employee")]
    [Required]
    [WriteOnly]
    public string? DateOfBirth { get; init; }

    [JsonPropertyName("phone")]
    [Description("Phone number of the Employee")]
    [Required]
    [WriteOnly]
    public string? Phone { get; init; }

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
    [Required]
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
    [WriteOnly]
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
    [WriteOnly] 
    public string? Ethnicity { get; init; }

    [JsonPropertyName("driver_license")]
    [Description("Driver License of the user")]
    [Nullable(true)]
    [WriteOnly] 
    public string? DriverLicense { get; init; }
}

public class Address
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
    [Nullable(true)]
    public string? Country { get; init; }

    [JsonPropertyName("postal_code")]
    [Description("Postal code")]
    [Nullable(true)]
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