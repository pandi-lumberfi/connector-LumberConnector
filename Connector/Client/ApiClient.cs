using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Connector.App.v1.CostCode.Create;
using Connector.App.v1.CostCode.Update;
using Connector.App.v1.CostType.Create;
using Connector.App.v1.CostType.Update;
using Connector.App.v1.Employees.Create;
using Connector.App.v1.Employees.Update;
using Connector.App.v1.Project.Create;
using Connector.App.v1.Project.Update;

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

    public async Task<ApiResponse<PaginatedResponse<EmployeesDataObject>>> GetEmployeeRecords<EmployeesDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to get employee records. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<PaginatedResponse<EmployeesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<EmployeesDataObject>>(
                    cancellationToken: cancellationToken)
                : default,
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
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);    
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
    
    internal async Task<ApiResponse<UpdateEmployeesActionOutput>> UpdateEmployeesDataObject(string relativeUrl, UpdateEmployeesActionInput input, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PatchAsJsonAsync(relativeUrl, input, cancellationToken);    
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update employee data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<UpdateEmployeesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<UpdateEmployeesActionOutput>(
                new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true },cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    public async Task<ApiResponse<PaginatedResponse<ProjectDataObject>>> GetProjectRecords<ProjectDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to get project records. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<PaginatedResponse<ProjectDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<ProjectDataObject>>(
                    cancellationToken: cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<CreateProjectActionOutput>> PostProjectDataObject(
        string relativeUrl,
        CreateProjectActionInput input,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            relativeUrl,
            input,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to post project data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<CreateProjectActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateProjectActionOutput>(
                    new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = true
                    },
                    cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<UpdateProjectActionOutput>> UpdateProjectDataObject(
        string relativeUrl,
        UpdateProjectActionInput input,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PatchAsJsonAsync(
            relativeUrl,
            input,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update project data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<UpdateProjectActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<UpdateProjectActionOutput>(
                    cancellationToken: cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<PaginatedResponse<CostCodeDataObject>>> GetCostCodeRecords<CostCodeDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to get cost code records. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<PaginatedResponse<CostCodeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<CostCodeDataObject>>(
                    new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = true
                    },
                    cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<CreateCostCodeActionOutput>> CreateCostCodeDataObject(
        string relativeUrl,
        CreateCostCodeActionInput input,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            relativeUrl,
            input,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to create cost code data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<CreateCostCodeActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateCostCodeActionOutput>(
                    new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = true
                    },
                    cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<UpdateCostCodeActionOutput>> UpdateCostCodeDataObject(
        string relativeUrl,
        UpdateCostCodeActionInput input,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PatchAsJsonAsync(
            relativeUrl,
            input,
            cancellationToken);

        return new ApiResponse<UpdateCostCodeActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<UpdateCostCodeActionOutput>(
                    new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = true
                    },
                    cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<PaginatedResponse<CostTypeDataObject>>> GetCostTypeRecords<CostTypeDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken)
    {   
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse<PaginatedResponse<CostTypeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<CostTypeDataObject>>(
                    new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = true
                    },
                    cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<UpdateCostTypeActionOutput>> UpdateCostTypeDataObject(
        string relativeUrl, 
        UpdateCostTypeActionInput input, 
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PatchAsJsonAsync(
            relativeUrl,
            input,
            cancellationToken);

        return new ApiResponse<UpdateCostTypeActionOutput>      
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<UpdateCostTypeActionOutput>(
                    cancellationToken: cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<CreateCostTypeActionOutput>> CreateCostTypeDataObject(
        string relativeUrl, 
        CreateCostTypeActionInput input, 
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            relativeUrl,
            input,
            cancellationToken);

        return new ApiResponse<CreateCostTypeActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateCostTypeActionOutput>(
                    cancellationToken: cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)  
        };
    }

    internal async Task<ApiResponse<IEnumerable<TimesheetDataObject>>> GetTimesheetRecords<TimesheetDataObject>(
        string relativeUrl,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            relativeUrl,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to get timesheet records. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<IEnumerable<TimesheetDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<TimesheetDataObject>>(
                    cancellationToken: cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }
}
