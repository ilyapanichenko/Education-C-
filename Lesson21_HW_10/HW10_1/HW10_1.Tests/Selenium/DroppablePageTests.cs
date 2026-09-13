using HW10_1.Core.Pages;

namespace HW10_1.Tests.Selenium;

public class DroppablePageTests : BaseTest
{
    private DroppablePage _droppablePage = null!;

    [SetUp]
    public void SetupPage()
    {
        _droppablePage = new DroppablePage(Driver);
    }

    [Test]
    public void DragAndDrop()
    {
        _droppablePage.Open();
        _droppablePage.DragToTarget();
        _droppablePage.WaitUntilDropped();
        Assert.That(_droppablePage.GetDropText(), Is.EqualTo("dropped"));
    }
}