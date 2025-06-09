using RESTGenio;
using RESTGenio.Auth;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestTest;

[TestFixture]
public class UnitTestXRSAuth
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly JsonSerializerOptions _jsonop;

    public UnitTestXRSAuth()
    {
        _factory = new WebApplicationFactory<Program>();
        _jsonop = new JsonSerializerOptions();
        _jsonop.Converters.Add(new JsonStringEnumConverter());
    }

    [Test]
    public async Task LoginCorrect()
    {
        var _client = _factory.CreateClient();
        var res = await _client.PostAsJsonAsync("Auth/Login", new LoginRequest()
        {
            username = "quidgest",
            password = "zph2lab",
            year = "0",
            timeout = 50
        });
        var main = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop);
        Assert.That(main, Is.Not.Null);
        Assert.That(main.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(main.token, Is.Not.Null);
    }


    [Test]
    public async Task LoginIncorrectPassword()
    {
        var _client = _factory.CreateClient();
        var res = await _client.PostAsJsonAsync("Auth/Login", new LoginRequest()
        {
            username = "quidgest",
            password = "wrong",
            year = "0",
            timeout = 50
        });
        var main = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop);
        Assert.That(main, Is.Not.Null);
        Assert.That(main.status, Is.EqualTo(RESTStatus.Error));
        Assert.That(main.token, Is.Empty);
    }

    [Test]
    public async Task LoginUnknownUser()
    {
        var _client = _factory.CreateClient();
        var res = await _client.PostAsJsonAsync("Auth/Login", new LoginRequest()
        {
            username = "xpto",
            password = "any",
            year = "0",
            timeout = 50
        });
        var main = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop);
        Assert.That(main, Is.Not.Null);
        Assert.That(main.status, Is.EqualTo(RESTStatus.Error));
        Assert.That(main.token, Is.Empty);
    }

    [Test]
    public async Task RefreshToken()
    {
        var _client = _factory.CreateClient();
        var res = await _client.PostAsJsonAsync("Auth/Login", new LoginRequest()
        {
            username = "quidgest",
            password = "zph2lab",
            year = "0",
            timeout = 50
        });
        var main = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop);
        Assert.That(main, Is.Not.Null);
        Assert.That(main.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(main.token, Is.Not.Null);

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", main.token);
        res = await _client.GetAsync("Auth/Refresh");
        var refresh = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop);

        Assert.That(refresh, Is.Not.Null);
        Assert.That(refresh.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(refresh.token, Is.Not.Null);
    }

    [Test]
    public async Task RefuseUnauthenticated()
    {
        var _client = _factory.CreateClient();

        var res = await _client.GetAsync("Auth/Refresh");
        Assert.That(res.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Unauthorized));
    }


    [Test]
    public async Task SecureLeaseRefreshToken()
    {
        var _client = _factory.CreateClient();
        var res = await _client.PostAsJsonAsync("Auth/Login", new LoginRequest()
        {
            username = "quidgest",
            password = "zph2lab",
            year = "0",
            timeout = 50
        });
        var main = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop);
        Assert.That(main, Is.Not.Null);
        Assert.That(main.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(main.token, Is.Not.Null);

        //We request a lease token from the main token
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", main.token);
        res = await _client.GetAsync("Auth/Refresh?lease=true");
        var lease = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop);

        Assert.That(lease, Is.Not.Null);
        Assert.That(lease.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(lease.token, Is.Not.Null);

        //The service should refuse to give us a third token generated from the lease token
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", lease.token);
        res = await _client.GetAsync("Auth/Refresh");
        var invalid = await res.Content.ReadFromJsonAsync<LoginResponse>(_jsonop);

        Assert.That(invalid, Is.Not.Null);
        Assert.That(invalid.status, Is.EqualTo(RESTStatus.Error));
        Assert.That(invalid.token, Is.Empty);
    }

}