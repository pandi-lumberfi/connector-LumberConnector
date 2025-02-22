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

namespace Connector.App.v1.CostCode;

public class CostCodeDataReader : TypedAsyncDataReaderBase<CostCodeDataObject>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<CostCodeDataReader> _logger;
    private int _currentPage = 0;
    private int _pageSize = 100;

    public CostCodeDataReader(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<CostCodeDataReader> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }

    public override async IAsyncEnumerable<CostCodeDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<CostCodeDataObject>>();

            try
            {
                response = await _apiClient.GetCostCodeRecords<CostCodeDataObject>(
                    relativeUrl: $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/cost_code",
                    page: _currentPage,
                    size: _pageSize,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(
                    exception,
                    "Exception while making a read request to data object 'CostCodeDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception(
                    $"Failed to retrieve records for 'CostCodeDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any())
            {
                break;
            }

            foreach (var item in response.Data.Items)
            {
                yield return item;
            }

            _currentPage++;
            if (_currentPage >= response.Data.TotalPages)
            {
                break;
            }
        }
    }
}