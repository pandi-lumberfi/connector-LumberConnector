using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.App.v1.Project.Create;

public class CreateProjectHandler : IActionHandler<CreateProjectAction>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<CreateProjectHandler> _logger;

    public CreateProjectHandler(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<CreateProjectHandler> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating project");
        var input = JsonSerializer.Deserialize<CreateProjectActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = [new Error { Source = ["CreateProjectHandler"], Text = "Invalid input" }]
            });
        }

        try
        {
            var response = await _apiClient.PostProjectDataObject(
                $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/projects", 
                input,
                cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = [new Error { Source = ["CreateProjectHandler"], Text = "Invalid response" }]
                });
            }   

            if (response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = "400", 
                    Errors = [new Error { Source = ["CreateProjectHandler"], Text = "Invalid input" }]
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
                new() 
                { 
                    DataObjectType = typeof(ProjectDataObject),
                    CacheChanges = [.. operations]
                }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { "CreateProjectHandler" };
            if (!string.IsNullOrEmpty(exception.Source))
            {
                errorSource.Add(exception.Source);
            }
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = errorSource.ToArray(),
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
