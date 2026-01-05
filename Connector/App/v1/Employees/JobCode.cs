namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class JobCode
{

    [JsonPropertyName("id")]
    [Description("ID of the job code")]
    [Required]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("company_user_id")]
    [Description("Company user ID")]
    [Nullable(true)]
    public string? CompanyUserId { get; set; } = string.Empty;

    [JsonPropertyName("job_code_id")]
    [Description("Job code ID")]
    [Nullable(true)]
    public string? JobCodeId { get; set; } = string.Empty;

    [JsonPropertyName("job_code_code")]
    [Description("Job code code")]
    [Nullable(true)]
    public string? JobCodeCode { get; set; } = string.Empty;

    [JsonPropertyName("active")]
    [Description("Is the job code active?")]
    [Nullable(true)]
    public bool? Active { get; set; } = true;
}