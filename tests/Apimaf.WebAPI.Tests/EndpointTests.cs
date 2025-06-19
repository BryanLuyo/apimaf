using System.Net;
using System.Net.Http.Json;
using Apimaf.WebAPI;
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

        var wrapper = await response.Content.ReadFromJsonAsync<ApiResponse<List<object>>>();
        Assert.NotNull(wrapper);
        Assert.NotNull(wrapper!.Data);
        Assert.NotEmpty(wrapper.Data!);
    }

    [Fact]
    public async Task GetSucursales_ReturnsOk()
    {
        var response = await _client.GetAsync("/concesionarios/1/sucursales");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var wrapper = await response.Content.ReadFromJsonAsync<ApiResponse<List<object>>>();
        Assert.NotNull(wrapper);
        Assert.NotNull(wrapper!.Data);
        Assert.NotEmpty(wrapper.Data!);
    }
}
