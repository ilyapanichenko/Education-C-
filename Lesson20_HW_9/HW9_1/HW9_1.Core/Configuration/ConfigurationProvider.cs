using System.Text.Json;

namespace HW9_1.Core.Configuration;

public class ConfigurationProvider
{
    private static readonly string ConfigPath = Path.Combine(AppContext.BaseDirectory, "Config", "testsettings.json");
    public static TestSettings GetSettings()
    {
        if (!File.Exists(ConfigPath))
        {
            throw new FileNotFoundException($"Config file not found: {ConfigPath}");
        }

        string json = File.ReadAllText(ConfigPath);
        TestSettings? settings = JsonSerializer.Deserialize<TestSettings>(json);
        return settings ?? throw new InvalidOperationException("Failed to deserialize test settings.");
    }
}