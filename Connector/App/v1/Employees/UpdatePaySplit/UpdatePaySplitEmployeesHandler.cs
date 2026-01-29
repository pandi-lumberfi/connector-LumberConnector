using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.App.v1.Employees.UpdatePaySplit;

public class UpdatePaySplitEmployeesHandler : IActionHandler<UpdatePaySplitEmployeesAction>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<UpdatePaySplitEmployeesHandler> _logger;

    public UpdatePaySplitEmployeesHandler(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<UpdatePaySplitEmployeesHandler> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdatePaySplitEmployeesActionInput>(actionInstance.InputJson);
        try
        {
            // Given the input for the action, make a call to your API/system
            var response = new ApiResponse<UpdatePaySplitEmployeesActionOutput>();
            response = await _apiClient.UpdatePaySplitConfig($"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/users/{input?.Id}/pay-split-config", input, cancellationToken)
            .ConfigureAwait(false);

            if (!response.IsSuccessful || response.Data == null)
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new []
                    {
                        new Error
                        {
                            Source = new [] { nameof(UpdatePaySplitEmployeesHandler) },
                            Text = response.RawResult is { Position: 0, Length: > 0 } ? await new StreamReader(response.RawResult).ReadToEndAsync(cancellationToken) : "Request to target system failed"
                        }
                    }
                });

            return ActionHandlerOutcome.Successful(response.Data, new List<CacheSyncCollection>());
        }
        catch (HttpRequestException exception)
        {
            // If an error occurs, we want to create a failure result for the action that matches
            // the failure type for the action. 
            // Common to create extension methods to map to Standard Action Failure
            var errorSource = new List<string> { nameof(UpdatePaySplitEmployeesHandler) };
            if (string.IsNullOrEmpty(exception.Source)) errorSource.Add(exception.Source!);
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new []
                {
                    new Xchange.Connector.SDK.Action.Error
                    {
                        Source = errorSource.ToArray(),
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
