namespace Connector.App.v1.Project;

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
public class ProjectDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Id of the company to which the Project belongs")]
    [Required]
    public required string CompanyId { get; set; }

    [JsonPropertyName("project_name")]
    [Description("Name of the project")]
    [Required]
    public required string ProjectName { get; set; }

    [JsonPropertyName("project_code")]
    [Description("Code for the project")]
    [Nullable(true)]
    public string? ProjectCode { get; set; }

    [JsonPropertyName("project_number")]
    [Description("Project Number")]
    [Nullable(true)]
    public string? ProjectNumber { get; set; }

    [JsonPropertyName("address")]
    [Description("Address of the project")]
    [Nullable(true)]
    public Address? Address { get; set; }

    [JsonPropertyName("description")]
    [Description("Description of the project")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("budget")]
    [Description("Budget of the project")]
    [Nullable(true)]
    public double? Budget { get; set; }

    [JsonPropertyName("start_date")]
    [Description("Start date of the project")]
    [Nullable(true)]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    [Description("End date of the project")]
    [Nullable(true)]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("status")]
    [Description("Status of the project")]
    [Nullable(true)]
    public string? Status { get; set; }

    [JsonPropertyName("prevailing_wage_project")]
    [Description("Is prevailing wage project?")]
    [Nullable(true)]
    public bool PrevailingWageProject { get; set; } = false;

    [JsonPropertyName("contract_type")]
    [Description("Type of project contract")]
    [Nullable(true)]
    public string? ContractType { get; set; }

    [JsonPropertyName("active")]
    [Description("Is project active?")]
    [Nullable(true)]
    public bool Active { get; set; } = true;

    [JsonPropertyName("allow_only_assigned_crews")]
    [Description("Is allow only assigned crew to clock in")]
    [Nullable(true)]
    public bool AllowOnlyAssignedCrews { get; set; } = false;
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
