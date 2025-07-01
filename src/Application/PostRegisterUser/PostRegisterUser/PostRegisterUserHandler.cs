using Application.Common;
using Application.Services;
using Application.Tools;
using Domain.Entities;
using FluentValidation;

namespace Application.PostRegisterUser.PostRegisterUser;

public sealed class PostRegisterUserHandler(IServiceProvider serviceProvider, IValidator<PostRegisterUserRequest> validator, IUserDataService userDataService, JwtAuthenticationDataService jwtAuthenticationDataService, IRefreshTokenRepositoryService refreshTokenRepositoryService) : BaseHandler<PostRegisterUserRequest, PostRegisterUserResponse>(serviceProvider)
{
    public override async Task<PostRegisterUserResponse> ExecuteAsync(PostRegisterUserRequest command, CancellationToken ct)
    {
      command.Data.Trim();
      var validationResult = await validator.ValidateAsync(command, ct);
      if (!validationResult.IsValid)
      {
        return new PostRegisterUserValidationFailedResponse(validationResult);
      }

      if (await userDataService.CheckIfEmailExists(command.Data.Email, ct))
      {
        return new PostRegisterUserMailAlreadyExistsResponse();
      }

      var user = new UserDto
      {
        Email = command.Data.Email,
        EmailConfirmed = false,
        Active = true,
        Firstname = command.Data.FirstName,
        Lastname = command.Data.LastName,
        PasswordHash = PasswordHasher.HashPassword(command.Data.Password)
      };
      await userDataService.RegisterUser(user, ct);
      var (jwtToken, expiration) = jwtAuthenticationDataService.GenerateJwtToken(user);
      return new PostRegisterUserOkResponse()
      {
        Token = jwtToken, 
        ExpiresUtc = expiration,
        RefreshToken = await refreshTokenRepositoryService.GetRenewedRefreshTokenStringIfNecessary(user.EntityId, ct)
      };
    }
}
