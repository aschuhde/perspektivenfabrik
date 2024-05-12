namespace WebApi.Attributes.Authorization;

public sealed class AllowAndAttribute<TAllowAttribute1, TAllowAttribute2> : Attribute 
    where TAllowAttribute1 : AllowAttribute
    where TAllowAttribute2 : AllowAttribute
{
}
