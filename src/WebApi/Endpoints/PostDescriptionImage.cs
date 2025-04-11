using Application.PostDescriptionImage.PostDescriptionImage;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostDescriptionImage)]
public class PostDescriptionImage : JsonResponseEndpoint<PostDescriptionImageRequest, PostDescriptionImageResponse>;