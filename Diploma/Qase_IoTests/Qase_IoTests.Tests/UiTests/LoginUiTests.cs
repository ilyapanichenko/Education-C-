using Qase_IoTests.Core.Configuration;
using Qase_IoTests.Core.Pages;
using Qase_IoTests.Tests.BaseTests;

namespace Qase_IoTests.Tests.UiTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginUiTests : BaseUiTest
{
    [Test]
    public void LoginWithValidCredentials()
    {
        var loginPage = new LoginPage(Driver);
        loginPage.Open();
        loginPage.AcceptCookiesIfPresent();
        loginPage.EnterEmail(TestConfig.UiEmail);
        loginPage.EnterPassword(TestConfig.UiPassword);
        loginPage.ClickLogin();
        var projectsPage = new ProjectsPage(Driver);
        Assert.That(projectsPage.IsOpened(), Is.True,"After login, the projects page should open");
    }
}