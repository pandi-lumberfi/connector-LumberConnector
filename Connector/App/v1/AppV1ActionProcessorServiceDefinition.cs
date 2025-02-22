namespace Connector.App.v1;
using Connector.App.v1.CostCode;
using Connector.App.v1.CostCode.Create;
using Connector.App.v1.CostCode.Update;
using Connector.App.v1.CostType;
using Connector.App.v1.CostType.Create;
using Connector.App.v1.CostType.Update;
using Connector.App.v1.Employees;
using Connector.App.v1.Employees.Create;
using Connector.App.v1.Employees.Update;
using Connector.App.v1.Project;
using Connector.App.v1.Project.Create;
using Connector.App.v1.Project.Update;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class AppV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<AppV1ActionProcessorConfig>
{
    public override string ModuleId => "app-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<AppV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<AppV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<AppV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<AppV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<AppV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateEmployeesHandler>();
        serviceCollection.AddScoped<UpdateEmployeesHandler>();
        serviceCollection.AddScoped<CreateProjectHandler>();
        serviceCollection.AddScoped<UpdateProjectHandler>();
        serviceCollection.AddScoped<CreateCostCodeHandler>();
        serviceCollection.AddScoped<UpdateCostCodeHandler>();
        serviceCollection.AddScoped<CreateCostTypeHandler>();
        serviceCollection.AddScoped<UpdateCostTypeHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, AppV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateEmployeesHandler, EmployeesDataObject>(ModuleId, "employees", "create", config.CreateEmployeesConfig);
        service.RegisterHandlerForDataObjectAction<UpdateEmployeesHandler, EmployeesDataObject>(ModuleId, "employees", "update", config.UpdateEmployeesConfig);
        service.RegisterHandlerForDataObjectAction<CreateProjectHandler, ProjectDataObject>(ModuleId, "project", "create", config.CreateProjectConfig);
        service.RegisterHandlerForDataObjectAction<UpdateProjectHandler, ProjectDataObject>(ModuleId, "project", "update", config.UpdateProjectConfig);
        service.RegisterHandlerForDataObjectAction<CreateCostCodeHandler, CostCodeDataObject>(ModuleId, "cost-code", "create", config.CreateCostCodeConfig);
        service.RegisterHandlerForDataObjectAction<UpdateCostCodeHandler, CostCodeDataObject>(ModuleId, "cost-code", "update", config.UpdateCostCodeConfig);
        service.RegisterHandlerForDataObjectAction<CreateCostTypeHandler, CostTypeDataObject>(ModuleId, "cost-type", "create", config.CreateCostTypeConfig);
        service.RegisterHandlerForDataObjectAction<UpdateCostTypeHandler, CostTypeDataObject>(ModuleId, "cost-type", "update", config.UpdateCostTypeConfig);
    }
}