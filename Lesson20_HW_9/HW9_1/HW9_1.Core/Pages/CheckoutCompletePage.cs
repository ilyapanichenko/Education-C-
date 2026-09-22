using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CheckoutCompletePage(IWebDriver driver) : BasePage(driver)
{
    #region Elements

    private readonly Label _title = new(driver, By.CssSelector("[data-test='title']"));
    private readonly Label _completeHeader = new(driver, By.CssSelector("[data-test='complete-header']"));
    private readonly Label _completeText = new(driver, By.CssSelector("[data-test='complete-text']"));
    private readonly Button _backHomeButton = new(driver, By.CssSelector("[data-test='back-to-products']"));

    #endregion

    #region Methods

    public string GetTitle() => _title.GetText();
    public string GetCompleteHeader() => _completeHeader.GetText();
    public string GetCompleteText() => _completeText.GetText();
    public bool IsBackHomeButtonPresent() => _backHomeButton.IsElementPresent();

    public ProductsPage BackHome()
    {
        _backHomeButton.Click();
        return new ProductsPage(Driver);
    }

    #endregion
}