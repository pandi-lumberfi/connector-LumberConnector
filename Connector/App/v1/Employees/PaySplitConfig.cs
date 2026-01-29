namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class PaySplitConfig
{
    [JsonPropertyName("pay_split_type")]
    [Description("Pay split type")]
    [Nullable(true)]
    public string? PaySplitType { get; set; }

    [JsonPropertyName("accounts")]
    [Description("Accounts")]
    [Nullable(true)]
    [WriteOnly]
    public List<BankAccount>? Accounts { get; set; }

    [JsonPropertyName("active")]
    [Description("Active")]
    [Nullable(true)]
    public bool? Active { get; set; } = true;
}
