using System.Globalization;
using BookingBDD.Core.Pages;
using Reqnroll;
using TestContext = BookingBDD.Tests.Context.TestContext;

namespace BookingBDD.Tests.Step_Definitions;

[Binding]
public class HotelSearchSteps
{
    private readonly TestContext _context;
    private BookingSearchPage _searchPage = null!;
    private SearchResultsPage _resultsPage = null!;

    public HotelSearchSteps(TestContext context)
    {
        _context = context;
    }

    [Given(@"the user is on the Booking search page")]
    public void UserIsOnTheBookingSearchPage()
    {
        _searchPage = new BookingSearchPage(_context.Driver);
        _searchPage.Open();
    }

    [When(@"the user searches for ""(.*)""")]
    public void UserSearchesForHotel(string hotelName)
    {
        _context.HotelName = hotelName;
        _resultsPage = _searchPage.SearchHotel(hotelName);
    }

    [Then(@"the hotel ""(.*)"" should be displayed")]
    public void HotelShouldBeDisplayed(string hotelName)
    {
        var actualTitle = _resultsPage.GetHotelTitle(hotelName);
        Assert.That(actualTitle, Does.Contain(hotelName).IgnoreCase);
    }

    [Then(@"the hotel rating should be ""(.*)""")]
    public void HotelRatingShouldBeDisplayed(string expectedRating)
    {
        var actualRating = _resultsPage.GetHotelRating(_context.HotelName);
        var expected = decimal.Parse(expectedRating, CultureInfo.InvariantCulture);
        Assert.That(actualRating, Is.EqualTo(expected));
    }
}