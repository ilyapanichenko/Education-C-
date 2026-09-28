using HW9_1.Core.Configuration;
using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CheckoutInformationPage : BasePage
{
    private readonly Label _title;
    private readonly TextBox _firstNameField;
    private readonly TextBox _lastNameField;
    private readonly TextBox _postalCodeField;
    private readonly Button _continueButton;
    #region Elements

    public CheckoutInformationPage(IWebDriver driver, TestSettings settings) : base(driver,settings)
    {
        _title = ElementFactory.Create<Label>(By.CssSelector("[data-test='title']"));
        _firstNameField = ElementFactory.Create<TextBox>(By.Id("first-name"));
        _lastNameField = ElementFactory.Create<TextBox>(By.Id("last-name"));
        _postalCodeField = ElementFactory.Create<TextBox>(By.Id("postal-code"));
        _continueButton = ElementFactory.Create<Button>(By.Id("continue"));
    }

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
    public CheckoutOverviewPage ClickContinue()
{
    _continueButton.Click();
    WaitUntilUrlContains("checkout-step-two");
    return new CheckoutOverviewPage(Driver, Settings);
}
    public string GetTitle() => _title.GetText();

    #endregion

    public override bool IsLoaded()
    {
        return _title.IsElementPresent() && _title.GetText() == "Checkout: Your Information";
    }

    public override CheckoutInformationPage Load()
    {
        return new CartPage(Driver, Settings)
            .Load()
            .OpenCheckout();
    }
}