using HW9_1.Core.Configuration;
using HW9_1.Core.Elements;
using HW9_1.Core.Factories;
using HW9_1.Core.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HW9_1.Core.Components;

public class HeaderSection
{
    private readonly IWebDriver _driver;
    private readonly TestSettings _settings;
    private readonly ElementFactory _elementFactory;

    private readonly Label _cartBadge;
    private readonly Link _cartLink;

    public HeaderSection(IWebDriver driver, TestSettings settings)
    {
        _driver = driver;
        _settings = settings;
        _elementFactory = new ElementFactory(driver);
        _cartBadge = _elementFactory.Create<Label>(By.CssSelector("[data-test='shopping-cart-badge']"));
        _cartLink = _elementFactory.Create<Link>(By.ClassName("shopping_cart_link"));
    }

    public string GetCartCount() => _cartBadge.GetText();

    public bool IsCartBadgePresent() => _cartBadge.IsElementPresent();

    public void WaitUntilCartBadgeAbsent()
    {
        _cartBadge.WaitUntilElementAbsent();
    }

    public CartPage OpenCart()
    {
        _cartLink.Click();

        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_settings.TimeoutSeconds));
        wait.Until(driver => driver.Url.Contains("cart"));

        return new CartPage(_driver, _settings);
    }
}