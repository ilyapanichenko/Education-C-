using HW9_1.Core.Components;
using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CartPage(IWebDriver driver) : BasePage(driver)
{
    public HeaderSection Header = new HeaderSection(driver);

    #region Elements

    private readonly Label _title = new Label(driver, By.CssSelector("[data-test='title']"));
    private readonly Label _itemName = new Label(driver,By.CssSelector("[data-test='inventory-item-name']"));
    private readonly Button _removeBackpack = new Button(driver, By.Id("remove-sauce-labs-backpack"));
    private readonly Button _checkoutButton = new Button(driver, By.Id("checkout"));

    #endregion

    #region Methods

    public string GetTitle() => _title.GetText();

    public string GetItemName() => _itemName.GetText();

    public bool IsCheckoutButtonPresent() => _checkoutButton.IsElementPresent();

    public void RemoveBackpackFromCart() => _removeBackpack.Click();

    public CheckoutInformationPage OpenCheckout()
    {
        _checkoutButton.Click();
        return new CheckoutInformationPage(Driver);
    }

    #endregion
}