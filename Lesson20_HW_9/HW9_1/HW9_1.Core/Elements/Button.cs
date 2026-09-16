using OpenQA.Selenium;

namespace HW9_1.Core.Elements;

public class Button : BaseElement
{
    public Button(IWebDriver driver, By locator) : base(driver, locator)
    {
    }

    public void Click()
    {
        WaitUntilElementClickable().Click();
    }
}