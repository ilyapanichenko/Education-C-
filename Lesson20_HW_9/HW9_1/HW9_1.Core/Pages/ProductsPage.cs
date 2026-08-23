using HW9_1.Core.Components;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class ProductsPage(IWebDriver driver) : BasePage(driver)
{
    public HeaderSection Header = new HeaderSection(driver);

    #region Locators

    private readonly By _titleLocator = By.ClassName("title");
    private readonly By _addBackpackLocator = By.Id("add-to-cart-sauce-labs-backpack");
    private readonly By _removeBackpackLocator = By.Id("remove-sauce-labs-backpack");

    #endregion

    #region Methods

    public string GetTitle() => GetText(_titleLocator);

    public void AddBackpackToCart() => Click(_addBackpackLocator);

    public void RemoveBackpackFromCart() => Click(_removeBackpackLocator);

    #endregion
}