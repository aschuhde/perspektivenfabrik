using Application.PostProjectImage.PostProjectImage;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostProjectImage)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public class PostProjectImage : JsonResponseEndpoint<PostProjectImageRequest, PostProjectImageResponse>;