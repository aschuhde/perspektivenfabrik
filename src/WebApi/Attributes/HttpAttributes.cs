namespace WebApi.Attributes;

public sealed class HttpGetAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
public sealed class HttpPostAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
public sealed class HttpPatchAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
public sealed class HttpPutAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
public sealed class HttpDeleteAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
