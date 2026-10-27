using System.Globalization;
using System.Text.RegularExpressions;
using BookingBDD.Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace BookingBDD.Core.Pages;

public class SearchResultsPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    private static readonly By HotelCard = By.CssSelector("[data-testid='property-card']");
    private static readonly By HotelTitle = By.CssSelector("[data-testid='title']");
    private static readonly By HotelRating = By.CssSelector("[data-testid='review-score']");

    public SearchResultsPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TestSettings.DefaultTimeout);
        _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
    }

    public string GetHotelTitle(string hotelName)
    {
        return FindHotelCard(hotelName).FindElement(HotelTitle).Text;
    }

    public decimal GetHotelRating(string hotelName)
    {
        var ratingText = _wait.Until(driver =>
        {
            var card = driver.FindElements(HotelCard).FirstOrDefault(card => card.FindElements(HotelTitle).Any(title => title.Text.Contains(hotelName, StringComparison.OrdinalIgnoreCase)));
            return card?.FindElements(HotelRating).Select(element => element.Text).FirstOrDefault(text => !string.IsNullOrWhiteSpace(text));
        });
        var rating = Regex.Match(ratingText, @"\d+(?:[.,]\d+)?").Value.Replace(',', '.');
        return decimal.Parse(rating, CultureInfo.InvariantCulture);
    }

    private IWebElement FindHotelCard(string hotelName)
    {
        return _wait.Until(driver => driver.FindElements(HotelCard).FirstOrDefault(card => card.FindElements(HotelTitle).Any(title => title.Text.Contains(hotelName, StringComparison.OrdinalIgnoreCase))))!;
    }
}