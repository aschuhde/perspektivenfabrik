using System.Reflection;
using Application.Common;
using Application.Common.Response;
using Application.NotFound;
using WebApi.Attributes;
using WebApi.Constants;

namespace WebApi.Endpoints;

public class NotFound<TRequest, TResponse>: JsonResponseEndpoint<TRequest, TResponse> 
    where TRequest : BaseRequest<TResponse> 
    where TResponse : JsonResponse
{
    public override void Configure()
    {
        Tags(KnownTags.SwaggerIgnore);
        AllowAnonymous();
        base.Configure();
    }
}

[HttpGet(Constants.Routes.NotFound)]
public class GetNotFound : NotFound<NotFoundRequest, NotFoundResponse>;

[HttpPost(Constants.Routes.NotFound)]
public class PostNotFound : NotFound<NotFoundRequest, NotFoundResponse>;

[HttpPut(Constants.Routes.NotFound)]
public class PutNotFound : NotFound<NotFoundRequest, NotFoundResponse>;

[HttpPatch(Constants.Routes.NotFound)]
public class PatchNotFound : NotFound<NotFoundRequest, NotFoundResponse>;

[HttpDelete(Constants.Routes.NotFound)]
public class DeleteNotFound : NotFound<NotFoundRequest, NotFoundResponse>;

