using HW9_1.Core.Components;
using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class ProductsPage(IWebDriver driver) : BasePage(driver)
{
    public HeaderSection Header = new HeaderSection(driver);

    #region Locators

    private readonly Label _title =new Label(driver, By.ClassName("title"));
    private readonly Button _addBackpack = new Button(driver,By.Id("add-to-cart-sauce-labs-backpack"));
    private readonly Button _removeBackpack = new Button(driver, By.Id("remove-sauce-labs-backpack"));

    #endregion

    #region Elements

    public string GetTitle() => _title.GetText();

    public void AddBackpackToCart() => _addBackpack.Click();

    public void RemoveBackpackFromCart() => _removeBackpack.Click();

    #endregion
}