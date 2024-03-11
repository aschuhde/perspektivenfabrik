using System.Diagnostics;
using System.Text;

namespace WebApi.Common;

public class CustomTraceListener : TraceListener
{
    private readonly ILogger _iLogger;
    private readonly StringBuilder _stringBuilder = new();

    public CustomTraceListener(ILoggerFactory loggerFactory)
    {
        _iLogger =
            loggerFactory.CreateLogger(nameof(CustomTraceListener));
    }

    public override void Write(string? message, string? category)
    {
        _stringBuilder.Append(message + "-" + category);
    }

    public override void Write(string? message)
    {
        _stringBuilder.Append(message);
    }

    public override void WriteLine(string? message)
    {
        _stringBuilder.AppendLine(message);
        _iLogger.LogTrace(_stringBuilder.ToString());
        _stringBuilder.Clear();
    }
}
