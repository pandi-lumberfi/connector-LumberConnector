namespace Connector.App.v1.Department;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; 

public class DepartmentObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Nullable(true)]
    public string?  Id { get; init; }

    [JsonPropertyName("company_id")] 
    [Description("ID of the company associated with the cost code")]
    [Required]
    public string? CompanyId { get; init; }

    [JsonPropertyName("department_code")]       
    [Description("Code of the department")]
    [Required]
    public string? DepartmentCode { get; init; }

    [JsonPropertyName("department_name")]
    [Description("Name of the department")]
    [Required]
    public string? DepartmentName { get; init; }

    [JsonPropertyName("description")]
    [Description("Description of the department")]
    [Nullable(true)]
    public string? Description { get; init; }   

    [JsonPropertyName("active")]
    [Description("Is department active?")]
    [Required]
    public bool Active { get; init; }
}   