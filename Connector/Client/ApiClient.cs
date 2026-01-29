using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Connector.App.v1.CostCode.Create;
using Connector.App.v1.CostCode.Update;
using Connector.App.v1.CostType.Create;
using Connector.App.v1.CostType.Update;
using Connector.App.v1.Employees.Create;
using Connector.App.v1.Employees.Update;
using Connector.App.v1.Project.Create;
using Connector.App.v1.Project.Update;
using Connector.App.v1.CompCode.Create;
using Connector.App.v1.CompCode.Update;
using Connector.App.v1.Department.Create;
using Connector.App.v1.Department.Update;
using Connector.App.v1.Branch.Create;
using Connector.App.v1.Task.Create;
using Connector.App.v1.Task.Update;
using Connector.App.v1.Employees.CreatePaystub;
using Connector.App.v1.Employees.AddBankAccount;
using Connector.App.v1.Employees.UpdatePaySplit;
using Connector.App.v1.Employees.UpdateTaxWithHolding;
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
            $"{relativeUrl}?page_no={page}&page_size={size}",
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
        var jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = null, // Use JsonPropertyName attributes instead
            WriteIndented = false,
            Converters = { new DateOnlyJsonConverter(), new DateTimeJsonConverter() }
        };

        var jsonContent = JsonSerializer.Serialize(input, jsonOptions);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync(relativeUrl, content, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new HttpRequestException($"Failed to post employee data. Status Code: {response.StatusCode}. Response: {errorContent}")
            {
                Data = { ["StatusCode"] = response.StatusCode, ["ResponseBody"] = errorContent }
            };
        }

        return new ApiResponse<CreateEmployeesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CreateEmployeesActionOutput>(
                new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = null, WriteIndented = true },cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    private class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString() ?? string.Empty);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }

    private class DateOnlyJsonConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return string.IsNullOrEmpty(value) ? null : DateTime.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
    
    internal async Task<ApiResponse<UpdateEmployeesActionOutput>> UpdateEmployeesDataObject(string relativeUrl, UpdateEmployeesActionInput input, CancellationToken cancellationToken)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = null, // Use JsonPropertyName attributes instead
            WriteIndented = false,
            Converters = { new DateOnlyJsonConverter(), new DateTimeJsonConverter() }
        };

        var jsonContent = JsonSerializer.Serialize(input, jsonOptions);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PatchAsync(relativeUrl, content, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new HttpRequestException($"Failed to update employee data. Status Code: {response.StatusCode}. Response: {errorContent}")
            {
                Data = { ["StatusCode"] = response.StatusCode, ["ResponseBody"] = errorContent }
            };
        }

        return new ApiResponse<UpdateEmployeesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<UpdateEmployeesActionOutput>(
                new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = null, WriteIndented = true },cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<CreatePaystubEmployeesActionOutput>> CreatePaystubEmployeesDataObject(string relativeUrl, CreatePaystubEmployeesActionInput? input, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to post paystub employee data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<CreatePaystubEmployeesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CreatePaystubEmployeesActionOutput>(
                new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true },cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }
    internal async Task<ApiResponse<AddBankAccountEmployeesActionOutput>> AddBankAccount(string relativeUrl, AddBankAccountEmployeesActionInput input, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to add bank account. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<AddBankAccountEmployeesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<AddBankAccountEmployeesActionOutput>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    public async IAsyncEnumerable<BankAccount> GetBankAccounts<BankAccount>(
        string relativeUrl,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync(relativeUrl, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
            
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        await foreach (var record in JsonSerializer.DeserializeAsyncEnumerable<BankAccount>(stream))
        {
            if (record == null)
            {
                continue;
            }
            
            yield return record;
        }
    }

    public async IAsyncEnumerable<UserBenefit> GetUserBenefits<UserBenefit>(
        string relativeUrl, 
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync(relativeUrl, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
            
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        await foreach (var record in JsonSerializer.DeserializeAsyncEnumerable<UserBenefit>(stream))
        {
            if (record == null)
            {
                continue;
            }
            
            yield return record;
        }
    }

    public async IAsyncEnumerable<UserPayRate> GetUserPayRates<UserPayRate>(
        string relativeUrl,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync(relativeUrl, cancellationToken: cancellationToken)    
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        await foreach (var record in JsonSerializer.DeserializeAsyncEnumerable<UserPayRate>(stream))    
        {
            if (record == null)
            {
                continue;
            }
            
            yield return record;
        }
    }

    public async IAsyncEnumerable<UserTaxWithHolding> GetUserTaxWithHoldings<UserTaxWithHolding>(
        string relativeUrl,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync(relativeUrl, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        await foreach (var record in JsonSerializer.DeserializeAsyncEnumerable<UserTaxWithHolding>(stream))     
        {
            if (record == null)
            {
                continue;
            }
            
            yield return record;
        }
    }

    public async Task<UserLeaveBalance?> GetUserLeaveBalance<UserLeaveBalance>(
        string relativeUrl,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync(relativeUrl, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UserLeaveBalance>(cancellationToken: cancellationToken);
    }

    public async IAsyncEnumerable<CompCode> GetCompCodes<CompCode>(
        string relativeUrl, 
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync(relativeUrl, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
            
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        await foreach (var record in JsonSerializer.DeserializeAsyncEnumerable<CompCode>(stream))
        {
            if (record == null)
            {
                continue;
            }
            
            yield return record;
        }
    }

    public async IAsyncEnumerable<JobCode> GetJobCodes<JobCode>(
        string relativeUrl, 
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync(relativeUrl, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
            
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        await foreach (var record in JsonSerializer.DeserializeAsyncEnumerable<JobCode>(stream))
        {
            if (record == null)
            {
                continue;
            }
            
            yield return record;
        }
    }

    public async Task<ApiResponse<PaginatedResponse<ProjectDataObject>>> GetProjectRecords<ProjectDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page_no={page}&page_size={size}",
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
            $"{relativeUrl}?page_no={page}&page_size={size}",
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
            $"{relativeUrl}?page_no={page}&page_size={size}",
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

    internal async Task<ApiResponse<PaginatedResponse<TimesheetDataObject>>> GetTimesheetRecords<TimesheetDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page_no={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to get timesheet records. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<PaginatedResponse<TimesheetDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<TimesheetDataObject>>(
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

    internal async Task<ApiResponse<PaginatedResponse<CompCodeDataObject>>> GetCompCodeRecords<CompCodeDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {   
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page_no={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse<PaginatedResponse<CompCodeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<CompCodeDataObject>>(
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

    internal async Task<ApiResponse<CreateCompCodeActionOutput>> CreateCompCodeDataObject(
        string relativeUrl,
        CreateCompCodeActionInput input,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);    
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to create comp code data. Status Code: {response.StatusCode}");
        }
        
        return new ApiResponse<CreateCompCodeActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateCompCodeActionOutput>(
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

    internal async Task<ApiResponse<UpdateCompCodeActionOutput>> UpdateCompCodeDataObject(
        string relativeUrl,
        UpdateCompCodeActionInput input,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PatchAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update comp code data. Status Code: {response.StatusCode}");
        }
        
        return new ApiResponse<UpdateCompCodeActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<UpdateCompCodeActionOutput>(
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

    internal async Task<ApiResponse<PaginatedResponse<DepartmentDataObject>>> GetDepartments<DepartmentDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {   
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page_no={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse<PaginatedResponse<DepartmentDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<DepartmentDataObject>>(
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

    internal async Task<ApiResponse<CreateDepartmentActionOutput>> CreateDepartmentDataObject(
        string relativeUrl,
        CreateDepartmentActionInput input,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)      
        {
            throw new HttpRequestException($"Failed to create department data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<CreateDepartmentActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CreateDepartmentActionOutput>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }    

    internal async Task<ApiResponse<UpdateDepartmentActionOutput>> UpdateDepartmentDataObject(
        string relativeUrl,
        UpdateDepartmentActionInput input,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update department data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<UpdateDepartmentActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<UpdateDepartmentActionOutput>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<PaginatedResponse<BranchDataObject>>> GetBranches<BranchDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {   
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page_no={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
            
        return new ApiResponse<PaginatedResponse<BranchDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<PaginatedResponse<BranchDataObject>>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<CreateBranchActionOutput>> CreateBranch(string relativeUrl, CreateBranchActionInput input, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to create branch data. Status Code: {response.StatusCode}");    
        }

        return new ApiResponse<CreateBranchActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CreateBranchActionOutput>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<PaginatedResponse<TaskDataObject>>> GetTasks<TaskDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page_no={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse<PaginatedResponse<TaskDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<PaginatedResponse<TaskDataObject>>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }   

    internal async Task<ApiResponse<CreateTaskActionOutput>> CreateTask(string relativeUrl, CreateTaskActionInput input, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to create task data. Status Code: {response.StatusCode}");  
        }

        return new ApiResponse<CreateTaskActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,  
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CreateTaskActionOutput>(cancellationToken: cancellationToken) : default, 
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<UpdateTaskActionOutput>> UpdateTask(string relativeUrl, UpdateTaskActionInput input, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PatchAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update task data. Status Code: {response.StatusCode}");
        }   

        return new ApiResponse<UpdateTaskActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<UpdateTaskActionOutput>(cancellationToken: cancellationToken) : default, 
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)  
        };
    }
    public async Task<ApiResponse<PaginatedResponse<DeductionDataObject>>> GetDeductionRecords<DeductionDataObject>(
        string relativeUrl,
        int page,
        int size,
        CancellationToken cancellationToken = default)
    {   
        var response = await _httpClient.GetAsync(
            $"{relativeUrl}?page_no={page}&page_size={size}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
            
        return new ApiResponse<PaginatedResponse<DeductionDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<PaginatedResponse<DeductionDataObject>>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }
    public async Task<List<UserDemographicsDataObject>> GetUserDemographics<UserDemographicsDataObject>(
        string relativeUrl,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync(relativeUrl, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var userDemographicsDataObjects = new List<UserDemographicsDataObject>();
        
        var jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        
        await foreach (var record in JsonSerializer.DeserializeAsyncEnumerable<UserDemographicsDataObject>(stream, jsonOptions, cancellationToken))
        {
            if (record == null)
            {
                continue;
            }
            
            userDemographicsDataObjects.Add(record);
        }
        
        return userDemographicsDataObjects;
    }

    internal async Task<ApiResponse<UpdatePaySplitEmployeesActionOutput>> UpdatePaySplitConfig(string relativeUrl, UpdatePaySplitEmployeesActionInput? input, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to update pay split config. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<UpdatePaySplitEmployeesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<UpdatePaySplitEmployeesActionOutput>(
                new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true },cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    internal async Task<ApiResponse<UpdateTaxWithHoldingEmployeesActionOutput>> UpdateTaxWithHoldingConfig(string relativeUrl, UpdateTaxWithHoldingEmployeesActionInput? input, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(relativeUrl, input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to post tax with holding employee data. Status Code: {response.StatusCode}");
        }

        return new ApiResponse<UpdateTaxWithHoldingEmployeesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<UpdateTaxWithHoldingEmployeesActionOutput>(
                new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true },cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }
}
