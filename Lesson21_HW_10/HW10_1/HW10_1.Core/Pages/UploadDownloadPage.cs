using OpenQA.Selenium;

namespace HW10_1.Core.Pages;

public class UploadDownloadPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By _uploadButtonLocator = By.Id("uploadFile");
    private readonly By _uploadedFilePathLocator = By.Id("uploadedFilePath");
    private readonly By _downloadButtonLocator = By.Id("downloadButton");
    private const string PageUrl = "https://demoqa.com/upload-download";
    public void Open()
    {
        OpenPage(PageUrl);
    }
    public void UploadFile(string filePath)
    {
        SendKeys(_uploadButtonLocator, filePath);
    }
    public string GetUploadedFilePath()
    {
        return GetText(_uploadedFilePathLocator);
    }
    public void DownloadFile()
    {
        Click(_downloadButtonLocator);
    }
}