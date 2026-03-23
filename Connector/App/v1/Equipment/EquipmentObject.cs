using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class EquipmentObject
{
    
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public String? Id { get; init; }

    [JsonPropertyName("company_id")]
    [Description("Id of the company to which the equipment belongs")]
    [Nullable(true)]
    public String? CompanyId { get; init; }

    [JsonPropertyName("equipment_code")]
    [Description("Code of the equipment")]
    [Nullable(true)]
    public String? EquipmentCode { get; init; }

    [JsonPropertyName("equipment_name")]
    [Description("Name of the equipment")]
    [Nullable(true)]
    public String? EquipmentName { get; init; }

    [JsonPropertyName("model")]
    [Description("Model of the equipment")]
    [Nullable(true)]
    public String? Model { get; init; }

    [JsonPropertyName("make")]
    [Description("Make of the equipment")]
    [Nullable(true)]
    public String? Make { get; init; }

    [JsonPropertyName("make_id")]
    [Description("Id of the make of the equipment")]
    [Nullable(true)]
    public String? MakeId { get; init; }

    [JsonPropertyName("class_code")]
    [Description("Code of the class of the equipment")]
    [Nullable(true)]
    public String? ClassCode { get; init; }

    [JsonPropertyName("equipment_class_code_id")]
    [Description("Id of the equipment class code")]
    [Nullable(true)]
    public String? EquipmentClassCodeId { get; init; }

    [JsonPropertyName("status")]
    [Description("Status of the equipment")]
    [Nullable(true)]
    public String? Status { get; init; }

    [JsonPropertyName("category")]
    [Description("Category of the equipment")]
    [Nullable(true)]
    public String? Category { get; init; }

    [JsonPropertyName("category_id")]
    [Description("Id of the category of the equipment")]
    [Nullable(true)]
    public String? CategoryId { get; init; }

    [JsonPropertyName("hour_meter")]
    [Description("Hour meter of the equipment")]
    [Nullable(true)]
    public Double? HourMeter { get; init; }

    [JsonPropertyName("unit_of_usage")]
    [Description("Unit of usage of the equipment")]
    [Nullable(true)]
    public String? UnitOfUsage { get; init; }
    
    [JsonPropertyName("last_service_date")]
    [Description("Last service date of the equipment")]
    [Nullable(true)]
    public String? LastServiceDate { get; init; }

    [JsonPropertyName("source_system_links")]
    [Description("Source system links of the equipment")]
    [Nullable(true)]
    public List<SourceSystemLink>? SourceSystemLinks { get; set; } = new List<SourceSystemLink>();
}