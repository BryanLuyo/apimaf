using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Apimaf.WebAPI.Tests;

public class ApiEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ApiEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetConcesionarios_ReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/concesionarios");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetSucursalesByConcesionario_ReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/concesionarios/1/sucursales");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
