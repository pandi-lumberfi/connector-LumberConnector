namespace Connector.App.v1.Employees;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Json.Schema.Generation;

public class EmployeePaystub
{
    [JsonPropertyName("payroll")]
    [Description("Payroll")]
    [Required]
    public string? Payroll { get; set; }

    [JsonPropertyName("payday")]
    [Description("Payday")]
    [Required]
    public DateOnly? Payday { get; set; }

    [JsonPropertyName("period_start")]
    [Description("Period start")]
    [Required]
    public DateOnly? PeriodStart { get; set; }

    [JsonPropertyName("period_end")]
    [Description("Period end")]
    [Required]
    public DateOnly? PeriodEnd { get; set; }

    [JsonPropertyName("company_user_id")]
    [Description("Company user id")]
    [Required]
    public string? CompanyUserId { get; set; }

    [JsonPropertyName("employee_id")]
    [Description("Employee id")]
    [Nullable(true)]
    public string? EmployeeId { get; set; }

    [JsonPropertyName("earnings")]
    [Description("Earnings")]
    [Nullable(true)]
    public List<PaystubEarning>? Earnings { get; set; }

    [JsonPropertyName("reimbursements")]
    [Description("Reimbursements")]
    [Nullable(true)]
    public List<PaystubReimbursement>? Reimbursements { get; set; }

    [JsonPropertyName("employee_taxes")]
    [Description("Employee taxes")]
    [Nullable(true)]
    public List<PaystubTax>? EmployeeTaxes { get; set; }

    [JsonPropertyName("company_taxes")]
    [Description("Company taxes")]
    [Nullable(true)]
    public List<PaystubTax>? CompanyTaxes { get; set; }

    [JsonPropertyName("employee_benefit_contributions")]
    [Description("Employee benefit contributions")]
    [Nullable(true)]
    public List<PaystubBenefit>? EmployeeBenefitContributions { get; set; }

    [JsonPropertyName("company_benefit_contributions")]
    [Description("Company benefit contributions")]
    [Nullable(true)]
    public List<PaystubBenefit>? CompanyBenefitContributions { get; set; }

    [JsonPropertyName("post_tax_deductions")]
    [Description("Post tax deductions")]
    [Nullable(true)]
    public List<PaystubDeduction>? PostTaxDeductions { get; set; }

    [JsonPropertyName("summary")]
    [Description("Summary")]
    [Nullable(true)]
    public PaystubSummary? Summary { get; set; }

    [JsonPropertyName("total_hours")]
    [Description("Total hours")]
    [Nullable(true)]
    public double? TotalHours { get; set; }

    [JsonPropertyName("payment_method")]
    [Description("Payment method")]
    [Nullable(true)]
    public string? PaymentMethod { get; set; }
}

public class PaystubEarning
{
    [JsonPropertyName("type")]
    [Description("Type")]
    [Nullable(true)]
    public string? Type { get; set; }

    [JsonPropertyName("code")]
    [Description("Code")]
    [Nullable(true)]
    public string? Code { get; set; }

    [JsonPropertyName("earning_code")]
    [Description("Earning code")]
    [Nullable(true)]
    public string? EarningCode { get; set; }

    [JsonPropertyName("amount")]
    [Description("Amount")]
    [Nullable(true)]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_ytd")]
    [Description("Amount YTD")]
    [Nullable(true)]
    public double? AmountYtd { get; set; }

    [JsonPropertyName("hours")]
    [Description("Hours")]
    [Nullable(true)]
    public double? Hours { get; set; }

    [JsonPropertyName("hours_ytd")]
    [Description("Hours YTD")]
    [Nullable(true)]
    public double? HoursYtd { get; set; }

    [JsonPropertyName("name")]
    [Description("Name")]
    [Nullable(true)]
    public string? Name { get; set; }
}

public class PaystubReimbursement
{
    [JsonPropertyName("code")]
    [Description("Code")]
    [Nullable(true)]
    public string? Code { get; set; }

    [JsonPropertyName("amount")]
    [Description("Amount")]
    [Nullable(true)]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_ytd")]
    [Description("Amount YTD")]
    [Nullable(true)]
    public double? AmountYtd { get; set; }

    [JsonPropertyName("current_reimbursements")]
    [Description("Current reimbursements")]
    [Nullable(true)]
    public List<PaystubReimbursementItem>? CurrentReimbursements { get; set; }
}

