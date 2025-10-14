using System;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Connector.Connections;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http.Json;

namespace Connector.Client;

public class CustomAuthHandler(CustomAuth customAuth) : DelegatingHandler
{
    private readonly CustomAuth _customAuth = customAuth;
    private readonly SemaphoreSlim _tokenSemaphore = new(1, 1);
    private string? _token;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        await GetAuthToken(request, cancellationToken);
        return await base.SendAsync(request, cancellationToken);
    }

    private async Task GetAuthToken(HttpRequestMessage request, CancellationToken cancellationToken, bool refresh = false)
    {
        if (string.IsNullOrEmpty(_token) || refresh)
        {
            try
            {
                var previousToken = _token;
                await _tokenSemaphore.WaitAsync(cancellationToken);
                if (previousToken != _token)
                {
                    request.Headers.Add("Api-Key", _customAuth.ApiKey);
                    request.Headers.Add("Api-Secret", _customAuth.ApiSecretKey);
                    request.Headers.Add("User-Id", _customAuth.UserId);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                    return;
                }

                var response = await base.SendAsync(GetTokenRequest(), cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    var tokenRespose = await response.Content.ReadFromJsonAsync<JsonDocument>(cancellationToken: cancellationToken) ?? 
                        throw new JsonException("Error deserializing authentication JSON response while retrieving token");

                    _token = tokenRespose.RootElement.GetProperty("access_token").GetString();

                    if (_token == null)
                    {
                        throw new InvalidOperationException("Response did not contain an 'access_token' property.");
                    } 
                }
                else
                {
                    _token = null;
                }
            }
            finally
            {
                _tokenSemaphore.Release();
            }
        }
        request.Headers.Add("Api-Key", _customAuth.ApiKey);
        request.Headers.Add("Api-Secret", _customAuth.ApiSecretKey);
        request.Headers.Add("User-Id", _customAuth.UserId);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
    }

    private HttpRequestMessage GetTokenRequest()
    {
        var url = _customAuth.BaseUrl + "api/auth/login";
        var tokenRequest = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Headers =
                {
                    {"Api-Key", $"{_customAuth.ApiKey}"} ,
                    {"Api-Secret", $"{_customAuth.ApiSecretKey}"},
                    {"User-Id", $"{_customAuth.UserId}"}
                }
        };
        return tokenRequest;
    }
}