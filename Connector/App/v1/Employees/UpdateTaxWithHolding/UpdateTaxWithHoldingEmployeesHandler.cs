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

namespace Connector.App.v1.Employees.UpdateTaxWithHolding;

public class UpdateTaxWithHoldingEmployeesHandler : IActionHandler<UpdateTaxWithHoldingEmployeesAction>
{
    private readonly ApiClient _apiClient;
    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;
    private readonly ILogger<UpdateTaxWithHoldingEmployeesHandler> _logger;

    public UpdateTaxWithHoldingEmployeesHandler(
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig,
        ILogger<UpdateTaxWithHoldingEmployeesHandler> logger)
    {
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
        _logger = logger;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateTaxWithHoldingEmployeesActionInput>(actionInstance.InputJson);
        try
        {
            // Given the input for the action, make a call to your API/system
            var response = new ApiResponse<UpdateTaxWithHoldingEmployeesActionOutput>();
            response = await _apiClient.UpdateTaxWithHoldingConfig($"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/users/{input?.UserId}/tax-with-holdings", input, cancellationToken)
            .ConfigureAwait(false);

            if (!response.IsSuccessful || response.Data == null)
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new []
                    {
                        new Error
                        {
                            Source = new [] { nameof(UpdateTaxWithHoldingEmployeesHandler) },
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
            var errorSource = new List<string> { nameof(UpdateTaxWithHoldingEmployeesHandler) };
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
