using System.Net;
using ApiTests.Core.API.Models;

namespace ApiTesting.Tests.API;

[TestFixture]
public class UserMutationTests : BaseApiTest
{
    [Test]
    public async Task CreateUser_ValidData_ReturnsDataAndMetadata()
    {
        var newUser = new UserWriteRequestDto
        {
            Name = "Ilia",
            Job = "QA Engineer"
        };
        var response = await Users.Create(newUser);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        var created = response.Data ?? throw new AssertionException("Created user data is missing.");
        Assert.That(created.Name, Is.EqualTo(newUser.Name));
        Assert.That(created.Job, Is.EqualTo(newUser.Job));
        Assert.That(created.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(DateTimeOffset.TryParse(created.CreatedAt, out _), Is.True);
    }

    [Test]
    public async Task UpdateUser_ValidData_ReturnsChangesAndTimestamp()
    {
        var changes = new UserWriteRequestDto
        {
            Name = "Ilia",
            Job = "Senior QA Engineer"
        };
        var response = await Users.Update(2, changes);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var updated = response.Data ?? throw new AssertionException("Updated user data is missing.");
        Assert.That(updated.Name, Is.EqualTo(changes.Name));
        Assert.That(updated.Job, Is.EqualTo(changes.Job));
        Assert.That(DateTimeOffset.TryParse(updated.UpdatedAt, out _), Is.True);
    }

    [Test]
    public async Task DeleteUser_ExistingId_Returns204WithoutBody()
    {
        var response = await Users.Delete(2);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(response.Content, Is.Null.Or.Empty);
    }
}
