using Microsoft.Extensions.Logging;

namespace NewNet6Features;

public partial class InstanceLoggingExample
{
    private readonly ILogger _logger;

    public InstanceLoggingExample(ILogger<InstanceLoggingExample> logger)
    {
        _logger = logger;
    }

    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{hostName}`")]
    public partial void CouldNotOpenSocket(string hostName);

    public void MethodThatLogs()
    {
        CouldNotOpenSocket("localhost");
    }
}