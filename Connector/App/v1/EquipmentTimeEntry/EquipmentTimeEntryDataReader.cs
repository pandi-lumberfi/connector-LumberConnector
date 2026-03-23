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

namespace Connector.App.v1.EquipmentTimeEntry;

public class EquipmentTimeEntryDataReader : TypedAsyncDataReaderBase<EquipmentTimeEntryDataObject>
{
    private readonly ILogger<EquipmentTimeEntryDataReader> _logger;
    private int _currentPage = 0;
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private int _pageSize = 100;

    public EquipmentTimeEntryDataReader(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<EquipmentTimeEntryDataReader> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }

    public override async IAsyncEnumerable<EquipmentTimeEntryDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<EquipmentTimeEntryDataObject>>();
            // If the EquipmentTimeEntryDataObject does not have the same structure as the EquipmentTimeEntry response from the API, create a new class for it and replace EquipmentTimeEntryDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<EquipmentTimeEntryResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
               response = await _apiClient.GetEquipmentTimeEntry<EquipmentTimeEntryDataObject>(
                    relativeUrl: $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/equipment-timesheets",
                    page: _currentPage,
                    size: _pageSize,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'EquipmentTimeEntryDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'EquipmentTimeEntryDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
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