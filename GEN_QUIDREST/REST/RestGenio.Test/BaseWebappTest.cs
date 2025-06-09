
using RESTGenio.Auth;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace RestTest;

public class BaseWebappTest
{
    protected readonly WebApplicationFactory<Program> _factory;
    protected readonly JsonSerializerOptions _jsonop;

    protected string? _authToken;

    public BaseWebappTest()
    {
        _factory = new WebApplicationFactory<Program>();
        _jsonop = new JsonSerializerOptions();
        _jsonop.Converters.Add(new JsonStringEnumConverter());
        _jsonop.PropertyNameCaseInsensitive = true;
    }

    protected async Task Authenticate(HttpClient _client)
    {
        if (_authToken == null)
        {
            var res = await _client.PostAsJsonAsync("Auth/Login", new LoginRequest()
            {
                username = "quidgest",
                password = "zph2lab",
                year = "0",
                timeout = 50
            }, _jsonop);
            if (!res.IsSuccessStatusCode)
                throw new Exception("Authentication failed");
            var login = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop)
                ?? throw new Exception("Authentication token could not be deserialized");
            _authToken = login.token;
        }
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
    }

    protected MultipartFormDataContent CreateUploadFileContent(Stream stream, string filename)
    {
        var boundary = Guid.NewGuid().ToString();
        var content = new MultipartFormDataContent(boundary);
        content.Headers.Remove("Content-Type");
        content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
        var content_file = new StreamContent(stream);
        content_file.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
        content.Add(content_file, "file", filename);
        return content;
    }
}


public static class ExtraHttpClientExtensions
{
    public static async Task<HttpResponseMessage> DeleteAsJsonBodyAsync<T>(this HttpClient client, string? requestUri, T? body, JsonSerializerOptions? jsonOptions = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);

        if (body != null)
        {
            var json_ = JsonSerializer.Serialize(body, jsonOptions);
            var content = new StringContent(json_);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            request.Content = content;
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));
        }

        return await client.SendAsync(request);
    }
}
