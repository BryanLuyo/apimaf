using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Apimaf.WebAPI.Tests;

public class EndpointTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public EndpointTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetConcesionarios_ReturnsOk()
    {
        var response = await _client.GetAsync("/concesionarios");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var data = await response.Content.ReadFromJsonAsync<List<object>>();
        Assert.NotNull(data);
        Assert.NotEmpty(data!);
    }

    [Fact]
    public async Task GetSucursales_ReturnsOk()
    {
        var response = await _client.GetAsync("/concesionarios/1/sucursales");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var data = await response.Content.ReadFromJsonAsync<List<object>>();
        Assert.NotNull(data);
        Assert.NotEmpty(data!);
    }
}
