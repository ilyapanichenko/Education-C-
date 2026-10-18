using System.Net;
using ApiTests.Core.API.Models;

namespace ApiTesting.Tests.API;

[TestFixture]
public class AuthTests : BaseApiTest
{
    [Test]
    public async Task Login_ValidCredentials_ReturnsToken()
    {
        var credentials = new CredentialsRequestDto
        {
            Email = "eve.holt@reqres.in",
            Password = "cityslicka"
        };
        var response = await Auth.Login<AuthResponseDto>(credentials);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var auth = response.Data ?? throw new AssertionException("Login response data is missing.");
        Assert.That(auth.Token, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task Login_WithoutPassword_Returns400()
    {
        var credentials = new CredentialsRequestDto
        {
            Email = "peter@klaven"
        };
        var response = await Auth.Login<ErrorResponseDto>(credentials);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var error = ReadError(response);
        Assert.That(error.Error, Is.EqualTo("Missing password"));
    }

    [Test]
    public async Task Register_ValidCredentials_ReturnsIdAndToken()
    {
        var credentials = new CredentialsRequestDto
        {
            Email = "eve.holt@reqres.in",
            Password = "pistol"
        };
        var response = await Auth.Register<AuthResponseDto>(credentials);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var auth = response.Data ?? throw new AssertionException("Registration response data is missing.");
        Assert.That(auth.Id, Is.GreaterThan(0));
        Assert.That(auth.Token, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task Register_WithoutEmail_Returns400()
    {
        var credentials = new CredentialsRequestDto
        {
            Password = "pistol"
        };
        var response = await Auth.Register<ErrorResponseDto>(credentials);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var error = ReadError(response);
        Assert.That(error.Error, Is.EqualTo("Missing email or username"));
    }
}
