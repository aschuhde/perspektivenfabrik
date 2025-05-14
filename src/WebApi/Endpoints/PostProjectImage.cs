using Application.PostProjectImage.PostProjectImage;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostProjectImage)]
public class PostProjectImage : JsonResponseEndpoint<PostProjectImageRequest, PostProjectImageResponse>;