using HW9_1.Core.Elements;
using HW9_1.Core.Pages;
using OpenQA.Selenium;

namespace HW9_1.Core.Components;

public class HeaderSection(IWebDriver driver) : BasePage(driver)
{
    #region Locators

    private readonly Label _cartBadge = new Label(driver, By.CssSelector("[data-test='shopping-cart-badge']"));
    private readonly Link _cartLink = new Link(driver, By.ClassName("shopping_cart_link"));

    #endregion

    #region Methods

    public string GetCartCount() => _cartBadge.GetText();

    public bool IsCartBadgePresent() => _cartBadge.IsElementPresent();

    public void WaitUntilCartBadgeAbsent()
    {
        _cartBadge.WaitUntilElementAbsent();
    }

    public CartPage OpenCart()
    {
        _cartLink.Click();
        return new CartPage(Driver);
    }

    #endregion
}