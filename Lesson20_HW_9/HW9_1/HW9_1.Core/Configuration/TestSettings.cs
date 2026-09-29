namespace HW9_1.Core.Configuration;

public class TestSettings
{
    public string Browser { get; set; } = string.Empty;
    public int TimeoutSeconds { get; set; }
    public string BaseUrl { get; set; } = string.Empty;
    public bool Headless { get; set; }
    public string ExecutionMode { get; set; } = string.Empty;
    public string GridUrl { get; set; } = string.Empty;
}