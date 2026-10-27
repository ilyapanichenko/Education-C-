using System.Net;

namespace ApiTesting.Tests.API;

[TestFixture]
public class ResourcesTests : BaseApiTest
{
    [Test]
    public async Task GetResources_List_ReturnsUniqueIds()
    {
        var response = await Resources.GetAll();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var resources = response.Data?.Data ?? throw new AssertionException("Resource list is missing.");
        Assert.That(resources, Is.Not.Empty);
        var ids = resources.Select(resource => resource.Id);
        Assert.That(ids, Is.Unique);
    }

    [Test]
    public async Task GetResource_ExistingId_ReturnsValidFields()
    {
        const int resourceId = 2;
        var response = await Resources.GetById(resourceId);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var resource = response.Data?.Data ?? throw new AssertionException("Resource data is missing.");
        Assert.That(resource.Id, Is.EqualTo(resourceId));
        Assert.That(resource.Name, Is.Not.Null.And.Not.Empty);
        Assert.That(resource.Year, Is.GreaterThan(0));
        Assert.That(resource.Color, Does.StartWith("#"));
    }
}
