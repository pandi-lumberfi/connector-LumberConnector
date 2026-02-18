using Microsoft.Extensions.DependencyInjection;
using System;
using Xchange.Connector.SDK.Client.ConnectivityApi.Models;
using ESR.Hosting.Client;
using System.Text.Json;
using Xchange.Connector.SDK.Client.AuthTypes;
using Connector.Connections;

namespace Connector.Client
{
    public static class ClientHelper
    {
        public static class AuthTypeKeyEnums
        {
            public const string CustomAuth = "customAuth";
        }

        public static void ResolveServices(this IServiceCollection serviceCollection, ConnectionContainer activeConnection)
        {
            serviceCollection.AddTransient<RetryPolicyHandler>();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            switch (activeConnection.DefinitionKey)
            {
                case AuthTypeKeyEnums.CustomAuth:
                    var configCustomAuth = JsonSerializer.Deserialize<CustomAuth>(activeConnection.Configuration, options);
                    serviceCollection.AddSingleton<CustomAuth>(configCustomAuth!);
                    serviceCollection.AddTransient<RetryPolicyHandler>();
                    serviceCollection.AddTransient<CustomAuthHandler>();
                    serviceCollection.AddHttpClient<ApiClient, ApiClient>(client =>
                    {
                        // Employee report (user demographics) can be large; default 100s is insufficient.
                        client.Timeout = TimeSpan.FromMinutes(10);
                        return new ApiClient(client, configCustomAuth!.BaseUrl);
                    }).AddHttpMessageHandler<CustomAuthHandler>().AddHttpMessageHandler<RetryPolicyHandler>();
                    break;
                default:
                    throw new Exception($"Unable to find services for definition key {activeConnection.DefinitionKey}");
            }
        }
    }
}