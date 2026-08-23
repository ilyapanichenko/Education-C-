using HW9_1.Core.Pages;
using OpenQA.Selenium;

namespace HW9_1.Core.Components;

public class HeaderSection(IWebDriver driver) : BasePage(driver)
{
    #region Locators

    private readonly By _cartBadgeLocator = By.CssSelector("[data-test='shopping-cart-badge']");
    private readonly By _cartLinkLocator = By.ClassName("shopping_cart_link");

    #endregion

    #region Methods

    public string GetCartCount() => GetText(_cartBadgeLocator);

    public bool IsCartBadgePresent() => IsElementPresent(_cartBadgeLocator);

    public void WaitUntilCartBadgeAbsent()
    {
        WaitUntilElementAbsent(_cartBadgeLocator);
    }

    public CartPage OpenCart()
    {
        Click(_cartLinkLocator);
        return new CartPage(Driver);
    }

    #endregion
}