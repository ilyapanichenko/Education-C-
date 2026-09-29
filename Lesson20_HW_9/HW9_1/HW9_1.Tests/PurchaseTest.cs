using HW9_1.Core.Pages;
using HW9_1.Tests.TestData;

namespace HW9_1.Tests;

public class PurchaseTest : BaseTest
{
    [Test]
    public void PurchaseItemTest()
    {
        var loginPage = new LoginPage(Driver, Settings)
            .Load();

        var productsPage = loginPage
            .EnterUsername()
            .EnterPassword()
            .Login();
        Assert.That(productsPage.GetTitle(), Is.EqualTo("Products"));

        productsPage.AddBackpackToCart();
        Assert.That(productsPage.Header.GetCartCount(), Is.EqualTo("1"));

        var cartPage = productsPage.Header.OpenCart();
        Assert.That(cartPage.GetTitle(), Is.EqualTo("Your Cart"));
        Assert.That(cartPage.GetItemName(), Is.EqualTo("Sauce Labs Backpack"));

        var checkoutInformationPage = cartPage.OpenCheckout();
        Assert.That(checkoutInformationPage.GetTitle(), Is.EqualTo("Checkout: Your Information"));
        var checkoutData = new CheckoutDataBuilder().Build();
        var checkoutOverviewPage = checkoutInformationPage
            .EnterFirstName(checkoutData.FirstName)
            .EnterLastName(checkoutData.LastName)
            .EnterPostalCode(checkoutData.PostalCode)
            .ClickContinue();
        Assert.That(checkoutOverviewPage.GetTitle(), Is.EqualTo("Checkout: Overview"));
        Assert.That(checkoutOverviewPage.GetItemName(), Is.EqualTo("Sauce Labs Backpack"));
        Assert.That(checkoutOverviewPage.GetItemQuantity(), Is.EqualTo("1"));
        Assert.That(checkoutOverviewPage.GetPaymentInfoLabel(), Is.EqualTo("Payment Information:"));
        Assert.That(checkoutOverviewPage.GetPaymentInfoValue(), Is.EqualTo("SauceCard #31337"));
        Assert.That(checkoutOverviewPage.GetShippingInfoLabel(), Is.EqualTo("Shipping Information:"));
        Assert.That(checkoutOverviewPage.GetShippingInfoValue(), Is.EqualTo("Free Pony Express Delivery!"));
        Assert.That(checkoutOverviewPage.GetTotalInfoLabel(), Is.EqualTo("Price Total"));
        Assert.That(checkoutOverviewPage.GetSubtotal(), Is.EqualTo("Item total: $29.99"));
        Assert.That(checkoutOverviewPage.GetTax(), Is.EqualTo("Tax: $2.40"));
        Assert.That(checkoutOverviewPage.GetTotal(), Is.EqualTo("Total: $32.39"));
        Assert.That(checkoutOverviewPage.IsFinishButtonPresent(), Is.True);

        var checkoutCompletePage = checkoutOverviewPage.CompleteOrder();
        Assert.That(checkoutCompletePage.GetTitle(), Is.EqualTo("Checkout: Complete!"));
        Assert.That(checkoutCompletePage.GetCompleteHeader(), Is.EqualTo("Thank you for your order!"));
        Assert.That(checkoutCompletePage.GetCompleteText(),
            Is.EqualTo("Your order has been dispatched, and will arrive just as fast as the pony can get there!"));
        Assert.That(checkoutCompletePage.IsBackHomeButtonPresent(), Is.True);

        productsPage = checkoutCompletePage.BackHome();
        Assert.That(productsPage.GetTitle(), Is.EqualTo("Products"));
    }
}