public class PaystubReimbursementItem
{
    [JsonPropertyName("description")]
    [Description("Description")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("amount")]
    [Description("Amount")]
    [Nullable(true)]
    public double? Amount { get; set; }

}

public class PaystubTax
{
    [JsonPropertyName("amount")]
    [Description("Amount")]
    [Nullable(true)]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_ytd")]
    [Description("Amount YTD")]
    [Nullable(true)]
    public double? AmountYtd { get; set; }

    [JsonPropertyName("description")]
    [Description("Description")]
    [Nullable(true)]
    public string? Description { get; set; }
}

public class PaystubBenefit
{
    [JsonPropertyName("benefit")]
    [Description("Benefit")]
    [Nullable(true)]
    public string? Benefit { get; set; }

    [JsonPropertyName("description")]
    [Description("Description")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("amount")]
    [Description("Amount")]
    [Nullable(true)]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_ytd")]
    [Description("Amount YTD")]
    [Nullable(true)]
    public double? AmountYtd { get; set; }
}

public class PaystubDeduction
{
    [JsonPropertyName("type")]
    [Description("Type")]
    [Nullable(true)]
    public string? Type { get; set; }

    [JsonPropertyName("description")]
    [Description("Description")]
    [Nullable(true)]
    public string? Description { get; set; }

    [JsonPropertyName("calculation_method")]
    [Description("Calculation method")]
    [Nullable(true)]
    public string? CalculationMethod { get; set; }

    [JsonPropertyName("amount")]
    [Description("Amount")]
    [Nullable(true)]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_ytd")]
    [Description("Amount YTD")]
    [Nullable(true)]
    public double? AmountYtd { get; set; }
}

public class PaystubSummary
{
    [JsonPropertyName("earnings")]
    [Description("Earnings")]
    [Nullable(true)]
    public double? Earnings { get; set; }

    [JsonPropertyName("earnings_ytd")]  
    [Description("Earnings YTD")]
    [Nullable(true)]
    public double? EarningsYtd { get; set; }

    [JsonPropertyName("reimbursements")]
    [Description("Reimbursements")]
    [Nullable(true)]
    public double? Reimbursements { get; set; }

    [JsonPropertyName("reimbursements_ytd")]
    [Description("Reimbursements YTD")]
    [Nullable(true)]
    public double? ReimbursementsYtd { get; set; }

    [JsonPropertyName("employee_taxes")]
    [Description("Employee taxes")]
    [Nullable(true)]
    public double? EmployeeTaxes { get; set; }

    [JsonPropertyName("employee_taxes_ytd")]
    [Description("Employee taxes YTD")]
    [Nullable(true)]
    public double? EmployeeTaxesYtd { get; set; }

    [JsonPropertyName("company_taxes")]
    [Description("Company taxes")]
    [Nullable(true)]
    public double? CompanyTaxes { get; set; }

    [JsonPropertyName("company_taxes_ytd")]
    [Description("Company taxes YTD")]
    [Nullable(true)]
    public double? CompanyTaxesYtd { get; set; }

    [JsonPropertyName("employee_benefit_contributions")]
    [Description("Employee benefit contributions")]
    [Nullable(true)]
    public double? EmployeeBenefitContributions { get; set; }

    [JsonPropertyName("employee_benefit_contributions_ytd")]
    [Description("Employee benefit contributions YTD")]
    [Nullable(true)]
    public double? EmployeeBenefitContributionsYtd { get; set; }

    [JsonPropertyName("company_benefit_contributions")]
    [Description("Company benefit contributions")]
    [Nullable(true)]
    public double? CompanyBenefitContributions { get; set; }

    [JsonPropertyName("company_benefit_contributions_ytd")]
    [Description("Company benefit contributions YTD")]
    [Nullable(true)]
    public double? CompanyBenefitContributionsYtd { get; set; }

    [JsonPropertyName("post_tax_deductions")]
    [Description("Post tax deductions")]
    [Nullable(true)]
    public double? PostTaxDeductions { get; set; }

    [JsonPropertyName("post_tax_deductions_ytd")]
    [Description("Post tax deductions YTD")]
    [Nullable(true)]
    public double? PostTaxDeductionsYtd { get; set; }

    [JsonPropertyName("net_pay")]
    [Description("Net pay")]
    [Nullable(true)]
    public double? NetPay { get; set; }

    [JsonPropertyName("net_pay_ytd")]
    [Description("Net pay YTD")]
    [Nullable(true)]
    public double? NetPayYtd { get; set; }
}
