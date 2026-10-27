using BookingBDD.Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BookingBDD.Core.Pages;

public class BookingSearchPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    private static readonly By SearchField = By.Id("searchbox-horizontal-destination-input");
    private static readonly By SearchButton = By.CssSelector("button[type='submit']");
    private static readonly By GeniusCloseButton = By.CssSelector("[role='dialog'] button[aria-label]");
    public BookingSearchPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TestSettings.DefaultTimeout);
    }

    public void Open()
    {
        _driver.Navigate().GoToUrl("https://www.booking.com/searchresults.en-gb.html?ss=London&lang=en-gb");
        CloseGeniusPopupIfPresent();
    }

    public SearchResultsPage SearchHotel(string hotelName)
    {
        var searchField = _wait.Until(driver => driver.FindElements(SearchField).FirstOrDefault(element => element.Displayed && element.Enabled))!;
        searchField.Clear();
        searchField.SendKeys(hotelName);
        _wait.Until(driver => driver.FindElements(SearchButton).FirstOrDefault(element => element.Displayed && element.Enabled))!.Click();
        return new SearchResultsPage(_driver);
    }
    private void CloseGeniusPopupIfPresent()
    {
        _driver.FindElements(GeniusCloseButton).FirstOrDefault()?.Click();
    }
}