namespace WebApi.Attributes.Authorization;

public sealed class AllowOrAttribute<TAllowAttribute1, TAllowAttribute2> : Attribute 
    where TAllowAttribute1 : AllowAttribute
    where TAllowAttribute2 : AllowAttribute
{
}
