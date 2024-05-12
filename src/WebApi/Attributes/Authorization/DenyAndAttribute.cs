namespace WebApi.Attributes.Authorization;

public sealed class DenyAndAttribute<TDenyAttribute1, TDenyAttribute2> : Attribute 
    where TDenyAttribute1 : DenyAttribute
    where TDenyAttribute2 : DenyAttribute
{
}
