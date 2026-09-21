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

namespace Connector.App.v1.Timesheet.Create;

public class CreateTimesheetHandler : IActionHandler<CreateTimesheetAction>
{
    private readonly ILogger<CreateTimesheetHandler> _logger;

    private readonly ConnectorRegistrationConfig _connectorRegistrationConfig;

    private readonly ApiClient _apiClient;

    public CreateTimesheetHandler(
        ILogger<CreateTimesheetHandler> logger,
        ApiClient apiClient,
        ConnectorRegistrationConfig connectorRegistrationConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectorRegistrationConfig = connectorRegistrationConfig;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating timesheet");
        _logger.LogInformation("ActionInstance: {ActionInstance}", actionInstance.InputJson);
        var input = JsonSerializer.Deserialize<CreateTimesheetActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = [new Error { Source = ["CreateTimesheetHandler"], Text = "Invalid input" }]
            });
        }
        try
        {
            // Given the input for the action, make a call to your API/system
            var response = new ApiResponse<CreateTimesheetActionOutput>();
            response = await _apiClient.CreateTimesheet(
                $"api/v1/companies/{_connectorRegistrationConfig.CompanyId}/timesheets",
                input,
                cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessful || response.Data == null)
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new []
                    {
                        new Error
                        {
                            Source = new [] { nameof(CreateTimesheetHandler) },
                            Text = response.RawResult is { CanRead: true, Position: 0, Length: > 0 } ? await new StreamReader(response.RawResult).ReadToEndAsync(cancellationToken) : "Request to target system failed"
                        }
                    }
                });

            // The full record is needed for SyncOperations. If the endpoint used for the action returns a partial record (such as only returning the ID) then you can either:
            // - Make a GET call using the ID that was returned
            // - Add the ID property to your action input (Assuming this results in the proper data object shape)

            // var resource = await _apiClient.GetTimesheetDataObject(response.Data.id, cancellationToken);

            // var resource = new CreateTimesheetActionOutput
            // {
            //      TODO : map
            // };

            // If the response is already the output object for the action, you can use the response directly

            // Build sync operations to update the local cache as well as the Xchange cache system (if the data type is cached)
            // For more information on SyncOperations and the KeyResolver, check: https://trimble-xchange.github.io/connector-docs/guides/creating-actions/#sync-operations-in-detail
            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(response.Data);
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, response.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new CacheSyncCollection() { DataObjectType = typeof(TimesheetDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            // If an error occurs, we want to create a failure result for the action that matches
            // the failure type for the action. 
            // Common to create extension methods to map to Standard Action Failure
            var errorSource = new List<string> { nameof(CreateTimesheetHandler) };
            if (!string.IsNullOrEmpty(exception.Source)) errorSource.Add(exception.Source);
            
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
