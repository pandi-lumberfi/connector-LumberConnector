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

namespace Connector.App.v1.Equipment;

public class EquipmentDataReader : TypedAsyncDataReaderBase<EquipmentDataObject>
{
    private readonly ILogger<EquipmentDataReader> _logger;
    private int _currentPage = 0;
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private int _pageSize = 100;

    public EquipmentDataReader(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<EquipmentDataReader> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }

    public override async IAsyncEnumerable<EquipmentDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<EquipmentDataObject>>();
            // If the EquipmentDataObject does not have the same structure as the Equipment response from the API, create a new class for it and replace EquipmentDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<EquipmentResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
               response = await _apiClient.GetEquipments<EquipmentDataObject>(
                    relativeUrl: $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/equipments",
                    page: _currentPage,
                    size: _pageSize,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'EquipmentDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'EquipmentDataObject'. API StatusCode: {response.StatusCode}");
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