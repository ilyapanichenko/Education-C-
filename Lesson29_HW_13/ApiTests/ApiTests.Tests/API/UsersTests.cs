using System.Net;

namespace ApiTesting.Tests.API;

[TestFixture]
public class UsersTests : BaseApiTest
{
    [Test]
    public async Task GetUser_ExistingId_ReturnsExpectedProfile()
    {
        const int userId = 2;
        var response = await Users.GetUser(userId);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var user = response.Data?.Data ?? throw new AssertionException("User data is missing.");
        Assert.That(user.Id, Is.EqualTo(userId));
        Assert.That(user.FirstName, Is.EqualTo("Janet"));
        Assert.That(user.LastName, Is.EqualTo("Weaver"));
        Assert.That(user.Email, Is.EqualTo("janet.weaver@reqres.in"));
    }

    [Test]
    public async Task GetUser_UnknownId_Returns404()
    {
        var response = await Users.GetUser(999);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetUsers_FirstPage_ReturnsConsistentPagination()
    {
        var response = await Users.GetPage(1);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var page = response.Data ?? throw new AssertionException("Pagination data is missing.");
        var users = page.Data ?? throw new AssertionException("User list is missing.");
        Assert.That(page.Page, Is.EqualTo(1));
        Assert.That(page.PerPage, Is.GreaterThan(0));
        Assert.That(page.Total, Is.GreaterThan(0));
        Assert.That(page.TotalPages,
            Is.EqualTo((int)Math.Ceiling((double)page.Total / page.PerPage)));
        Assert.That(users, Is.Not.Empty);
        Assert.That(users.Count, Is.LessThanOrEqualTo(page.PerPage));
    }

    [Test]
    public async Task GetUsers_SecondPage_DoesNotRepeatFirstPage()
    {
        var first = await Users.GetPage(1);
        var second = await Users.GetPage(2);
        Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var firstPage = first.Data ?? throw new AssertionException("First page data is missing.");
        var secondPage = second.Data ?? throw new AssertionException("Second page data is missing.");
        var firstUsers = firstPage.Data ?? throw new AssertionException("First page users are missing.");
        var secondUsers = secondPage.Data ?? throw new AssertionException("Second page users are missing.");
        Assert.That(firstUsers, Is.Not.Empty);
        Assert.That(secondUsers, Is.Not.Empty);
        Assert.That(secondPage.Page, Is.EqualTo(2));
        var firstIds = firstUsers.Select(user => user.Id);
        var secondIds = secondUsers.Select(user => user.Id);
        Assert.That(firstIds.Intersect(secondIds), Is.Empty);
    }

    [Test]
    public async Task GetUsers_PageBeyondLast_ReturnsEmptyList()
    {
        const int requestedPage = 100;
        var response = await Users.GetPage(requestedPage);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var page = response.Data ?? throw new AssertionException("Pagination data is missing.");
        var users = page.Data ?? throw new AssertionException("User list is missing.");
        Assert.That(page.Page, Is.EqualTo(requestedPage));
        Assert.That(users, Is.Empty);
    }

    [Test]
    public async Task GetUsers_List_ReturnsCompleteProfiles()
    {
        var response = await Users.GetPage(1);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var users = response.Data?.Data ?? throw new AssertionException("User list is missing.");
        Assert.That(users, Is.Not.Empty);
        foreach (var user in users)
        {
            Assert.That(user.Id, Is.GreaterThan(0));
            Assert.That(user.FirstName, Is.Not.Null.And.Not.Empty);
            Assert.That(user.LastName, Is.Not.Null.And.Not.Empty);
            Assert.That(user.Email, Does.Contain("@"));
        }
    }
}
