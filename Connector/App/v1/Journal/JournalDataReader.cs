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

namespace Connector.App.v1.Journal;

public class JournalDataReader : TypedAsyncDataReaderBase<JournalDataObject>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;

    private readonly ILogger<JournalDataReader> _logger;

    public JournalDataReader(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<JournalDataReader> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }

    public override async IAsyncEnumerable<JournalDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = new ApiResponse<List<JournalDataObject>>();

        // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
        try
        {
            response = await _apiClient.GetJournalRecords<JournalDataObject>(
               relativeUrl: $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/journals",
               cancellationToken: cancellationToken)
               .ConfigureAwait(false);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while making a read request to data object 'JournalDataObject'");
            throw;
        }

        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to retrieve records for 'JournalDataObject'. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null || !response.Data.Any())
        {
            yield break;
        }

        // Return the data objects to Cache.
        foreach (var item in response.Data)
        {
            JournalDataObject journal;
            try
            {
                journal = await _apiClient.GetJournal<JournalDataObject>(
                    relativeUrl: $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/journals/{item.Id}?productType=VISTA",
                    cancellationToken: cancellationToken);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'JournalDataObject'");
                throw;
            }
            yield return journal;
        }
    }
}
