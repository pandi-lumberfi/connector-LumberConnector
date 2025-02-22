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

namespace Connector.App.v1.Project.Update;

public class UpdateProjectHandler : IActionHandler<UpdateProjectAction>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<UpdateProjectHandler> _logger;

    public UpdateProjectHandler(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<UpdateProjectHandler> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating project");
        var input = JsonSerializer.Deserialize<UpdateProjectActionInput>(actionInstance.InputJson);
        
        if (input == null || string.IsNullOrEmpty(input.Id))
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = [new Error { 
                    Source = ["UpdateProjectHandler"], 
                    Text = input == null ? "Invalid input" : "Project id is required" 
                }]
            });
        }

        try
        {
            var response = await _apiClient.UpdateProjectDataObject(
                $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/projects/{input.Id}",
                input,
                cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessful || response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.IsSuccessful ? "400" : response.StatusCode.ToString(),
                    Errors = [new Error { Source = ["UpdateProjectHandler"], Text = "Invalid response" }]
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var (UrlPart, PropertyNames) = keyResolver.BuildKeyResolver()(response.Data);
            operations.Add(SyncOperation.CreateSyncOperation(
                UpdateOperation.Upsert.ToString(),
                UrlPart,
                PropertyNames,
                response.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(ProjectDataObject), CacheChanges = [.. operations] }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { "UpdateProjectHandler" };
            if (!string.IsNullOrEmpty(exception.Source))
            {
                errorSource.Add(exception.Source);
            }

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
