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

    [JsonPropertyName("employee_id")]
    [Description("Employee ID")]
    [Nullable(true)]
    public string? EmployeeId { get; init; }

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
    public string? Gender { get; init; }

    [JsonPropertyName("date_of_birth")]
    [Description("Date of Birth of the Employee")]
    [Required]
    public string? DateOfBirth { get; init; }

    [JsonPropertyName("phone")]
    [Description("Phone number of the Employee")]
    [Required]
    public string? Phone { get; init; }

    [JsonPropertyName("email")]
    [Description("Email address of the Employee")]
    [Nullable(true)]
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
    public string? ShortSsn { get; init; }

    [JsonPropertyName("job_title")]
    [Description("Job title")]
    [Required]
    public string? JobTitle { get; init; }
}

public class Address
{
    [JsonPropertyName("street_line1")]
    [Description("Street address line 1")]
    [Nullable(true)]
    public string? StreetLine1 { get; init; }

    [JsonPropertyName("street_line2")]
    [Description("Street address line 2")]
    [Nullable(true)]
    public string? StreetLine2 { get; init; }

    [JsonPropertyName("city")]
    [Description("City name")]
    [Nullable(true)]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("State or region")]
    [Nullable(true)]
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