namespace WebApi.Attributes.Authorization;

public sealed class DenyOrAttribute<TDenyAttribute1, TDenyAttribute2> : Attribute 
    where TDenyAttribute1 : DenyAttribute
    where TDenyAttribute2 : DenyAttribute
{
}
