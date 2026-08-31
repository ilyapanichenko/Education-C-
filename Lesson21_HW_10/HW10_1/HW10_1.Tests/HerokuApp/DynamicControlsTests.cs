using HW10_1.Core.Pages;

namespace HW10_1.Tests.HerokuApp;

public class DynamicControlsTests : BaseTest
{
    private DynamicControlsPage _dynamicControlsPage = null!;
    [SetUp]
    public void SetupPage()
    {
        _dynamicControlsPage = new DynamicControlsPage(Driver);
    }

    [Test]
    public void CheckboxAndInput()
    {
        _dynamicControlsPage.Open();
        Assert.That(_dynamicControlsPage.IsCheckboxPresent(), Is.True);
        _dynamicControlsPage.RemoveCheckbox();
        _dynamicControlsPage.WaitUntilMessage("It's gone!");
        _dynamicControlsPage.WaitUntilCheckboxAbsent();
        Assert.That(_dynamicControlsPage.GetMessageText(),Is.EqualTo("It's gone!"));
        Assert.That(_dynamicControlsPage.IsCheckboxPresent(), Is.False);
        Assert.That(_dynamicControlsPage.IsInputEnabled(), Is.False);
        _dynamicControlsPage.EnableInput();
        _dynamicControlsPage.WaitUntilMessage("It's enabled!");
        Assert.That(_dynamicControlsPage.GetMessageText(), Is.EqualTo("It's enabled!"));
        Assert.That(_dynamicControlsPage.IsInputEnabled(), Is.True);
    }
}