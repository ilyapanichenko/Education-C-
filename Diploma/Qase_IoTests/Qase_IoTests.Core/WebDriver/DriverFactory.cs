using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Qase_IoTests.Core.Configuration;

namespace Qase_IoTests.Core.WebDriver;

public static class DriverFactory
{
    public static IWebDriver CreateDriver()
    {
        var browser = TestConfig.BrowserSettings.Browser.ToLowerInvariant();
        var headless = TestConfig.BrowserSettings.Headless;
        var driver = browser switch
        {
            "chrome" => CreateChromeDriver(headless),
            "firefox" => CreateFirefoxDriver(headless),
            "edge" => CreateEdgeDriver(headless),
            _ => throw new ArgumentException($"Unsupported browser: {browser}")
        };

        if (!headless)
            driver.Manage().Window.Maximize();
        return driver;
    }

    private static IWebDriver CreateChromeDriver(bool headless)
    {
        var options = new ChromeOptions();

        if (headless)
            options.AddArgument("--headless=new");

        options.AddArgument("--window-size=1920,1080");

        return new ChromeDriver(options);
    }

    private static IWebDriver CreateFirefoxDriver(bool headless)
    {
        var options = new FirefoxOptions();

        if (headless)
            options.AddArgument("-headless");

        options.AddArgument("--width=1920");
        options.AddArgument("--height=1080");

        return new FirefoxDriver(options);
    }

    private static IWebDriver CreateEdgeDriver(bool headless)
    {
        var options = new EdgeOptions();

        if (headless)
            options.AddArgument("--headless=new");

        options.AddArgument("--window-size=1920,1080");

        return new EdgeDriver(options);
    }
}