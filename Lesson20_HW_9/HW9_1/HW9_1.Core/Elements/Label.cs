using OpenQA.Selenium;

namespace HW9_1.Core.Elements;

public class Label : BaseElement
{
    public Label(IWebDriver driver, By locator) : base(driver, locator)
    {
    }
    public string GetText()
    {
        return WaitUntilElementVisible().Text;
    }
}