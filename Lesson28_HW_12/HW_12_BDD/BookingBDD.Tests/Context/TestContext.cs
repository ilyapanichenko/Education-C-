using OpenQA.Selenium;

namespace BookingBDD.Tests.Context;

public class TestContext
{
    public IWebDriver Driver { get; set; } = null!;
    public string HotelName { get; set; } = string.Empty;
}