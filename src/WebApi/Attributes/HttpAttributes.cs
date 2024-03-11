namespace WebApi.Attributes;

public class HttpGetAttribute(string RouteTemplate) : Attribute
{
    public string RouteTemplate { get; } = RouteTemplate;
}
public class HttpPostAttribute(string RouteTemplate) : Attribute
{
    public string RouteTemplate { get; } = RouteTemplate;
}
public class HttpPatchAttribute(string RouteTemplate) : Attribute
{
    public string RouteTemplate { get; } = RouteTemplate;
}
public class HttpPutAttribute(string RouteTemplate) : Attribute
{
    public string RouteTemplate { get; } = RouteTemplate;
}
public class HttpDeleteAttribute(string RouteTemplate) : Attribute
{
    public string RouteTemplate { get; } = RouteTemplate;
}
