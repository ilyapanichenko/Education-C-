using System.Text.Json;

namespace Qase_IoTests.Core.Configuration;

public static class TestConfig
{
    public const string BaseUrl = "https://api.qase.io/";
    public const string ProjectCode = "DEMO";
    public static string ApiKey => Environment.GetEnvironmentVariable("QASE_API_KEY") ?? throw new InvalidOperationException("QASE_API_KEY is not set");
    public static string UiEmail => Environment.GetEnvironmentVariable("QASE_UI_EMAIL") ?? throw new InvalidOperationException("QASE_UI_EMAIL is not set");
    public static string UiPassword => Environment.GetEnvironmentVariable("QASE_UI_PASSWORD") ?? throw new InvalidOperationException("QASE_UI_PASSWORD is not set");
    public static BrowserSettings BrowserSettings { get; } = 
        JsonSerializer.Deserialize<BrowserSettings>(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
        ) ?? throw new InvalidOperationException("Invalid appsettings.json");
}