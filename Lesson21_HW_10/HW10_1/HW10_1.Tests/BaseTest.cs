using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HW10_1.Tests;

public class BaseTest
{
    protected IWebDriver Driver = null!;
    protected string DownloadDirectory = null!;
    [SetUp]
    public void Setup()
    {
        DownloadDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Downloads");
        Directory.CreateDirectory(DownloadDirectory);
        var options = new ChromeOptions
        {
            PageLoadStrategy = PageLoadStrategy.Eager
        };
        options.AddUserProfilePreference("download.default_directory", DownloadDirectory);
        options.AddUserProfilePreference("download.prompt_for_download",false);
        Driver = new ChromeDriver(options);
        Driver.Manage().Window.Maximize();
    }
    protected void WaitUntilFileExists(string filePath)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        wait.Until(_ => File.Exists(filePath));
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}