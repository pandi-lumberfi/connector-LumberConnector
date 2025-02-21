namespace Connector.User.v1.Employees;

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
    [Required]
    public required DateTime? StartDate { get; init; }

    [JsonPropertyName("end_date")]
    [Description("End date of employment")]
    [Nullable(true)]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("active")]
    [Description("Is the employee active?")]
    [Required]
    public required bool Active { get; init; }
}

public class UserData
{
    [JsonPropertyName("first_name")]
    [Description("First name of the Employee")]
    [Required]
    public required string FirstName { get; init; }

    [JsonPropertyName("middle_name")]
    [Description("Middle name of the Employee")]
    [Nullable(true)]
    public string? MiddleName { get; init; }

    [JsonPropertyName("last_name")]
    [Description("Last name of the Employee")]
    [Required]
    public required string LastName { get; init; }

    [JsonPropertyName("gender")]
    [Description("Gender of the Employee")]
    [Nullable(true)]
    public string? Gender { get; init; }

    [JsonPropertyName("date_of_birth")]
    [Description("Date of Birth of the Employee")]
    [Nullable(true)]
    public DateTime? DateOfBirth { get; init; }

    [JsonPropertyName("phone")]
    [Description("Phone number of the Employee")]
    public string? Phone { get; init; }

    [JsonPropertyName("email")]
    [Description("Email address of the Employee")]
    [Nullable(true)]
    public string? Email { get; init; }

    [JsonPropertyName("address")]
    [Description("Address details of the Employee")]
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
    [Nullable(true)]
    public string? JobTitle { get; init; }
}

public class AddressData
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
