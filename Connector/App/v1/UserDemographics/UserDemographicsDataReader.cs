using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.App.v1.UserDemographics;

public class UserDemographicsDataReader : TypedAsyncDataReaderBase<UserDemographicsDataObject>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<UserDemographicsDataReader> _logger;

    public UserDemographicsDataReader(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<UserDemographicsDataReader> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }

    public override async IAsyncEnumerable<UserDemographicsDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        List<UserDemographicsDataObject> userDemographicsDataObjects;
        
        try
        {
            userDemographicsDataObjects = await _apiClient.GetUserDemographics<UserDemographicsDataObject>(
                relativeUrl: $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/users/employee_report",
                cancellationToken: cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while making a read request to data object 'UserDemographicsDataObject'");
            throw;
        }

        // Return the data objects to Cache.
        foreach (var item in userDemographicsDataObjects)
        {
            // Generate an ID if the item doesn't have one using reflection
            if (item.Id == null)
            {
                var itemWithId = CreateWithId(item, Guid.NewGuid());
                yield return itemWithId;
            }
            else
            {
                yield return item;
            }
        }
    }

    private static UserDemographicsDataObject CreateWithId(UserDemographicsDataObject source, Guid id)
    {
        return new UserDemographicsDataObject
        {
            Id = id,
            FirstName = source.FirstName,
            MiddleName = source.MiddleName,
            LastName = source.LastName,
            Gender = source.Gender,
            JobTitle = source.JobTitle,
            UserStatus = source.UserStatus,
            HiringStatus = source.HiringStatus,
            Ethnicity = source.Ethnicity,
            Race = source.Race,
            EeocJobClassificationType = source.EeocJobClassificationType,
            VeteranStatus = source.VeteranStatus,
            DisabilityStatus = source.DisabilityStatus,
            Active = source.Active,
            PayrollEnabled = source.PayrollEnabled,
            DateOfBirth = source.DateOfBirth,
            HireDate = source.HireDate,
            StartDate = source.StartDate,
            RehireDate = source.RehireDate,
            TerminationDate = source.TerminationDate,
            EmployeeCode = source.EmployeeCode,
            LumberRole = source.LumberRole,
            MaritalStatus = source.MaritalStatus,
            EmploymentType = source.EmploymentType,
            EmploymentCategory = source.EmploymentCategory,
            Email = source.Email,
            PhoneNumber = source.PhoneNumber,
            Address = source.Address,
            Workplaces = source.Workplaces,
            EmergencyContactName = source.EmergencyContactName,
            EmergencyContactPhoneNumber = source.EmergencyContactPhoneNumber,
            EmergencyContactRelation = source.EmergencyContactRelation,
            PrimaryWorkplace = source.PrimaryWorkplace,
            Department = source.Department,
            Branch = source.Branch,
            EmployeeClass = source.EmployeeClass,
            ShortSsn = source.ShortSsn,
            CompensationType = source.CompensationType,
            PayFrequency = source.PayFrequency,
            IsNonOvertimeEmployee = source.IsNonOvertimeEmployee,
            IsAutoAssignWorkplaceByState = source.IsAutoAssignWorkplaceByState,
            BasePayRate = source.BasePayRate,
            OvertimePayRate = source.OvertimePayRate,
            DoubleOvertimePayRate = source.DoubleOvertimePayRate,
            AdditionalCompensationRate = source.AdditionalCompensationRate,
            UnionName = source.UnionName,
            Trades = source.Trades,
            JobLevel = source.JobLevel,
            JobClassification = source.JobClassification,
            BankAccounts = source.BankAccounts,
            TaxWithHoldings = source.TaxWithHoldings,
            Account = source.Account,
            SubAccount = source.SubAccount
        };
    }
}