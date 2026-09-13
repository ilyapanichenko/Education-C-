using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HW10_1.Core.Pages;

public class DroppablePage(IWebDriver driver) : BasePage(driver)
{
    private readonly By _draggableLocator = By.Id("draggable");
    private readonly By _droppableLocator = By.Id("droppable");
    private readonly By _dropStatusLocator = By.Id("drop-status");

    private const string PageUrl = "https://www.selenium.dev/selenium/web/mouse_interaction.html";
    public void Open()
    {
        OpenPage(PageUrl);
    }
    public void DragToTarget()
    {
        var source = Driver.FindElement(_draggableLocator);
        var target = Driver.FindElement(_droppableLocator);
        var actions = new Actions(Driver);
        actions.DragAndDrop(source, target).Perform();
    }
    public void WaitUntilDropped()
    {
        WaitUntilTextEquals(_dropStatusLocator, "dropped");
    }
    public string GetDropText()
    {
        return GetText(_dropStatusLocator);
    }
}