using Application.PutMaterials.PutMaterials;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPut(Constants.Routes.PutMaterials)]
[Allow(AuthorizationObject.Administrator)]
public sealed class PutMaterials : JsonResponseEndpoint<PutMaterialsRequest, PutMaterialsResponse>;