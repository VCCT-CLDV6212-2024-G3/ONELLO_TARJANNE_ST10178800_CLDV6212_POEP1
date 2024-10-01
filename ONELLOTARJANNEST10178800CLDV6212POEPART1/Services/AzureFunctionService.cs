using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class AzureFunctionService
{
    private readonly HttpClient _httpClient;

    public AzureFunctionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // StoreTableInfo Function
    public async Task<string> StoreTableInfo(string tableName, string partitionKey, string rowKey, string data)
    {
        var url = "https://st10178800-p2.azurewebsites.net/api/StoreTableInfo?code=xASYlgpX6sF-v5glMF3iHLLeSbszJH08E0pTvKZ6miyHAzFu4ShEpA%3D%3D";

        var content = new StringContent(
            $"tableName={tableName}&partitionKey={partitionKey}&rowKey={rowKey}&data={data}", 
            Encoding.UTF8, 
            "application/x-www-form-urlencoded"
        );

        try
        {
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode(); 
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            return $"HttpRequestException: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    // UploadBlob Function
    public async Task<string> UploadBlob(string containerName, string blobName, Stream blobStream)
    {
        var url = "https://st10178800-p2.azurewebsites.net/api/UploadBlob?code=fGHmb78LIR4Fmo_BorewdTmvn9AZeM7gAOnt_20wRSQGAzFunY-CdQ%3D%3D";

        using var content = new MultipartFormDataContent
        {
            { new StreamContent(blobStream), "blob", blobName }
        };

        try
        {
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            return $"HttpRequestException: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    // ProcessQueueMessage Function
    public async Task<string> ProcessQueueMessage(string queueName, string message)
    {
        var url = "https://st10178800-p2.azurewebsites.net/api/ProcessQueueMessage?code=J6AwkZgC4tiBwxJq_JYi_gPxkRcR3t7foI4D5FqrEOmGAzFuzdyJ6A%3D%3D";

        var content = new StringContent(
            $"queueName={queueName}&message={message}", 
            Encoding.UTF8, 
            "application/x-www-form-urlencoded"
        );

        try
        {
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            return $"HttpRequestException: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    // UploadFile Function
    public async Task<string> UploadFile(string shareName, string fileName, Stream fileStream)
    {
        var url = "https://st10178800-p2.azurewebsites.net/api/UploadFile?code=yMURFX6bBFR8FKTmoUScZ1KuBRJPcFaTXOnlXE1btLigAzFu7bv7IA%3D%3D";

        using var content = new MultipartFormDataContent
        {
            { new StreamContent(fileStream), "file", fileName }
        };

        try
        {
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            return $"HttpRequestException: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}

