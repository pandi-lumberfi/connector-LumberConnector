namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System.Text.Json.Serialization;
using System;

public class BankAccount
{
    [JsonPropertyName("id")]
    [Description("ID of the bank account")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    [Description("Status of the bank account")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("raw_bank_account")]
    [Description("Raw bank account details")]
    [Nullable(true)]
    public RawBankAccount? RawBankAccount { get; set; }

    [JsonPropertyName("employee")]
    [Description("Employee ID associated with the bank account")]
    [Nullable(true)]
    public string? Employee { get; set; }
}

public class RawBankAccount
{
    [JsonPropertyName("institution_name")]
    [Description("Name of the financial institution")]
    public string InstitutionName { get; set; } = string.Empty;

    [JsonPropertyName("account_number_last_four")]
    [Description("Last four digits of the account number")]
    public string AccountNumberLastFour { get; set; } = string.Empty;

    [JsonPropertyName("routing_number")]
    [Description("Routing number of the bank account")]
    public string RoutingNumber { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    [Description("Type of the bank account")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("subtype")]
    [Description("Subtype of the bank account")]
    public string Subtype { get; set; } = string.Empty;
}