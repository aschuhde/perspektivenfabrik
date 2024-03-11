using WebApi.Common;

namespace WebApi.Attributes.Authorization;

public class DenyAttribute(params AuthorizationObject[] authorizationObjects) : Attribute
{
    public AuthorizationObject[] AuthorizationObjects { get; } = authorizationObjects;
}
