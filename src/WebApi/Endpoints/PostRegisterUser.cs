using Application.PostRegisterUser.PostRegisterUser;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostRegisterUser)]
[Allow(AuthorizationObject.Anonymous)]
public sealed class PostRegisterUser : JsonResponseEndpoint<PostRegisterUserRequest, PostRegisterUserResponse>;