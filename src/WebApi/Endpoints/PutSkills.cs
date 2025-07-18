using Application.PutSkills.PutSkills;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPut(Constants.Routes.PutSkills)]
[Allow(AuthorizationObject.Administrator)]
public sealed class PutSkills : JsonResponseEndpoint<PutSkillsRequest, PutSkillsResponse>;