using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.App.v1.CostCode.Create;

public class CreateCostCodeHandler : IActionHandler<CreateCostCodeAction>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<CreateCostCodeHandler> _logger;

    public CreateCostCodeHandler(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<CreateCostCodeHandler> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateCostCodeActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = [new Error { Source = ["CreateCostCodeHandler"], Text = "Invalid input" }]
            });
        }

        try
        {
            var response = await _apiClient.CreateCostCodeDataObject(
                $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/cost_code",
                input,
                cancellationToken)
                .ConfigureAwait(false);

            if (response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = "400",
                    Errors = [new Error { Source = ["CreateCostCodeHandler"], Text = "Invalid response" }]
                });
            }

            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(response.Data);

            var operations = new List<SyncOperation>
            {
                SyncOperation.CreateSyncOperation(
                    UpdateOperation.Upsert.ToString(),
                    key.UrlPart,
                    key.PropertyNames,
                    response.Data)
            };

            var resultList = new List<CacheSyncCollection>
            {
                new()
                {
                    DataObjectType = typeof(CostCodeDataObject),
                    CacheChanges = operations.ToArray()
                }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { "CreateCostCodeHandler" };
            if (!string.IsNullOrEmpty(exception.Source))
            {
                errorSource.Add(exception.Source);
            }

            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = [
                    new Error
                    {
                        Source = errorSource.ToArray(),
                        Text = exception.Message
                    }
                ]
            });
        }
    }
}
