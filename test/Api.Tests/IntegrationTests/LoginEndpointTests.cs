using System.Net;
using System.Text;
using System.Text.Json;
using Api.InputModel;

namespace Api.Tests.IntegrationTests;
public class LoginEndpointTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory = factory;
    private readonly HttpClient _client = factory.CreateClient();
    private readonly string _loginEndpoint = "api/auth";

    [Fact]
    public async Task RegisterAsync_IsNotValid_ReturnBadRequest()
    {
        // Arrange
        var loginInput = new RegisterLoginInputModel("email", "password");
        var content = CreateHttpContent(loginInput);

        // Act
        var response = await _client.PostAsync(_loginEndpoint, content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    private HttpContent CreateHttpContent(RegisterLoginInputModel loginInput)
        => new StringContent(JsonSerializer.Serialize(loginInput), Encoding.UTF8, "application/json");
}

