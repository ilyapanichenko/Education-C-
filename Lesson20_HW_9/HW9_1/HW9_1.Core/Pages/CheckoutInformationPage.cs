using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CheckoutInformationPage(IWebDriver driver) : BasePage(driver)
{
    #region Elements

    private readonly Label _title = new Label(driver, By.CssSelector("[data-test='title']"));
    private readonly TextBox _firstNameField = new  TextBox(driver, By.Id("first-name"));
    private readonly TextBox _lastNameField = new  TextBox(driver, By.Id("last-name"));
    private readonly TextBox _postalCodeField = new TextBox(driver, By.Id("postal-code"));
    private readonly Button _continueButton = new  Button(driver, By.Id("continue"));

    #endregion

    #region Methods

    public CheckoutInformationPage EnterFirstName(string firstName)
    {
        _firstNameField.SetText(firstName);
        return this;
    }

    public CheckoutInformationPage EnterLastName(string lastName)
    {
        _lastNameField.SetText(lastName);
        return this;
    }

    public CheckoutInformationPage EnterPostalCode(string postalCode)
    {
        _postalCodeField.SetText(postalCode);
        return this;
    }

    public CheckoutOverviewPage FillForm(string firstName, string lastName, string postalCode)
    {
        EnterFirstName(firstName);
        EnterLastName(lastName);
        EnterPostalCode(postalCode);
        _continueButton.Click();
        return new CheckoutOverviewPage(Driver);
    }
    public string GetTitle() => _title.GetText();

    #endregion
}