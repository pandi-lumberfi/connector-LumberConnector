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

namespace Connector.App.v1.Employees.Update;

public class UpdateEmployeesHandler : IActionHandler<UpdateEmployeesAction>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<UpdateEmployeesHandler> _logger;

    public UpdateEmployeesHandler(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<UpdateEmployeesHandler> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateEmployeesActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = [new Error { Source = ["UpdateEmployeesHandler"], Text = "Invalid input" }]
            });
        }
        
        try
        {
            if (string.IsNullOrEmpty(input.CompanyId) || string.IsNullOrEmpty(input.Id))
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = "400",
                    Errors = [new Error { Source = ["UpdateEmployeesHandler"], Text = "Id is required" }]
                });
            } 
            // Given the input for the action, make a call to your API/system
            var response = new ApiResponse<UpdateEmployeesActionOutput>();
            response = await _apiClient.UpdateEmployeesDataObject($"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/users/{input.Id}", input, cancellationToken)
            .ConfigureAwait(false);

            if (response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = "400",
                    Errors = [new Error { Source = ["UpdateEmployeesHandler"], Text = "Invalid response" }]
                }); 
            } 
            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var (UrlPart, PropertyNames) = keyResolver.BuildKeyResolver()(response.Data);
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), UrlPart, PropertyNames, response.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(EmployeesDataObject), CacheChanges = [.. operations] }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            // If an error occurs, we want to create a failure result for the action that matches
            // the failure type for the action. 
            // Common to create extension methods to map to Standard Action Failure

            var errorSource = new List<string> { "UpdateEmployeesHandler" };
            if (string.IsNullOrEmpty(exception.Source)) errorSource.Add(exception.Source!);
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors =
                [
                    new Error
                    {
                        Source = [.. errorSource],
                        Text = exception.Message
                    }
                ]
            });
        }
    }
}
