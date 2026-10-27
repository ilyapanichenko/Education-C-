using Qase_IoTests.Core.Utilities;
using Serilog;

namespace Qase_IoTests.Core.Logging;

public static class TestLogger
{
    private static readonly ILogger Logger = CreateLogger();
    private static ILogger CreateLogger()
    {
        Directory.CreateDirectory(ArtifactPaths.Logs);
        return new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(Path.Combine(ArtifactPaths.Logs, "tests-.log"), rollingInterval: RollingInterval.Day)
            .WriteTo.Console()
            .CreateLogger();
    }

    public static void Info(string message)
    {
        Logger.Information("{Message}", message);
    }

    public static void Warning(string message)
    {
        Logger.Warning("{Message}", message);
    }
    public static void Error(string message, Exception? exception = null)
    {
        Logger.Error(exception, "{Message}", message);
    }
}