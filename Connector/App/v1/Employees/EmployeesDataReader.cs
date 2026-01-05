using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.App.v1.Employees;

public class EmployeesDataReader : TypedAsyncDataReaderBase<EmployeesDataObject>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<EmployeesDataReader> _logger;

    private int _currentPage = 0;
    private int _pageSize = 100;

    public EmployeesDataReader(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<EmployeesDataReader> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }

    public override async IAsyncEnumerable<EmployeesDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<EmployeesDataObject>>();
            try
            {
                response = await _apiClient.GetEmployeeRecords<EmployeesDataObject>(
                   relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId +"/users",
                   page: _currentPage,
                   size: _pageSize,
                   cancellationToken: cancellationToken)
                   .ConfigureAwait(false);

            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'EmployeesDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'EmployeesDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                if (item.PayrollEnabled) {
                try
                    {
                        var bankAccounts = new List<BankAccount>();
                        await foreach (var bankAccount in _apiClient.GetBankAccounts<BankAccount>(
                            relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId +"/users/" + item.Id + "/bank-accounts",
                            cancellationToken: cancellationToken))
                        {
                            bankAccounts.Add(bankAccount);
                        }

                        // TODO: Uncomment this when the API is implemented
                        // var userBenefits = new List<UserBenefit>();
                        // await foreach (var userBenefit in _apiClient.GetUserBenefits<UserBenefit>(
                        //     relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId +"/users/" + item.Id + "/benefits",
                        //     cancellationToken: cancellationToken))
                        // {
                        //     userBenefits.Add(userBenefit);
                        // }

                        var userPayRates = new List<UserPayRate>();
                        await foreach (var userPayRate in _apiClient.GetUserPayRates<UserPayRate>(
                            relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId +"/users/" + item.Id + "/pay-rates",
                            cancellationToken: cancellationToken))
                        {   
                            userPayRates.Add(userPayRate);
                        }

                        var userTaxWithHoldings = new List<UserTaxWithHolding>();   
                        await foreach (var userTaxWithHolding in _apiClient.GetUserTaxWithHoldings<UserTaxWithHolding>(
                            relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId +"/users/" + item.Id + "/tax-with-holdings",
                            cancellationToken: cancellationToken))
                        {
                            userTaxWithHoldings.Add(userTaxWithHolding);
                        }       

                        var compCodes = new List<CompCode>();
                        await foreach (var compCode in _apiClient.GetCompCodes<CompCode>(
                            relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId +"/users/" + item.Id + "/comp-codes",
                            cancellationToken: cancellationToken))
                        {
                            compCodes.Add(compCode);
                        }

                        var jobCodes = new List<JobCode>();
                        await foreach (var jobCode in _apiClient.GetJobCodes<JobCode>(
                            relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId +"/users/" + item.Id + "/job-codes",
                            cancellationToken: cancellationToken))
                        {
                            jobCodes.Add(jobCode);
                        }

                        item.BankAccounts = bankAccounts;
                        // item.UserBenefits = userBenefits;
                        item.UserPayRates = userPayRates;
                        item.UserTaxWithHoldings = userTaxWithHoldings;
                        item.CompCodes = compCodes;
                        item.JobCodes = jobCodes;
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError(exception, "Exception while processing data object 'EmployeesDataObject'");
                    }
                }
                
                // TODO: Uncomment this when the API is implemented
                // var userLeaveBalance = await _apiClient.GetUserLeaveBalance<UserLeaveBalance>(
                //     relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId + "/users/" + item.Id + "/leave_balance_summary",
                //     cancellationToken: cancellationToken)
                //     .ConfigureAwait(false);
                // if (userLeaveBalance != null) {
                //     item.UserLeaveBalance = userLeaveBalance;
                // }

                yield return item;

            }

            // Handle pagination per API client design
            _currentPage++;
            if (_currentPage >= response.Data.TotalPages)
            {
                break;
            }
        }
    }
}