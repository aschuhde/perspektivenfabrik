namespace WebApi.Attributes;

public class HttpGetAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
public class HttpPostAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
public class HttpPatchAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
public class HttpPutAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
public class HttpDeleteAttribute(string routeTemplate) : Attribute
{
    public string RouteTemplate { get; } = routeTemplate;
}
