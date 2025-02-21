using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Connector.User.v1.Employees.Create;

namespace Connector.Client;

/// <summary>
/// A client for interfacing with the API via the HTTP protocol.
/// </summary>
public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient (HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new System.Uri(baseUrl);
    }

    // Example of a paginated response.
    public async Task<ApiResponse<PaginatedResponse<EmployeesDataObject>>> GetRecords<EmployeesDataObject>(string relativeUrl, int page, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{relativeUrl}?page={page}", cancellationToken: cancellationToken).ConfigureAwait(false);
        Console.WriteLine("response api", response);
        string json = JsonSerializer.Serialize(response);
        Console.WriteLine(json);


        // Log the raw response status
        Console.WriteLine("Response Status: " + response.StatusCode);

        // Read response body as a string
        string jsons = await response.Content.ReadAsStringAsync(cancellationToken);

        // Log the actual response content
        Console.WriteLine("Response Body:");
        Console.WriteLine(jsons);


        return new ApiResponse<PaginatedResponse<EmployeesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<PaginatedResponse<EmployeesDataObject>>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    public async Task<ApiResponse> GetNoContent(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync("no-content", cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    public async Task<ApiResponse> TestConnection(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync($"api/v1/business_types", cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
        };
    }

    internal async Task<ApiResponse<CreateEmployeesActionOutput>> PostEmployeesDataObject(string relativeUrl, CreateEmployeesActionInput? input, CancellationToken cancellationToken)
    {
        // var response = await _httpClient.PostAsync(
        //     "api/v1/companies/caaf4f88-4735-39d0-948f-7eb367c0c3fd/users",
        //     input, cancellationToken
        // );
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);    

        Console.WriteLine("response api", response);
        string json = JsonSerializer.Serialize(response);
        Console.WriteLine(json);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to post employee data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<CreateEmployeesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CreateEmployeesActionOutput>(
                new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true },cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }
}