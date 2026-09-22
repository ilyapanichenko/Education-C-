using OpenQA.Selenium;

namespace HW9_1.Core.Elements;

public class TextBox : BaseElement
{
    public TextBox(IWebDriver driver, By locator) : base(driver, locator)
    {
    }
    public void SetText(string text)
    {
        var element = WaitUntilElementClickable();
        element.Clear();
        element.SendKeys(text);
    }
}