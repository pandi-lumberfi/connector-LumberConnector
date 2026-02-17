namespace Connector.App.v1.Journal;

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
public class JournalDataObject
{
    [JsonPropertyName("id")]
    [Description("Example primary key of the object")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("periodStart")]
    [Description("Example period start of the object")]
    [Nullable(true)]

    public String? PeriodStart { get; init; }

    [JsonPropertyName("periodEnd")]
    [Description("Example period end of the object")]
    [Nullable(true)]
    public String? PeriodEnd { get; init; }

    [JsonPropertyName("payday")]
    [Description("Example payday of the object")]
    [Nullable(true)]
    public String? Payday { get; init; }

    [JsonPropertyName("payrollType")]
    [Description("Example payroll type of the object")]
    [Nullable(true)]
    public String? PayrollType { get; init; }

    [JsonPropertyName("paymentMethod")]
    [Description("Example payment method of the object")]
    [Nullable(true)]
    public String? PaymentMethod { get; init; }

    [JsonPropertyName("paymentStatus")]
    [Description("Example payment status of the object")]
    [Nullable(true)]
    public String? PaymentStatus { get; init; }

    [JsonPropertyName("managed")]
    [Description("Example managed of the object")]
    [Nullable(true)]
    public Boolean? Managed { get; init; }

    [JsonPropertyName("voided")]
    [Description("Example voided of the object")]
    [Nullable(true)]
    public Boolean? Voided { get; init; }

    [JsonPropertyName("entries")]
    [Description("Example entries of the object")]
    [Nullable(true)]
    public List<JournalEntry>? Entries { get; init; }

}

public class JournalEntry
{
    [JsonPropertyName("branchId")]
    [Description("Branch ID")]
    [Nullable(true)]
    public String? BranchId { get; init; }

    [JsonPropertyName("branchName")]
    [Description("Branch name")]
    [Nullable(true)]
    public String? BranchName { get; init; }

    [JsonPropertyName("branchCode")]
    [Description("Branch code")]
    [Nullable(true)]
    public String? BranchCode { get; init; }

    [JsonPropertyName("departmentId")]
    [Description("Department ID")]
    [Nullable(true)]
    public String? DepartmentId { get; init; }

    [JsonPropertyName("departmentName")]
    [Description("Department name")]
    [Nullable(true)]
    public String? DepartmentName { get; init; }

    [JsonPropertyName("departmentCode")]
    [Description("Department code")]
    [Nullable(true)]
    public String? DepartmentCode { get; init; }

    [JsonPropertyName("workerId")]
    [Description("Worker ID")]
    [Nullable(true)]
    public String? WorkerId { get; init; }

    [JsonPropertyName("workerName")]
    [Description("Worker name")]
    [Nullable(true)]
    public String? WorkerName { get; init; }

    [JsonPropertyName("workerCode")]
    [Description("Worker code")]
    [Nullable(true)]
    public String? WorkerCode { get; init; }

    [JsonPropertyName("projectId")]
    [Description("Project ID")]
    [Nullable(true)]
    public String? ProjectId { get; init; }

    [JsonPropertyName("projectName")]
    [Description("Project name")]
    [Nullable(true)]
    public String? ProjectName { get; init; }

    [JsonPropertyName("projectCode")]
    [Description("Project code")]
    [Nullable(true)]
    public String? ProjectCode { get; init; }

    [JsonPropertyName("subprojectId")]
    [Description("Subproject ID")]
    [Nullable(true)]
    public String? SubprojectId { get; init; }

    [JsonPropertyName("subprojectName")]
    [Description("Subproject name")]
    [Nullable(true)]
    public String? SubprojectName { get; init; }

    [JsonPropertyName("subprojectCode")]
    [Description("Subproject code")]
    [Nullable(true)]
    public String? SubprojectCode { get; init; }

    [JsonPropertyName("taskId")]
    [Description("Task ID")]
    [Nullable(true)]
    public String? TaskId { get; init; }

    [JsonPropertyName("taskName")]
    [Description("Task name")]
    [Nullable(true)]
    public String? TaskName { get; init; }

    [JsonPropertyName("taskCode")]
    [Description("Task code")]
    [Nullable(true)]
    public String? TaskCode { get; init; }

    [JsonPropertyName("costCodeId")]
    [Description("Cost code ID")]
    [Nullable(true)]
    public String? CostCodeId { get; init; }

    [JsonPropertyName("costCodeName")]
    [Description("Cost code name")]
    [Nullable(true)]
    public String? CostCodeName { get; init; }

