using OpenQA.Selenium.Chrome;
using Reqnroll;
using TestContext = BookingBDD.Tests.Context.TestContext;

namespace BookingBDD.Tests.Hooks;

[Binding]
public class TestHooks
{
    private readonly TestContext _context;

    public TestHooks(TestContext context)
    {
        _context = context;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var options = new ChromeOptions();
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddArgument("--guest");
        options.AddArgument("--disable-notifications");

        _context.Driver = new ChromeDriver(options);
        _context.Driver.Manage().Window.Maximize();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _context.Driver.Quit();
        _context.Driver.Dispose();
    }
}