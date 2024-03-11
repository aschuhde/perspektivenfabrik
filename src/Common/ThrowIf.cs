using System.Runtime.CompilerServices;

namespace Common;

public static class ThrowIf 
{
    public static T Null<T>(T? parameter, Message? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        if (parameter == null)
            throw new ArgumentNullException(parameterName, message?.ToString());
        return parameter;
    }
    public static T NullOrEmpty<T>(T? parameter, Message? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        if (string.IsNullOrEmpty(parameter?.ToString()))
            throw new ArgumentNullException(parameterName, message?.ToString());
        return parameter;
    }
    public static T NullOrWhitespace<T>(T? parameter, Message? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        if (string.IsNullOrWhiteSpace(parameter?.ToString()))
            throw new ArgumentNullException(parameterName, message?.ToString());
        return parameter;
    }
}
