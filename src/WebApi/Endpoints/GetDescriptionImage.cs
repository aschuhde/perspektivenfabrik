using Application.GetDescriptionImage.GetDescriptionImage;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetDescriptionImage)]
[Allow(AuthorizationObject.Anonymous)]
public class GetDescriptionImage : FileBytesResponseEndpoint<GetDescriptionImageRequest, GetDescriptionImageResponse>;