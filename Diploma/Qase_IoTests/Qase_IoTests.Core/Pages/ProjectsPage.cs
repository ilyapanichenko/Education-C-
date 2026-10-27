using OpenQA.Selenium;
using Qase_IoTests.Core.Configuration;

namespace Qase_IoTests.Core.Pages;

public class ProjectsPage : BasePage
{
    private readonly By _projectLink = By.CssSelector($"a[href='/project/{TestConfig.ProjectCode}']");
    public ProjectPage OpenProject()
    {
        WaitForVisible(_projectLink).Click();
        return new ProjectPage(Driver);
    }
    public ProjectsPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsOpened()
    {
        return WaitForUrlPath("/projects");
    }
    
}