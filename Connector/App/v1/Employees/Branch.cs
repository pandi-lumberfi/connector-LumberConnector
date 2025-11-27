namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class Branch
{
    [JsonPropertyName("id")]
    [Description("ID of the branch")]
    [Required]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("branch_name")]
    [Description("Name of the branch")]
    [Nullable(true)]
    public string? BranchName { get; set; } = string.Empty;

    [JsonPropertyName("legal_address")]
    [Description("Legal address of the branch")]
    [Nullable(true)]
    public Address? LegalAddress { get; set; } = new Address();

    [JsonPropertyName("branch_code")]
    [Description("Code of the branch")]
    [Nullable(true)]
    public string? BranchCode { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    [Description("Is the branch active?")]
    [Nullable(true)]
    public bool? Active { get; set; } = true;

    [JsonPropertyName("legal_name")]
    [Description("Legal name of the branch")]
    [Nullable(true)]
    public string? LegalName { get; set; } = string.Empty;

}