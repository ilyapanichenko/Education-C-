using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using HW9_1.Core.Configuration;

namespace HW9_1.Core.Factories;
public static class DriverFactory
{
    public static IWebDriver CreateDriver(TestSettings settings)
    {
        
        return settings.Browser.ToLowerInvariant() switch
        {
            "chrome" => CreateChromeDriver(settings),
            "firefox" => CreateFirefoxDriver(settings),
            "edge" => CreateEdgeDriver(settings),
            _ => throw new ArgumentException($"Unsupported browser: {settings.Browser}")
        };
    }

    private static IWebDriver CreateChromeDriver(TestSettings settings)
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
        chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
        chromeOptions.AddArgument("--guest");
        if (settings.Headless)
        {
            chromeOptions.AddArgument("--headless");
        }
        return new ChromeDriver(chromeOptions);
    }

    private static IWebDriver CreateFirefoxDriver(TestSettings settings)
    {
        var firefoxOptions = new FirefoxOptions();
        firefoxOptions.SetPreference("signon.rememberSignons", false);
        firefoxOptions.SetPreference("signon.autofillForms", false);
        firefoxOptions.AddArgument("-private-window");
        if (settings.Headless)
        {
            firefoxOptions.AddArgument("--headless");
        }

        return new FirefoxDriver(firefoxOptions);
    }

    private static IWebDriver CreateEdgeDriver(TestSettings settings)
    {
        var edgeOptions = new EdgeOptions();
        edgeOptions.AddUserProfilePreference("credentials_enable_service", false);
        edgeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
        edgeOptions.AddArgument("--guest");
        if (settings.Headless)
        {
            edgeOptions.AddArguments("--headless");
        }
        return new EdgeDriver(edgeOptions);
    }
}