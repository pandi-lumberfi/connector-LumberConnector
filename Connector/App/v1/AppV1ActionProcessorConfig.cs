namespace Connector.App.v1;
using Connector.App.v1.CostCode.Create;
using Connector.App.v1.CostCode.Update;
using Connector.App.v1.CostType.Create;
using Connector.App.v1.CostType.Update;
using Connector.App.v1.Employees.Create;
using Connector.App.v1.Employees.Update;
using Connector.App.v1.Project.Create;
using Connector.App.v1.Project.Update;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("App V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class AppV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateEmployeesConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateEmployeesConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateProjectConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateProjectConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostCodeConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCostCodeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostTypeConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCostTypeConfig { get; set; } = new();
}