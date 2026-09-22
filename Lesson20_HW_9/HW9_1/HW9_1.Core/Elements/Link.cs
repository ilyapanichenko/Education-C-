using OpenQA.Selenium;

namespace HW9_1.Core.Elements;

public class Link : BaseElement
{
    public Link(IWebDriver driver, By locator) : base(driver, locator)
    {
    }

    public void Click()
    {
        WaitUntilElementClickable().Click();
    }
}