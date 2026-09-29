using HW9_1.Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace HW9_1.Core.Factories;

public static class DriverFactory
{
    public static IWebDriver CreateDriver(TestSettings settings)
    {
        return settings.ExecutionMode.ToLowerInvariant() switch
        {
            "local" => CreateLocalDriver(settings),
            "remote" => CreateRemoteDriver(settings),
            _ => throw new ArgumentException($"Unsupported execution mode: {settings.ExecutionMode}")
        };
    }

    private static IWebDriver CreateLocalDriver(TestSettings settings)
    {
        return settings.Browser.ToLowerInvariant() switch
        {
            "chrome" => new ChromeDriver(CreateChromeOptions(settings)),
            "firefox" => new FirefoxDriver(CreateFirefoxOptions(settings)),
            "edge" => new EdgeDriver(CreateEdgeOptions(settings)),
            _ => throw new ArgumentException($"Unsupported browser: {settings.Browser}")
        };
    }

    private static IWebDriver CreateRemoteDriver(TestSettings settings)
    {
        var gridUrl = new Uri(settings.GridUrl);

        return settings.Browser.ToLowerInvariant() switch
        {
            "chrome" => new RemoteWebDriver(gridUrl, CreateChromeOptions(settings)),
            "firefox" => new RemoteWebDriver(gridUrl, CreateFirefoxOptions(settings)),
            "edge" => new RemoteWebDriver(gridUrl, CreateEdgeOptions(settings)),
            _ => throw new ArgumentException($"Unsupported browser: {settings.Browser}")
        };
    }

    private static ChromeOptions CreateChromeOptions(TestSettings settings)
    {
        var options = new ChromeOptions();

        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddArgument("--guest");

        if (settings.Headless)
        {
            options.AddArgument("--headless");
        }

        return options;
    }

    private static FirefoxOptions CreateFirefoxOptions(TestSettings settings)
    {
        var options = new FirefoxOptions();

        options.SetPreference("signon.rememberSignons", false);
        options.SetPreference("signon.autofillForms", false);
        options.AddArgument("-private-window");

        if (settings.Headless)
        {
            options.AddArgument("--headless");
        }

        return options;
    }

    private static EdgeOptions CreateEdgeOptions(TestSettings settings)
    {
        var options = new EdgeOptions();

        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddArgument("--guest");

        if (settings.Headless)
        {
            options.AddArgument("--headless");
        }

        return options;
    }
}