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

namespace Connector.App.v1.CostCode.Update;

public class UpdateCostCodeHandler : IActionHandler<UpdateCostCodeAction>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<UpdateCostCodeHandler> _logger;

    public UpdateCostCodeHandler(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<UpdateCostCodeHandler> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateCostCodeActionInput>(actionInstance.InputJson);
        if (input == null || string.IsNullOrEmpty(input.Id))
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = [new Error { Source = ["UpdateCostCodeHandler"], Text = "Invalid input" }]
            });
        }
        try
        {
            // Given the input for the action, make a call to your API/system
            var response = new ApiResponse<UpdateCostCodeActionOutput>();
            response = await _apiClient.UpdateCostCodeDataObject($"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/cost_code/{input.Id}", input, cancellationToken)
            .ConfigureAwait(false);

            if (!response.IsSuccessful || response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.IsSuccessful ? "400" : response.StatusCode.ToString(),
                    Errors = [new Error { Source = ["UpdateCostCodeHandler"], Text = "Invalid response" }]
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(response.Data);
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, response.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new CacheSyncCollection() { DataObjectType = typeof(CostCodeDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { "UpdateCostCodeHandler" };
            if (string.IsNullOrEmpty(exception.Source)) errorSource.Add(exception.Source!);
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors =
                [
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
