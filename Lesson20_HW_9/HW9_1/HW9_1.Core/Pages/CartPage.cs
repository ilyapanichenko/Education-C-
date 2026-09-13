using HW9_1.Core.Components;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CartPage(IWebDriver driver) : BasePage(driver)
{
    public HeaderSection Header = new HeaderSection(driver);

    #region Locators

    private readonly By _titleLocator = By.CssSelector("[data-test='title']");
    private readonly By _itemNameLocator = By.CssSelector("[data-test='inventory-item-name']");
    private readonly By _removeBackpackLocator = By.Id("remove-sauce-labs-backpack");
    private readonly By _checkoutButtonLocator = By.Id("checkout");

    #endregion

    #region Methods

    public string GetTitle() => GetText(_titleLocator);

    public string GetItemName() => GetText(_itemNameLocator);

    public bool IsCheckoutButtonPresent() => IsElementPresent(_checkoutButtonLocator);

    public void RemoveBackpackFromCart() => Click(_removeBackpackLocator);

    public CheckoutInformationPage OpenCheckout()
    {
        Click(_checkoutButtonLocator);
        return new CheckoutInformationPage(Driver);
    }

    #endregion
}