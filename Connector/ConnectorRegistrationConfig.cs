using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Connector;

/// <summary>
/// Contains all configuration values necessary for execution of the connector, that are configurable by a connector implementation.
/// </summary>
public class ConnectorRegistrationConfig
{
    [JsonPropertyName("CompanyId")]
    [Required]
    public required string CompanyId { get; init; }
}
