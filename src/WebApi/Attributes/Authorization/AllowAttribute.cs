using WebApi.Common;

namespace WebApi.Attributes.Authorization;

public class AllowAttribute(params AuthorizationObject[] authorizationObjects) : Attribute
{
    public AuthorizationObject[] AuthorizationObjects { get; } = authorizationObjects;
}
