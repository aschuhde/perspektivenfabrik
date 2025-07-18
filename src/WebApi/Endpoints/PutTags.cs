using Application.PutTags.PutTags;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPut(Constants.Routes.PutTags)]
[Allow(AuthorizationObject.Administrator)]
public sealed class PutTags : JsonResponseEndpoint<PutTagsRequest, PutTagsResponse>;