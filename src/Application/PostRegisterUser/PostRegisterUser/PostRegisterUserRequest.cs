using Application.Common;

namespace Application.PostRegisterUser.PostRegisterUser;

public sealed class PostRegisterUserRequest : BaseRequest<PostRegisterUserResponse>
{
    public required PostRegisterUserRequestBody Data { get; init; }
}

public sealed class PostRegisterUserRequestBody
{
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string LanguageCode { get; set; }
    public required string Password { get; set; }
    public required string DateOfBirth { get; set; } //Honeypot
    public required bool ConsentPrivacy { get; set; } //Honeypot

    public void Trim()
    {
      Email = Email.Trim();
      FirstName = FirstName.Trim();
      LastName = LastName.Trim();
      Password = Password.Trim();     
    }
}
