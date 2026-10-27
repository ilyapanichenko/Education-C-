using OpenQA.Selenium;
namespace Qase_IoTests.Core.Utilities;

public static class ScreenshotHelper
{
    public static string Save(IWebDriver driver, string testName)
    {
        var directory = ArtifactPaths.Screenshots;
        Directory.CreateDirectory(directory);
        var safeName = new string(testName.Select(c => char.IsLetterOrDigit(c) || c == '_' || c == '-' ? c : '_').ToArray()).Trim('_');
        if (string.IsNullOrEmpty(safeName))
            safeName = "UnknownTest";
        if (safeName.Length > 40)
            safeName = safeName[..40];
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
        var uniqueId = Guid.NewGuid().ToString("N")[..8];
        var filePath = Path.Combine(directory, $"{timestamp}_{safeName}_{uniqueId}.png");
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile(filePath);
        return filePath;
    }
}