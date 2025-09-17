namespace Connector.App.v1.Branch;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
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
public class BranchDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Company ID")]
    [Required]
    public required string CompanyId { get; init; }

    [JsonPropertyName("branch_code")]   
    [Description("Branch code")]
    [Required]
    public required string BranchCode { get; init; }

    [JsonPropertyName("branch_name")]
    [Description("Name of the Branch")]
    [Required]
    public required string BranchName { get; init; }
    
    [JsonPropertyName("address")]
    [Description("Address")]
    [Nullable(true)]
    public AddressData? Address { get; init; }

    [JsonPropertyName("legal_name")]
    [Description("Branch Legal Name")]
    [Nullable(true)]
    public string? LegalName { get; init; }
    
    [JsonPropertyName("tax_registration_id")]
    [Description("Branch Tax Registration Id")]
    [Nullable(true)]
    public string? TaxRegistrationId { get; init; } 

    [JsonPropertyName("tax_exemption_number")]
    [Description("Branch Tax Exemption Number")]
    [Nullable(true)]
    public string? TaxExemptionNumber { get; init; }  
    
    [JsonPropertyName("active")]
    [Description("Is the branch active?")]
    [Required]
    public bool Active { get; init; } = true;
    
    [JsonPropertyName("legal_address")]
    [Description("Legal Address of the Branch")]
    [Nullable(true)]
    public AddressData? LegalAddress { get; init; }

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; }
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
