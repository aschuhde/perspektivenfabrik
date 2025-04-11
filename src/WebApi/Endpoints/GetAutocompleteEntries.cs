using Application.GetAutocompleteEntries.GetAutocompleteEntries;
using Application.Example.GetExample;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetAutocompleteEntries)]
[Allow(AuthorizationObject.Anonymous)]
public class GetAutocompleteEntries : JsonResponseEndpoint<GetAutocompleteEntriesRequest, GetAutocompleteEntriesResponse>;