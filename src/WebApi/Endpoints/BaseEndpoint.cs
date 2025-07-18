using System.Reflection;
using Application.Common;
using Application.Common.Response;
using FastEndpoints;
using WebApi.Attributes.Authorization;
using WebApi.Common;
using HttpGetAttribute = WebApi.Attributes.HttpGetAttribute;
using HttpPutAttribute = WebApi.Attributes.HttpPutAttribute;
using HttpPostAttribute = WebApi.Attributes.HttpPostAttribute;
using HttpDeleteAttribute = WebApi.Attributes.HttpDeleteAttribute;
using HttpPatchAttribute = WebApi.Attributes.HttpPatchAttribute;

namespace WebApi.Endpoints;

public abstract class BaseEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
    where TRequest : BaseRequest<TResponse>
    where TResponse : BaseResponse
{
    public override void Configure()
    {
        var t = this.GetType();
        HandleAttributes<HttpGetAttribute>(t, HandleHttpGetAttribute);
        HandleAttributes<HttpPostAttribute>(t, HandleHttpPostAttribute);
        HandleAttributes<HttpPatchAttribute>(t, HandleHttpPatchAttribute);
        HandleAttributes<HttpPutAttribute>(t, HandleHttpPutAttribute);
        HandleAttributes<HttpDeleteAttribute>(t, HandleHttpDeleteAttribute);
        HandleAttributes<AllowAttribute>(t, HandleAllowAttribute);
        HandleAttributes<TagsAttribute>(t, HandleTagsAttribute);
    }


    private void HandleAttributes<T>(Type t, Action<T[]> callback) where T : Attribute
    {
        while (true)
        {
            var foundAttributes = t.GetCustomAttributes<T>(false).ToArray();
            if (foundAttributes.Length == 0)
            {
                if (t.BaseType == null || t.BaseType.DeclaringType == typeof(Endpoint<>).DeclaringType)
                    return;

                t = t.BaseType;
                continue;
            }

            callback(foundAttributes);
            break;
        }
    }

    private void AcceptNotMoreThanOneAttribute<T>(T[] attributes) where T : Attribute
    {
        if (attributes.Length > 1)
            throw new InvalidOperationException($"There is more than one attribute of {typeof(T).Name} in {this.GetType().Name}");
    }
    private void HandleHttpGetAttribute(HttpGetAttribute[] httpGetAttributes)
    {
        AcceptNotMoreThanOneAttribute(httpGetAttributes);
        Get(httpGetAttributes.First().RouteTemplate);
    }
    private void HandleHttpPostAttribute(HttpPostAttribute[] httpPostAttributes)
    {
        AcceptNotMoreThanOneAttribute(httpPostAttributes);
        Post(httpPostAttributes.First().RouteTemplate);
    }
    private void HandleHttpDeleteAttribute(HttpDeleteAttribute[] httpDeleteAttributes)
    {
        AcceptNotMoreThanOneAttribute(httpDeleteAttributes);
        Delete(httpDeleteAttributes.First().RouteTemplate);
    }
    private void HandleHttpPatchAttribute(HttpPatchAttribute[] httpPatchAttributes)
    {
        AcceptNotMoreThanOneAttribute(httpPatchAttributes);
        Patch(httpPatchAttributes.First().RouteTemplate);
    }
    private void HandleHttpPutAttribute(HttpPutAttribute[] httpPutAttributes)
    {
        AcceptNotMoreThanOneAttribute(httpPutAttributes);
        Put(httpPutAttributes.First().RouteTemplate);
    }
    
    private void HandleAllowAttribute(AllowAttribute[] allowAttributes)
    {
        AcceptNotMoreThanOneAttribute(allowAttributes);
        var attr = allowAttributes.First();
        if (attr.AuthorizationObjects.Contains(AuthorizationObject.Anonymous))
        {
          AllowAnonymous();
        }
        else if (attr.AuthorizationObjects.Contains(AuthorizationObject.AuthenticatedWithUnconfirmedEmail))
        {
          
        }
        else if (attr.AuthorizationObjects.Contains(AuthorizationObject.Administrator))
        {
            Policy(x => x.RequireAssertion(y => y.User.ToUserData()?.IsAdmin ?? false));
        }
        else
        {
          Policy(x => x.RequireClaim(ClaimsPrincipalUserData.EMailIsConfirmed, "true"));
        }
    }
    
    private void HandleTagsAttribute(TagsAttribute[] tagsAttributes)
    {
        foreach (var tags in tagsAttributes)
        {
            Tags(tags.Tags.ToArray());
        }
    }
    
    protected abstract Task HandleResult(TResponse response, CancellationToken ct);

    private Task HandleError(TResponse response, CancellationToken ct)
    {
        var request = HttpContext.Request;
        var errorResponse = response.Error!.BuildErrorResponse(request.Method, request.GetUri().AbsoluteUri);
        Logger.LogError(errorResponse.ToException(), "The following error was produced inside an http request:");
        return HttpContext.Response.SendAsync(errorResponse, (int)response.StatusCode, cancellation: ct);
    }

    public override async Task HandleAsync(TRequest req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        if (!response.Success)
        {
            await HandleError(response, ct);
            return;
        }

        response.ApplyHeaders((key, value) =>
        {
            this.HttpContext.Response.Headers[key] = value;
        });
        
        await HandleResult(response, ct);
    }
}

public class EmptyResponseEndpoint<TRequest, TResponse> : BaseEndpoint<TRequest, TResponse> 
    where TRequest : BaseRequest<TResponse>
    where TResponse : EmptyStatusCodeResponse
{
    protected override Task HandleResult(TResponse response, CancellationToken ct)
    {
        return SendStringAsync("", (int)response.StatusCode, cancellation:ct);
    }
}

public class StringResponseEndpoint<TRequest, TResponse> : BaseEndpoint<TRequest, TResponse> 
    where TRequest : BaseRequest<TResponse>
    where TResponse : StringResponse
{
    protected override Task HandleResult(TResponse response, CancellationToken ct)
    {
        return SendStringAsync(response.Content, (int)response.StatusCode, response.ContentType, cancellation:ct);
    }
}

public class FileInfoResponseEndpoint<TRequest, TResponse> : BaseEndpoint<TRequest, TResponse> 
    where TRequest : BaseRequest<TResponse>
    where TResponse : FileInfoResponse
{
    protected override Task HandleResult(TResponse response, CancellationToken ct)
    {
        return SendFileAsync(response.FileInfo, response.ContentType, response.LastModified, cancellation: ct);
    }
}

public class FileBytesResponseEndpoint<TRequest, TResponse> : BaseEndpoint<TRequest, TResponse> 
    where TRequest : BaseRequest<TResponse>
    where TResponse : FileBytesResponse
{
    protected override Task HandleResult(TResponse response, CancellationToken ct)
    {
        if (response.IsInline)
        {
            this.HttpContext.Response.Headers["Content-Disposition"] = $"inline; filename=\"{response.FileName}\"";
        }

        return SendBytesAsync(response.Content ?? [], response.IsInline ? null : response.FileName, response.ContentType ?? "application/octet-stream", response.LastModified, cancellation: ct);
    }
}

public class JsonResponseEndpoint<TRequest, TResponse> : BaseEndpoint<TRequest, TResponse> 
    where TRequest : BaseRequest<TResponse>
    where TResponse : JsonResponse
{
    protected override Task HandleResult(TResponse response, CancellationToken ct)
    {
        return SendAsync(response, (int)response.StatusCode, cancellation: ct);
    }
}
