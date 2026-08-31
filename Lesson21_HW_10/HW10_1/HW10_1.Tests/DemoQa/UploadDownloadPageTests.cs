using HW10_1.Core.Pages;

namespace HW10_1.Tests.DemoQa;

public class UploadDownloadPageTests : BaseTest
{
    private UploadDownloadPage _uploadDownloadPage = null!;
    [SetUp]
    public void SetupPage()
    {
        _uploadDownloadPage = new UploadDownloadPage(Driver);
    }
    [Test]
    public void Upload()
    {
        var filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "text.txt");
        Assert.That(File.Exists(filePath), Is.True);
        var fileName = Path.GetFileName(filePath);
        _uploadDownloadPage.Open();
        _uploadDownloadPage.UploadFile(filePath);
        Assert.That(_uploadDownloadPage.GetUploadedFilePath(), Does.EndWith(fileName));
    }
}