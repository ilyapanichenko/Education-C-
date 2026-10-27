using Allure.Net.Commons;
using OpenQA.Selenium;
using Qase_IoTests.Core.Configuration;
using Qase_IoTests.Core.Logging;
using Qase_IoTests.Core.Pages;
using Qase_IoTests.Core.Utilities;
using Qase_IoTests.Core.WebDriver;
using Reqnroll;

namespace Qase_IoTests.Tests.BDD.Steps;

[Binding]
public class LoginSteps
{
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver? _driver;
    private LoginPage? _loginPage;
    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    [Given("the browser is open")]
    public void GivenTheBrowserIsOpen()
    {
        _driver = DriverFactory.CreateDriver();
        _loginPage = new LoginPage(_driver);
    }
    [When("I open the Qase login page")]
    public void WhenIOpenTheQaseLoginPage()
    {
        _loginPage!.Open();
    }
    [Then("the email field is visible")]
    public void ThenTheEmailFieldIsVisible()
    {
        Assert.That(_loginPage!.IsEmailFieldVisible(), Is.True);
    }
    [Then("the password field is visible")]
    public void ThenThePasswordFieldIsVisible()
    {
        Assert.That(_loginPage!.IsPasswordFieldVisible(), Is.True);
    }
    
    [When("I accept cookies if present")]
    public void WhenIAcceptCookiesIfPresent()
    {
        _loginPage!.AcceptCookiesIfPresent();
    }

    [When("I enter my email")]
    public void WhenIEnterMyEmail()
    {
        _loginPage!.EnterEmail(TestConfig.UiEmail);
    }

    [When("I enter the password {string}")]
    public void WhenIEnterThePassword(string password)
    {
        _loginPage!.EnterPassword(password);
    }

    [When("I click the login button")]
    public void WhenIClickTheLoginButton()
    {
        _loginPage!.ClickLogin();
    }

    [Then("I should see the error {string}")]
    public void ThenIShouldSeeTheError(string expectedMessage)
    {
        Assert.That(
            _loginPage!.GetLoginErrorMessage(),
            Is.EqualTo(expectedMessage)
        );
    }

    [AfterScenario]
    public void AfterScenario()
    {
        if (_driver is null)
            return;
        try
        {
            if (_scenarioContext.TestError is not null)
            {
                try
                {
                    var path = ScreenshotHelper.Save(_driver, _scenarioContext.ScenarioInfo.Title);
                    TestContext.AddTestAttachment(path, "BDD screenshot on failure");
                    AllureApi.AddAttachment("BDD screenshot on failure", "image/png", path);
                    TestLogger.Info($"BDD screenshot saved: {path}");
                }
                catch (Exception ex)
                {
                    TestLogger.Error("Failed to save BDD screenshot", ex);
                }
            }
        }
        finally
        {
            try
            {
                _driver.Quit();
            }
            finally
            {
                _driver.Dispose();
            }
        }
    }
}