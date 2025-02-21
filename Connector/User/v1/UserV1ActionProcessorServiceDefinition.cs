namespace Connector.User.v1;
using Connector.User.v1.Employees;
using Connector.User.v1.Employees.Create;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class UserV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<UserV1ActionProcessorConfig>
{
    public override string ModuleId => "user-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<UserV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<UserV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<UserV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<UserV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<UserV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateEmployeesHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, UserV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateEmployeesHandler, EmployeesDataObject>(ModuleId, "employees", "create", config.CreateEmployeesConfig);
    }
}