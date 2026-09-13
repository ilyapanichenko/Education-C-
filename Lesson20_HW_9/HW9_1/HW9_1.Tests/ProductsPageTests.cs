using HW9_1.Core.Pages;
namespace HW9_1.Tests;

public class ProductsPageTests : BaseTest
{
    private ProductsPage _productsPage = null!;

    [SetUp]
    public void Login()
    {
        var loginPage = new LoginPage(Driver);
        loginPage.Open();

        _productsPage = loginPage.Login();
    }

    [Test]
    public void AddBackpackTest()
    {
        _productsPage.AddBackpackToCart();

        Assert.That(_productsPage.Header.GetCartCount(), Is.EqualTo("1"));
    }

    [Test]
    public void AddBackpackRemoveTest()
    {
        _productsPage.AddBackpackToCart();

        Assert.That(_productsPage.Header.GetCartCount(), Is.EqualTo("1"));

        _productsPage.RemoveBackpackFromCart();

        _productsPage.Header.WaitUntilCartBadgeAbsent();

        Assert.That(_productsPage.Header.IsCartBadgePresent(), Is.False);
    }
}