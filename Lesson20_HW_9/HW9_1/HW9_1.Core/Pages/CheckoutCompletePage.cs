using HW9_1.Core.Configuration;
using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CheckoutCompletePage : BasePage
{
    private readonly Label _title;
    private readonly Label _completeHeader;
    private readonly Label _completeText;
    private readonly Button _backHomeButton;

    #region Elements

    public CheckoutCompletePage(IWebDriver driver, TestSettings settings) : base(driver, settings)
    {
        _title = ElementFactory.Create<Label>(By.CssSelector("[data-test='title']"));
        _completeHeader = ElementFactory.Create<Label>(By.CssSelector("[data-test='complete-header']"));
        _completeText = ElementFactory.Create<Label>(By.CssSelector("[data-test='complete-text']"));
        _backHomeButton = ElementFactory.Create<Button>(By.CssSelector("[data-test='back-to-products']"));
    }

    #endregion

    #region Methods

    public string GetTitle()
    {
        return _title.GetText();
    }

    public string GetCompleteHeader()
    {
        return _completeHeader.GetText();
    }

    public string GetCompleteText()
    {
        return _completeText.GetText();
    }

    public bool IsBackHomeButtonPresent()
    {
        return _backHomeButton.IsElementPresent();
    }

    public ProductsPage BackHome()
    {
        _backHomeButton.Click();
        WaitUntilUrlContains("inventory");
        return new ProductsPage(Driver, Settings);
    }

    public override bool IsLoaded()
    {
        return _title.IsElementPresent() && _title.GetText() == "Checkout: Complete!";
    }

    public override CheckoutCompletePage Load()
    {
        return new CheckoutOverviewPage(Driver, Settings)
            .Load()
            .CompleteOrder();
    }

    #endregion
}