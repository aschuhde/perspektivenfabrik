using Application.Common;
using FastEndpoints;

namespace Application.RegisterGlobalAccessCookie.RegisterGlobalAccessCookie;

public class RegisterGlobalAccessCookieRequest : BaseRequest<RegisterGlobalAccessCookieResponse>
{
    [BindFrom("token")]
    [QueryParam]
    public string? GlobalAccessCookie { get; set; }
}

