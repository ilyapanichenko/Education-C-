using HW9_1.Core.Pages;
namespace HW9_1.Tests;

public class CartPageTests : BaseTest
{
    private CartPage _cartPage = null!;

    [SetUp]
    public void OpenCart()
    {
        var loginPage = new LoginPage(Driver);
        loginPage.Open();

        var productsPage = loginPage.Login();

        productsPage.AddBackpackToCart();

        _cartPage = productsPage.Header.OpenCart();
    }

    [Test]
    public void ProceedToCheckoutTest()
    {
        Assert.That(_cartPage.GetTitle(), Is.EqualTo("Your Cart"));
        Assert.That(_cartPage.Header.GetCartCount(), Is.EqualTo("1"));
        Assert.That(_cartPage.GetItemName(), Is.EqualTo("Sauce Labs Backpack"));
        Assert.That(_cartPage.IsCheckoutButtonPresent(), Is.True);

        var checkoutInformationPage = _cartPage.OpenCheckout();

        Assert.That(checkoutInformationPage.GetTitle(), Is.EqualTo("Checkout: Your Information"));
    }

    [Test]
    public void RemoveBackpackFromCartTest()
    {
        Assert.That(_cartPage.Header.GetCartCount(), Is.EqualTo("1"));

        _cartPage.RemoveBackpackFromCart();

        _cartPage.Header.WaitUntilCartBadgeAbsent();

        Assert.That(_cartPage.Header.IsCartBadgePresent(), Is.False);
    }
}