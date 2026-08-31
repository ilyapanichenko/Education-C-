using OpenQA.Selenium;
namespace HW10_1.Core.Pages;

public class DynamicControlsPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By _checkboxLocator = By.Id("checkbox");
    private readonly By _buttonCheckboxLocator = By.CssSelector("button[onclick='swapCheckbox()']");
    private readonly By _buttonInputLocator = By.CssSelector("button[onclick='swapInput()']");
    private readonly By _messageLocator = By.Id("message");
    private readonly By _inputFieldLocator = By.CssSelector("input[type='text']");
    private const string PageUrl = "https://the-internet.herokuapp.com/dynamic_controls";
    public void Open()
    {
        OpenPage(PageUrl);
    }
    public void RemoveCheckbox()
    {
        Click(_buttonCheckboxLocator);
    }
    public bool IsCheckboxPresent()
    {
        return IsElementPresent(_checkboxLocator);
    }
    public string GetMessageText()
    {
        return GetText(_messageLocator);
    }
    public bool IsInputEnabled()
    {
        return IsElementEnabled(_inputFieldLocator);
    }
    public void EnableInput()
    {
        Click(_buttonInputLocator);
    }
    public void WaitUntilCheckboxAbsent()
    {
        WaitUntilElementAbsent(_checkboxLocator);
    }
    public void WaitUntilMessage(string expectedText)
    {
        WaitUntilTextEquals(_messageLocator, expectedText);
    }
}