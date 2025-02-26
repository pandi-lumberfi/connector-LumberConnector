using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.App.v1.Timesheet;

public class TimesheetDataReader : TypedAsyncDataReaderBase<TimesheetDataObject>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<TimesheetDataReader> _logger;

    public TimesheetDataReader(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<TimesheetDataReader> logger)
    {
         _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }

    public override async IAsyncEnumerable<TimesheetDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = new ApiResponse<IEnumerable<TimesheetDataObject>>();
        // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
        try
        {
            response = await _apiClient.GetTimesheetRecords<TimesheetDataObject>(
                relativeUrl: "api/v1/companies/" + _connectorRegistrationConfig.CompanyId +"/timesheet",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while making a read request to data object 'TimesheetDataObject'");
            throw;
        }

        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to retrieve records for 'TimesheetDataObject'. API StatusCode: {response.StatusCode}");
        }

        if (response.Data != null)
        {
           foreach (var item in response.Data)
            {
                yield return item;
            }
        }        
    }
}