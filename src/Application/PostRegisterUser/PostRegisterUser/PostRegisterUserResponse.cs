using System.Net;
using System.Text.Json.Serialization;
using Application.Common;
using Application.Common.Response;
using FluentValidation.Results;

namespace Application.PostRegisterUser.PostRegisterUser;

public class PostRegisterUserResponse : JsonResponse
{
    public PostRegisterUserResponseStatus Status { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PostRegisterUserResponseStatus
{
  Ok, MailAlreadyExists, BadRequest
}

public sealed class PostRegisterUserValidationFailedResponse : PostRegisterUserResponse
{
  public PostRegisterUserValidationFailedResponse(ValidationResult validationResult)
  {
    StatusCode = HttpStatusCode.BadRequest;
    Status = PostRegisterUserResponseStatus.BadRequest;
    Error = validationResult.ToErrorResponseData();
  }
}
public sealed class PostRegisterUserOkResponse : PostRegisterUserResponse
{
  public PostRegisterUserOkResponse()
  {
    Status = PostRegisterUserResponseStatus.Ok;
  }  
  public string? Token { get; init; }
  public string? RefreshToken { get; init; }
  public DateTimeOffset? ExpiresUtc { get; init; }
}

public sealed class PostRegisterUserMailAlreadyExistsResponse : PostRegisterUserResponse
{
  public PostRegisterUserMailAlreadyExistsResponse()
  {
    Status = PostRegisterUserResponseStatus.MailAlreadyExists;
  }
}