    [JsonPropertyName("costCode")]
    [Description("Cost code")]
    [Nullable(true)]
    public String? CostCode { get; init; }

    [JsonPropertyName("costTypeId")]
    [Description("Cost type ID")]
    [Nullable(true)]
    public String? CostTypeId { get; init; }

    [JsonPropertyName("costTypeName")]
    [Description("Cost type name")]
    [Nullable(true)]
    public String? CostTypeName { get; init; }

    [JsonPropertyName("costTypeCode")]
    [Description("Cost type code")]
    [Nullable(true)]
    public String? CostTypeCode { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("Equipment ID")]
    [Nullable(true)]
    public String? EquipmentId { get; init; }

    [JsonPropertyName("equipmentName")]
    [Description("Equipment name")]
    [Nullable(true)]
    public String? EquipmentName { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("Equipment code")]
    [Nullable(true)]
    public String? EquipmentCode { get; init; }

    [JsonPropertyName("inventoryItemId")]
    [Description("Inventory item ID")]
    [Nullable(true)]
    public String? InventoryItemId { get; init; }

    [JsonPropertyName("inventoryItemName")]
    [Description("Inventory item name")]
    [Nullable(true)]
    public String? InventoryItemName { get; init; }

    [JsonPropertyName("inventoryItemCode")]
    [Description("Inventory item code")]
    [Nullable(true)]
    public String? InventoryItemCode { get; init; }

    [JsonPropertyName("serviceOrderAppointmentId")]
    [Description("Service order appointment ID")]
    [Nullable(true)]
    public String? ServiceOrderAppointmentId { get; init; }

    [JsonPropertyName("serviceOrderAppointmentName")]
    [Description("Service order appointment name")]
    [Nullable(true)]
    public String? ServiceOrderAppointmentName { get; init; }

    [JsonPropertyName("serviceOrderAppointmentCode")]
    [Description("Service order appointment code")]
    [Nullable(true)]
    public String? ServiceOrderAppointmentCode { get; init; }

    [JsonPropertyName("jobCodeId")]
    [Description("Job code ID")]
    [Nullable(true)]
    public String? JobCodeId { get; init; }

    [JsonPropertyName("jobCodeName")]
    [Description("Job code name")]
    [Nullable(true)]
    public String? JobCodeName { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("Job code")]
    [Nullable(true)]
    public String? JobCode { get; init; }

    [JsonPropertyName("jobClassificationId")]
    [Description("Job classification ID")]
    [Nullable(true)]
    public String? JobClassificationId { get; init; }

    [JsonPropertyName("jobClassificationName")]
    [Description("Job classification name")]
    [Nullable(true)]
    public String? JobClassificationName { get; init; }

    [JsonPropertyName("jobClassificationCode")]
    [Description("Job classification code")]
    [Nullable(true)]
    public String? JobClassificationCode { get; init; }

    [JsonPropertyName("jobLevelId")]
    [Description("Job level ID")]
    [Nullable(true)]
    public String? JobLevelId { get; init; }

    [JsonPropertyName("jobLevelName")]
    [Description("Job level name")]
    [Nullable(true)]
    public String? JobLevelName { get; init; }

    [JsonPropertyName("jobLevelCode")]
    [Description("Job level code")]
    [Nullable(true)]
    public String? JobLevelCode { get; init; }

    [JsonPropertyName("dateWorked")]
    [Description("Date worked")]
    [Nullable(true)]
    public String? DateWorked { get; init; }

    [JsonPropertyName("description")]
    [Description("Description")]
    [Nullable(true)]
    public String? Description { get; init; }

    [JsonPropertyName("transactionDescription")]
    [Description("Transaction description")]
    [Nullable(true)]
    public String? TransactionDescription { get; init; }

    [JsonPropertyName("chartOfAccount")]
    [Description("Chart of account")]
    [Nullable(true)]
    public String? ChartOfAccount { get; init; }

    [JsonPropertyName("subaccount")]
    [Description("Subaccount")]
    [Nullable(true)]
    public String? Subaccount { get; init; }

    [JsonPropertyName("quantity")]
    [Description("Quantity")]
    [Nullable(true)]
    public Double? Quantity { get; init; }

    [JsonPropertyName("uom")]
    [Description("Unit of measure")]
    [Nullable(true)]
    public String? Uom { get; init; }

    [JsonPropertyName("debitAmount")]
    [Description("Debit amount")]
    [Nullable(true)]
    public Double? DebitAmount { get; init; }

    [JsonPropertyName("creditAmount")]
    [Description("Credit amount")]
    [Nullable(true)]
    public Double? CreditAmount { get; init; }
}