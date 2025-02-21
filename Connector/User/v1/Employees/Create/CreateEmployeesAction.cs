namespace Connector.User.v1.Employees.Create;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Action object that will represent an action in the Xchange system. This will contain an input object type,
/// an output object type, and a Action failure type (this will default to <see cref="StandardActionFailure"/>
/// but that can be overridden with your own preferred type). These objects will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[Description("CreateEmployeesAction Action description goes here")]
public class CreateEmployeesAction : IStandardAction<CreateEmployeesActionInput, CreateEmployeesActionOutput>
{
    public CreateEmployeesActionInput ActionInput { get; set; } = new();
    public CreateEmployeesActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateEmployeesActionInput
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    public string? Id { get; init; }

    [JsonPropertyName("source_system")]
    [Description("Source system of the employee data")]
    public string? SourceSystem { get; init; }

    [JsonPropertyName("source_system_id")]
    [Description("Identifier from the source system")]
    public string? SourceSystemId { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Company ID")]
    public string? CompanyId { get; init; }

    [JsonPropertyName("user")]
    [Description("User details")]
    public UserData? User { get; init; }

    [JsonPropertyName("employee_id")]
    [Description("Employee ID")]
    public string? EmployeeId { get; init; }

    [JsonPropertyName("company_user_type")]
    [Description("Company user type")]
    public string? CompanyUserType { get; init; }

    [JsonPropertyName("employment_type")]
    [Description("Employment type")]
    public string? EmploymentType { get; init; }

    [JsonPropertyName("contract_employee_type")]
    [Description("Contract Employee Type")]
    public string? ContractEmployeeType { get; init; }

    [JsonPropertyName("contract_employee_business_name")]
    [Description("Business name of the contract employee")]
    public string? ContractEmployeeBusinessName { get; init; }

    [JsonPropertyName("user_status")]
    [Description("Current status of the user")]
    public string? UserStatus { get; init; }

    [JsonPropertyName("start_date")]
    [Description("Start date of employment")]
    public string? StartDate { get; init; }

    [JsonPropertyName("end_date")]
    [Description("End date of employment")]
    public string? EndDate { get; init; }

    [JsonPropertyName("active")]
    [Description("Is the employee active?")]
    public bool Active { get; init; }
}

public class CreateEmployeesActionOutput
{
    
}

public class UserData
{
    [JsonPropertyName("first_name")]
    [Description("First name of the Employee")]
    public string? FirstName { get; init; }

    [JsonPropertyName("middle_name")]
    [Description("Middle name of the Employee")]
    public string? MiddleName { get; init; }

    [JsonPropertyName("last_name")]
    [Description("Last name of the Employee")]
    public string? LastName { get; init; }

    [JsonPropertyName("gender")]
    [Description("Gender of the Employee")]
    public string? Gender { get; init; }

    [JsonPropertyName("date_of_birth")]
    [Description("Date of Birth of the Employee")]
    public string? DateOfBirth { get; init; }

    [JsonPropertyName("phone")]
    [Description("Phone number of the Employee")]
    public string? Phone { get; init; }

    [JsonPropertyName("email")]
    [Description("Email address of the Employee")]
    public string? Email { get; init; }

    [JsonPropertyName("address")]
    [Description("Address details of the Employee")]
    public AddressData? Address { get; init; }

    [JsonPropertyName("user_type")]
    [Description("User type")]
    public string? UserType { get; init; }

    [JsonPropertyName("short_ssn")]
    [Description("Short SSN")]
    public string? ShortSsn { get; init; }

    [JsonPropertyName("job_title")]
    [Description("Job title")]
    public string? JobTitle { get; init; }
}

public class AddressData
{
    [JsonPropertyName("street_line1")]
    [Description("Street address line 1")]
    public string? StreetLine1 { get; init; }

    [JsonPropertyName("street_line2")]
    [Description("Street address line 2")]
    public string? StreetLine2 { get; init; }

    [JsonPropertyName("city")]
    [Description("City name")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("State or region")]
    public string? State { get; init; }

    [JsonPropertyName("country")]
    [Description("Country code")]
    public string? Country { get; init; }

    [JsonPropertyName("postal_code")]
    [Description("Postal code")]
    public string? PostalCode { get; init; }

    [JsonPropertyName("latitude")]
    [Description("Latitude coordinate")]
    public double? Latitude { get; init; }

    [JsonPropertyName("longitude")]
    [Description("Longitude coordinate")]
    public double? Longitude { get; init; }
}