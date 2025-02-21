namespace Connector.User.v1;
using Connector.User.v1.Employees.Create;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("User V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class UserV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateEmployeesConfig { get; set; } = new();
}