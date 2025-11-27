namespace Connector.App.v1.Employees;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Json.Schema.Generation;

public class BankAccount
{
    [JsonPropertyName("id")]
    [Description("ID of the bank account")]
    [Nullable(true)]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    [Description("Status of the bank account")]
    [Nullable(true)]
    public string? Status { get; set; }

    [JsonPropertyName("institution_name")]
    [Description("Name of the financial institution")]
    [Nullable(true)]
    public string? InstitutionName { get; set; }

    [JsonPropertyName("account_number")]
    [Description("Account number")]
    [WriteOnly]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("routing_number")]
    [Description("Routing number of the bank account")]
    [WriteOnly]
    public string? RoutingNumber { get; set; }

    [JsonPropertyName("account_type")]
    [Description("Type of the bank account")]
    [WriteOnly]
    public string? AccountType { get; set; }   

    [JsonPropertyName("account_subtype")]
    [Description("Subtype of the bank account")]
    [Nullable(true)]
    public string? AccountSubtype { get; set; }

    [JsonPropertyName("priority")]
    [Description("Priority of the bank account")]
    [Nullable(true)]
    public int? Priority { get; set; }

    [JsonPropertyName("amount")]
    [Description("Amount of the bank account")]
    [Nullable(true)]
    public string? Amount { get; set; }

    [JsonPropertyName("percentage")]
    [Description("Percentage of the bank account")]
    [Nullable(true)]
    public string? Percentage { get; set; }
}
