using HW9_1.Core.Components;
using HW9_1.Core.Configuration;
using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class ProductsPage : BasePage
{
    public HeaderSection Header { get; }
    private readonly Label _title;
    private readonly Button _addBackpack;
    private readonly Button _removeBackpack;

    #region Elements

    public ProductsPage(IWebDriver driver, TestSettings settings) : base(driver,settings)
    {
        Header = new HeaderSection(driver, settings);
        _title = ElementFactory.Create<Label>(By.ClassName("title")); 
        _addBackpack = ElementFactory.Create<Button>(By.Id("add-to-cart-sauce-labs-backpack"));
        _removeBackpack = ElementFactory.Create<Button>(By.Id("remove-sauce-labs-backpack")); 
    }
    #endregion

    #region Methods
    public override bool IsLoaded()
    {
        return _title.IsElementPresent() && _title.GetText() == "Products";
    }

    public override ProductsPage Load()
    {
        return new LoginPage(Driver, Settings)
            .Load()
            .EnterUsername()
            .EnterPassword()
            .Login();
    }
    public string GetTitle() => _title.GetText();

    public void AddBackpackToCart() => _addBackpack.Click();

    public void RemoveBackpackFromCart() => _removeBackpack.Click();

    #endregion
}