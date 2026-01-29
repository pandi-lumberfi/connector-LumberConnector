namespace Connector.App.v1.Employees;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class TaxWithHolding
{
    [JsonPropertyName("user_id")]
    [Description("User ID")]
    [Nullable(true)]
    public Guid? UserId { get; set; }

    [JsonPropertyName("employee_code")]
    [Description("Employee code")]
    [Nullable(true)]
    public string? EmployeeCode { get; set; }

    [JsonPropertyName("jurisdiction")]
    [Description("Jurisdiction")]
    [Nullable(true)]
    public string? Jurisdiction { get; set; }

    [JsonPropertyName("label")]
    [Description("Label")]
    [Nullable(true)]
    public string? Label { get; set; }

    [JsonPropertyName("tax_parameters")]
    [Description("Tax parameters")]
    [Nullable(true)]
    public List<TaxParameterDTO>? TaxParameters { get; set; }

    [JsonPropertyName("tax_elections")]
    [Description("Tax elections")]
    [Nullable(true)]
    public List<TaxElectionDTO>? TaxElections { get; set; }

    [JsonPropertyName("exemption_amount")]
    [Description("Exemption amount")]
    [Nullable(true)]
    [WriteOnly]
    public double? ExemptionAmount { get; set; }
}

public class TaxParameterDTO
{
    [JsonPropertyName("label")]
    [Description("Label")]
    [Nullable(true)]
    public string? Label { get; set; }

    [JsonPropertyName("description")]
    [Description("Description")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("name")]
    [Description("Name")]
    [Nullable(true)]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    [Description("Tax parameter type")]
    [Nullable(true)]
    public string? Type { get; set; }

    [JsonPropertyName("editable")]
    [Description("Whether the parameter is editable")]
    [Nullable(true)]
    public bool? Editable { get; set; }

    [JsonPropertyName("setting")]
    [Description("Tax parameter setting")]
    [Nullable(true)]
    public CheckhqTaxParameterSetting? Setting { get; set; }

    [JsonPropertyName("definitions")]
    [Description("Tax parameter definitions")]
    [Nullable(true)]
    public List<CheckhqTaxParameterDefinition>? Definitions { get; set; }

    [JsonPropertyName("default_value")]
    [Description("Default value")]
    [Nullable(true)]
    public string? DefaultValue { get; set; }

    [JsonPropertyName("submitter")]
    [Description("Tax submitter type")]
    [Nullable(true)]
    public string? Submitter { get; set; }
}

public class TaxElectionDTO
{
    [JsonPropertyName("description")]
    [Description("Description")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("payer")]
    [Description("Payer")]
    [Nullable(true)]
    public string? Payer { get; set; }

    [JsonPropertyName("jurisdiction_abbreviation")]
    [Description("Jurisdiction abbreviation")]
    [Nullable(true)]
    public string? JurisdictionAbbreviation { get; set; }

    [JsonPropertyName("exemptible")]
    [Description("Whether the election is exemptible")]
    [Nullable(true)]
    public bool? Exemptible { get; set; }

    [JsonPropertyName("setting")]
    [Description("Tax election setting")]
    [Nullable(true)]
    public CheckhqTaxElectionSetting? Setting { get; set; }

    [JsonPropertyName("setting_timeline")]
    [Description("Tax election setting timeline")]
    [Nullable(true)]
    public List<CheckhqTaxElectionSetting>? SettingTimeline { get; set; }
}

public class CheckhqTaxElectionSetting
{
    [JsonPropertyName("exempt")]
    [Description("Whether the tax is exempt")]
    [Nullable(true)]
    public bool? Exempt { get; set; }

    [JsonPropertyName("effective_start")]
    [Description("Effective start date")]
    [Nullable(true)]
    public string? EffectiveStart { get; set; }

    [JsonPropertyName("effective_end")]
    [Description("Effective end date")]
    [Nullable(true)]
    public string? EffectiveEnd { get; set; }
}

public class CheckhqTaxParameterSetting
{
    [JsonPropertyName("id")]
    [Description("ID of the tax parameter setting")]
    [Nullable(true)]
    public string? Id { get; set; }

    [JsonPropertyName("applied_for")]
    [Description("Applied for")]
    [Nullable(true)]
    public string? AppliedFor { get; set; }

    [JsonPropertyName("value")]
    [Description("Value")]
    [Nullable(true)]
    public string? Value { get; set; }

    [JsonPropertyName("effective_date")]
    [Description("Effective date")]
    [Nullable(true)]
    public string? EffectiveDate { get; set; }
}

public class CheckhqTaxParameterDefinition
{
    [JsonPropertyName("applied_for")]
    [Description("Applied for")]
    [Nullable(true)]
    public string? AppliedFor { get; set; }

    [JsonPropertyName("value")]
    [Description("Value")]
    [Nullable(true)]
    public string? Value { get; set; }

    [JsonPropertyName("effective_start")]
    [Description("Effective start date")]
    [Nullable(true)]
    public string? EffectiveStart { get; set; }
}