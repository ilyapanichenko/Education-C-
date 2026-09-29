using HW9_1.Core.Components;
using HW9_1.Core.Configuration;
using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CartPage : BasePage
{
    public HeaderSection Header { get; }
    private readonly Label _title;
    private readonly Label _itemName;
    private readonly Button _removeBackpack;
    private readonly Button _checkoutButton;

    #region Elements

    public CartPage(IWebDriver driver, TestSettings settings) : base(driver, settings)
    {
        Header = new HeaderSection(driver, settings);
        _title = ElementFactory.Create<Label>(By.CssSelector("[data-test='title']"));
        _itemName = ElementFactory.Create<Label>(By.CssSelector("[data-test='inventory-item-name']"));
        _removeBackpack = ElementFactory.Create<Button>(By.Id("remove-sauce-labs-backpack"));
        _checkoutButton = ElementFactory.Create<Button>(By.Id("checkout"));
    }

    #endregion

    #region Methods

    public override bool IsLoaded()
    {
        return _title.IsElementPresent() && _title.GetText() == "Your Cart";
    }

    public override CartPage Load()
    {
        return new ProductsPage(Driver, Settings)
            .Load()
            .Header
            .OpenCart();
    }

    public string GetTitle()
    {
        return _title.GetText();
    }

    public string GetItemName()
    {
        return _itemName.GetText();
    }

    public bool IsCheckoutButtonPresent()
    {
        return _checkoutButton.IsElementPresent();
    }

    public void RemoveBackpackFromCart()
    {
        _removeBackpack.Click();
    }

    public CheckoutInformationPage OpenCheckout()
    {
        _checkoutButton.Click();
        WaitUntilUrlContains("checkout-step-one");
        return new CheckoutInformationPage(Driver, Settings);
    }

    #endregion
}