namespace Connector.App.v1.Branch;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class BranchObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public string? Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Company ID")]
    [Required]
    public string? CompanyId { get; init; }

    [JsonPropertyName("branch_code")]
    [Description("Branch code")]
    [Required]
    public string? BranchCode { get; init; }

    [JsonPropertyName("branch_name")]   
    [Description("Name of the Branch")] 
    [Required]
    public string? BranchName { get; init; }

    [JsonPropertyName("address")]
    [Description("Address")]
    [Nullable(true)]
    public Address? Address { get; init; }  

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
    public Address? LegalAddress { get; init; }
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