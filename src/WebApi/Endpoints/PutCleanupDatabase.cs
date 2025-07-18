using Application.PutCleanupDatabase.PutCleanupDatabase;
using Application.Example.GetExample;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPut(Constants.Routes.PutCleanupDatabase)]
[Allow(AuthorizationObject.Administrator)]
public sealed class PutCleanupDatabase : JsonResponseEndpoint<PutCleanupDatabaseRequest, PutCleanupDatabaseResponse>;