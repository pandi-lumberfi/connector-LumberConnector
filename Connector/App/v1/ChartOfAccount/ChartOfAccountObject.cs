using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class ChartOfAccountObject
{
    
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public String? Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Id of the company to which the chart of account belongs")]
    [Nullable(true)]
    public String? CompanyId { get; init; }

    [JsonPropertyName("account_class")]
    [Description("Account Class")]
    [Nullable(true)]
    public String? AccountClass { get; init; }

    [JsonPropertyName("account_group")]
    [Description("Account Group")]
    [Nullable(true)]
    public String? AccountGroup { get; init; }

    [JsonPropertyName("account_type")]
    [Description("Account Type")]
    [Nullable(true)]
    public String? AccountType { get; init; }

    [JsonPropertyName("account_id")]
    [Description("Account ID")]
    [Nullable(true)]
    public String? AccountId { get; init; }

    [JsonPropertyName("description")]
    [Description("Account Description")]
    [Nullable(true)]
    [WriteOnly]
    public String? Description { get; init; }

    [JsonPropertyName("control_account_module")]
    [Description("Control Account Module")]
    [Nullable(true)]
    public String? ControlAccountModule { get; init; }

    [JsonPropertyName("allow_manual_entry")]
    [Description("Allow Manual Entry")]
    [Nullable(true)]
    public Boolean? AllowManualEntry { get; init; }

    [JsonPropertyName("post_option")]
    [Description("Journal Post Option")]
    [Nullable(true)]
    public String? PostOption { get; init; }

    [JsonPropertyName("source_system_links")]
    [Description("List of source system links")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; } = new List<SourceSystemLink>();
    
}