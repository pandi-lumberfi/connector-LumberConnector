namespace Connector.App.v1;
using Connector.App.v1.Branch;
using Connector.App.v1.ChartOfAccount;
using Connector.App.v1.CompCode;
using Connector.App.v1.CostCode;
using Connector.App.v1.CostType;
using Connector.App.v1.Deduction;
using Connector.App.v1.Department;
using Connector.App.v1.Employees;
using Connector.App.v1.Journal;
using Connector.App.v1.Project;
using Connector.App.v1.Task;
using Connector.App.v1.Timesheet;
using Connector.App.v1.UserDemographics;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class AppV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<AppV1CacheWriterConfig>
{
    public override string ModuleId => "app-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<AppV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<AppV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<AppV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<AppV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<AppV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<EmployeesDataReader>();
        serviceCollection.AddSingleton<ProjectDataReader>();
        serviceCollection.AddSingleton<CostCodeDataReader>();
        serviceCollection.AddSingleton<CostTypeDataReader>();
        serviceCollection.AddSingleton<TimesheetDataReader>();
        serviceCollection.AddSingleton<CompCodeDataReader>();
        serviceCollection.AddSingleton<DepartmentDataReader>();
        serviceCollection.AddSingleton<BranchDataReader>();
        serviceCollection.AddSingleton<TaskDataReader>();
        serviceCollection.AddSingleton<DeductionDataReader>();
        serviceCollection.AddSingleton<UserDemographicsDataReader>();
        serviceCollection.AddSingleton<ChartOfAccountDataReader>();
        serviceCollection.AddSingleton<JournalDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<EmployeesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ProjectDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCodeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostTypeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<TimesheetDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CompCodeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<DepartmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BranchDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<TaskDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<DeductionDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UserDemographicsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ChartOfAccountDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JournalDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, AppV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<EmployeesDataReader, EmployeesDataObject>(ModuleId, config.EmployeesConfig, dataReaderSettings);
        service.RegisterDataReader<ProjectDataReader, ProjectDataObject>(ModuleId, config.ProjectConfig, dataReaderSettings);
        service.RegisterDataReader<CostCodeDataReader, CostCodeDataObject>(ModuleId, config.CostCodeConfig, dataReaderSettings);
        service.RegisterDataReader<CostTypeDataReader, CostTypeDataObject>(ModuleId, config.CostTypeConfig, dataReaderSettings);
        service.RegisterDataReader<TimesheetDataReader, TimesheetDataObject>(ModuleId, config.TimesheetConfig, dataReaderSettings);
        service.RegisterDataReader<CompCodeDataReader, CompCodeDataObject>(ModuleId, config.CompCodeConfig, dataReaderSettings);
        service.RegisterDataReader<DepartmentDataReader, DepartmentDataObject>(ModuleId, config.DepartmentConfig, dataReaderSettings);
        service.RegisterDataReader<BranchDataReader, BranchDataObject>(ModuleId, config.BranchConfig, dataReaderSettings);
        service.RegisterDataReader<TaskDataReader, TaskDataObject>(ModuleId, config.TaskConfig, dataReaderSettings);
        service.RegisterDataReader<DeductionDataReader, DeductionDataObject>(ModuleId, config.DeductionConfig, dataReaderSettings);
        service.RegisterDataReader<UserDemographicsDataReader, UserDemographicsDataObject>(ModuleId, config.UserDemographicsConfig, dataReaderSettings);
        service.RegisterDataReader<ChartOfAccountDataReader, ChartOfAccountDataObject>(ModuleId, config.ChartOfAccountConfig, dataReaderSettings);
        service.RegisterDataReader<JournalDataReader, JournalDataObject>(ModuleId, config.JournalConfig, dataReaderSettings);
    }
}