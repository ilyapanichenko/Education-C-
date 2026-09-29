using System.Text.Json;

namespace HW9_1.Core.Configuration;

public class ConfigurationProvider
{
    private static readonly string ConfigPath = Path.Combine(AppContext.BaseDirectory, "Config", "testsettings.json");

    public static TestSettings GetSettings()
    {
        if (!File.Exists(ConfigPath)) throw new FileNotFoundException($"Config file not found: {ConfigPath}");

        var json = File.ReadAllText(ConfigPath);
        var settings = JsonSerializer.Deserialize<TestSettings>(json) ?? throw new InvalidOperationException("Failed to deserialize test settings.");
        var executionMode = Environment.GetEnvironmentVariable("EXECUTION_MODE");
        if (!string.IsNullOrWhiteSpace(executionMode))
        {
            settings.ExecutionMode = executionMode;
        }
        var gridUrl = Environment.GetEnvironmentVariable("GRID_URL");
        if (!string.IsNullOrWhiteSpace(gridUrl))
        {
            settings.GridUrl = gridUrl;
        }
        var browser = Environment.GetEnvironmentVariable("BROWSER");
        if (!string.IsNullOrWhiteSpace(browser))
        {
            settings.Browser = browser;
        }
        return settings;
    }
}