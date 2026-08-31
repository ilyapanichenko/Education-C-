using HW10_1.Core.Pages;

namespace HW10_1.Tests.DemoQa;

public class DownloadPageTests : BaseTest
{
    private UploadDownloadPage _uploadDownloadPage = null!;
    [SetUp]
    public void SetupPage()
    {
        _uploadDownloadPage = new UploadDownloadPage(Driver);
    }
    [Test]
    public void Download()
    {
        var expectedFilePath = Path.Combine(DownloadDirectory, "sampleFile.jpeg");
        if (File.Exists(expectedFilePath))
        {
            File.Delete(expectedFilePath);
        }
        _uploadDownloadPage.Open();
        _uploadDownloadPage.DownloadFile();
        WaitUntilFileExists(expectedFilePath);
        Assert.That(File.Exists(expectedFilePath), Is.True);
    }
}