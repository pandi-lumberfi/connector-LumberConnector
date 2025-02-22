using System;
using Xchange.Connector.SDK.Client.AuthTypes;
using Xchange.Connector.SDK.Client.ConnectionDefinitions.Attributes;

namespace Connector.Connections;

[ConnectionDefinition(title: "CustomAuth", description: "CustomAuth Connection")]
public class CustomAuth : ICustomAuth
{
    //Create your own properties here like this (keep in mind only string types are supported currently):
    //[ConnectionProperty(title: "Custom Header", description: "", isRequired: true, isSensitive: false)]
    //public string CustomHeader { get; init; } = string.Empty;
    [ConnectionProperty(title: "Api Key", description: "A unique key used to authenticate and authorize API requests", isRequired: true, isSensitive: false)]
    public string ApiKey { get; init; } = string.Empty;

    [ConnectionProperty(title: "Api Secret Key", description: "A unique secret key used for authenticating API request", isRequired: true, isSensitive: false)]
    public string ApiSecretKey { get; init; } = string.Empty;

    [ConnectionProperty(title: "User Id", description: "Admin User ID for establishing the connection", isRequired: true, isSensitive: false)]
    public string UserId { get; init; } = string.Empty;

    [ConnectionProperty(title: "Connection Environment", description: "Connection Environment", isRequired: true, isSensitive: false)]
    public ConnectionEnvironmentCustomAuth ConnectionEnvironment { get; set; } = ConnectionEnvironmentCustomAuth.Unknown;

    public string BaseUrl
    {
        get
        {
            switch (ConnectionEnvironment)
            {
                case ConnectionEnvironmentCustomAuth.Production:
                    return "https://integration.lumberfi.com/";
                case ConnectionEnvironmentCustomAuth.Stage:
                    return "https://stage-integration.lumberfi.com/";
                case ConnectionEnvironmentCustomAuth.QA:
                    return "https://qa-integration.lumberfi.com/";
                case ConnectionEnvironmentCustomAuth.Develop:
                    return "https://dev-integration.lumberfi.com/";
                default:
                    throw new Exception("No base url was set.");
            }
        }
    }
}

public enum ConnectionEnvironmentCustomAuth
{
    Unknown = 0,
    Production = 1,
    Stage = 2,
    QA = 3,
    Develop = 4
}