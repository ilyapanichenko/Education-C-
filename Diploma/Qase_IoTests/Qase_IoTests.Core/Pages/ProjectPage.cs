using OpenQA.Selenium;
using Qase_IoTests.Core.Configuration;

namespace Qase_IoTests.Core.Pages;

public class ProjectPage : BasePage
{
    private readonly By _manualTestButton = By.XPath("//button[normalize-space()='Manual test']");
    private readonly By _testCaseTitle = By.CssSelector("input[placeholder='For example: Authorization']");
    private readonly By _saveTestCaseButton = By.XPath("//button[normalize-space()='Save']");
    private readonly By _addNewSuiteButton = By.CssSelector("button[aria-label='Add new suite']");
    private readonly By _suiteNameField = By.CssSelector("input[placeholder='For example: Web Application']");
    private readonly By _createSuiteButton = By.XPath("//button[@type='submit' and normalize-space()='Create']");
    private By SuiteByTitle(string title) => By.XPath($"//*[normalize-space(text())='{title}']");
    public ProjectPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsOpened()
    {
        return WaitForUrlPath($"/project/{TestConfig.ProjectCode}");
    }
    public void OpenCreateTestCaseForm()
    {
        WaitForVisible(_manualTestButton).Click();
    }

    public bool IsCreateTestCaseFormVisible()
    {
        return WaitForVisible(_testCaseTitle).Displayed;
    }

    public void EnterTestCaseTitle(string title)
    {
        var field =  WaitForVisible(_testCaseTitle);
        field.Clear();
        field.SendKeys(title);
    }

    public string GetTestCaseTitle()
    {
        return WaitForVisible(_testCaseTitle).GetDomProperty("value") ?? "";
    }
    
    public void SaveTestCase()
    {
        WaitForVisible(_saveTestCaseButton).Click();
    }
    
    public ProjectPage OpenCreateSuiteForm()
    {
        WaitForVisible(_addNewSuiteButton).Click();
        return this;
    }
    
    public bool IsCreateSuiteFormVisible()
    {
        return WaitForVisible(_suiteNameField).Displayed;
    }

    public ProjectPage EnterSuiteTitle(string title)
    {
        var  field =  WaitForVisible(_suiteNameField);
        field.Clear();
        field.SendKeys(title);
        return this;
    }
    
    public string GetSuiteTitle()
    {
        return WaitForVisible(_suiteNameField).GetDomProperty("value") ?? "";
    }
    
    public ProjectPage SaveSuite()
    {
        WaitForVisible(_createSuiteButton).Click();
        return this;
    }
    
    public bool IsSuiteTitleInvalid()
    {
        return WaitForVisible(_suiteNameField)
            .GetDomAttribute("aria-invalid") == "true";
    }
    public bool IsSuiteVisible(string title)
    {
        return WaitForVisible(SuiteByTitle(title)).Displayed;
    }
}