using System.Runtime.CompilerServices;

namespace Common;

public static class ThrowIf 
{
    public static string NullOrWhitespace(string? parameter, string? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        if (string.IsNullOrWhiteSpace(parameter))
            throw new ArgumentNullException(parameterName, message);
        return parameter;
    }
    public static T Null<T>(T? parameter, string? message = null, [CallerArgumentExpression("parameter")] string? parameterName = null)
    {
        if (parameter == null)
            throw new ArgumentNullException(parameterName, message);
        return parameter;
    }
}
