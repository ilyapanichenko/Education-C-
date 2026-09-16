using log4net.Config;
using NUnit.Framework;

[assembly: LevelOfParallelism(2)]

[assembly: XmlConfigurator(
    ConfigFile = "Configuration/log4net.config",
    Watch = true)]