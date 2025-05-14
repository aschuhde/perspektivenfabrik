using Application.GetProjectImage.GetProjectImage;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetProjectImage)]
[Allow(AuthorizationObject.Anonymous)]
public class GetProjectImage : FileBytesResponseEndpoint<GetProjectImageRequest, GetProjectImageResponse>;