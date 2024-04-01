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
    public static string NullOrEmpty(string? parameter, Message? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        if (string.IsNullOrEmpty(parameter))
            throw new ArgumentNullException(parameterName, message?.ToString());
        return parameter;
    }
    public static IEnumerable<T> NullOrEmpty<T>(IEnumerable<T>? parameter, Message? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        // ReSharper disable PossibleMultipleEnumeration
        if (parameter == null || parameter.Any())
            throw new ArgumentNullException(parameterName, message?.ToString());
        return parameter;
        // ReSharper restore PossibleMultipleEnumeration
    }
    public static T[] NullOrEmpty<T>(T[]? parameter, Message? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        if (parameter is not { Length: 0 })
            throw new ArgumentNullException(parameterName, message?.ToString());
        return parameter;
    }
    public static string NullOrWhitespace(string? parameter, Message? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        if (string.IsNullOrWhiteSpace(parameter))
            throw new ArgumentNullException(parameterName, message?.ToString());
        return parameter;
    }
}
