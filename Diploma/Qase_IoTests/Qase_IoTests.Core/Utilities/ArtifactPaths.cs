namespace Qase_IoTests.Core.Utilities;

public static class ArtifactPaths
{
    public static string Root { get; } = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "artifacts"));
    public static string Logs => Path.Combine(Root, "logs");
    public static string Screenshots => Path.Combine(Root, "screenshots");
}