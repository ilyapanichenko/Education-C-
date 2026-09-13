using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CheckoutInformationPage(IWebDriver driver) : BasePage(driver)
{
    #region Locators

    private readonly By _titleLocator = By.CssSelector("[data-test='title']");

    #endregion

    #region Methods

    public string GetTitle() => GetText(_titleLocator);

    #endregion
}