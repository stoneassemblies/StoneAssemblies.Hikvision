namespace StoneAssemblies.Hikvision.Services;

using System.Net.Mime;
using System.Text;

using Newtonsoft.Json;

using StoneAssemblies.Hikvision.Models;
using StoneAssemblies.Hikvision.Serialization;

public static class HttpClientExtensions
{
    private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new HikvisionJsonContractResolver(),
        NullValueHandling = NullValueHandling.Ignore
    };

    public static async Task<TResponse> PostAsync<TRequest, TResponse>(this HttpClient httpClient, string requestUri, TRequest request)
    {
        var content = new HikvisionJsonContent<TRequest>
        {
            Content = request
        };

        var serializeObject = JsonConvert.SerializeObject(content, JsonSerializerSettings);
        var stringContent = new StringContent(serializeObject, Encoding.UTF8, MediaTypeNames.Application.Json);

        var httpResponseMessage = await httpClient.PostAsync(requestUri, stringContent);
        httpResponseMessage.EnsureSuccessStatusCode();

        var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();

        // TODO: Check this later.
        var hikvisionJsonContent = JsonConvert.DeserializeObject<HikvisionJsonContent<TResponse>>(responseContentString, JsonSerializerSettings);
        return hikvisionJsonContent!.Content!;
    }


    public static async Task<TResponse> PutAsync<TRequest, TResponse>(this HttpClient httpClient, string requestUri, TRequest request)
    {
        var content = new HikvisionJsonContent<TRequest>
        {
            Content = request
        };

        var serializeObject = JsonConvert.SerializeObject(content, JsonSerializerSettings);
        var stringContent = new StringContent(serializeObject, Encoding.UTF8, MediaTypeNames.Application.Json);

        var httpResponseMessage = await httpClient.PutAsync(requestUri, stringContent);
        httpResponseMessage.EnsureSuccessStatusCode();

        var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();

        // TODO: Check this later.
        var hikvisionJsonContent = JsonConvert.DeserializeObject<HikvisionJsonContent<TResponse>>(responseContentString, JsonSerializerSettings);
        return hikvisionJsonContent!.Content!;
    }

    public static async Task<ResponseStatus> PutAsync<TRequest>(this HttpClient httpClient, string requestUri, TRequest request)
    {
        var content = new HikvisionJsonContent<TRequest>
        {
            Content = request
        };

        var serializeObject = JsonConvert.SerializeObject(content, JsonSerializerSettings);
        var stringContent = new StringContent(serializeObject, Encoding.UTF8, MediaTypeNames.Application.Json);

        var httpResponseMessage = await httpClient.PutAsync(requestUri, stringContent);
        httpResponseMessage.EnsureSuccessStatusCode();

        var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();

        // TODO: Check this later.
        return JsonConvert.DeserializeObject<ResponseStatus> (responseContentString, JsonSerializerSettings);
    }

    public static async Task<ResponseStatus> PostAsync<TRequest>(this HttpClient httpClient, string requestUri, TRequest request)
    {
        var content = new HikvisionJsonContent<TRequest>
        {
            Content = request
        };

        var serializeObject = JsonConvert.SerializeObject(content, JsonSerializerSettings);
        var stringContent = new StringContent(serializeObject, Encoding.UTF8, MediaTypeNames.Application.Json);

        var httpResponseMessage = await httpClient.PostAsync(requestUri, stringContent);
        httpResponseMessage.EnsureSuccessStatusCode();

        var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();

        // TODO: Check this later.
        return JsonConvert.DeserializeObject<ResponseStatus> (responseContentString, JsonSerializerSettings);
    }
}