namespace Connector.App.v1.ChartOfAccount;

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
public class ChartOfAccountDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }


    [JsonPropertyName("companyId")]
    [Description("Id of the company to which the chart of account belongs")]
    [Required]
    public required String CompanyId { get; init; }

    [JsonPropertyName("accountClass")]
    [Description("Account Class")]
    [Nullable(true)]
    public String? AccountClass { get; init; }


    [JsonPropertyName("accountGroup")]
    [Description("Account Group")]
    [Nullable(true)]
    public String? AccountGroup { get; init; }

    [JsonPropertyName("accountType")]
    [Description("Account Type")]
    [Nullable(true)]
    public String? AccountType { get; init; }

    [JsonPropertyName("accountId")]
    [Description("Account ID")]
    [Nullable(true)]
    [WriteOnly]
    public String? AccountId { get; init; }

    [JsonPropertyName("description")]
    [Description("Account Description")]
    [Nullable(true)]
    public String? Description { get; init; }

    [JsonPropertyName("controlAccountModule")]
    [Description("Control Account Module")]
    [Nullable(true)]
    public String? ControlAccountModule { get; init; }

    [JsonPropertyName("allowManualEntry")]
    [Description("Allow Manual Entry")]
    [Nullable(true)]
    public Boolean? AllowManualEntry { get; init; }

    [JsonPropertyName("postOption")]
    [Description("Journal Post Option")]
    [Nullable(true)]
    public String? PostOption { get; init; }

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; } = new List<SourceSystemLink>();

}