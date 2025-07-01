using Application.PostRegisterUser.PostRegisterUser;
using FluentValidation;

namespace Application.Validators;

public class PostRegisterUserRequestValidator : AbstractValidator<PostRegisterUserRequest>
{
  public PostRegisterUserRequestValidator()
  {
      RuleFor(model => model.Data.Email).EmailAddress().Length(4, 50);
      RuleFor(model => model.Data.FirstName).NotEmpty().Length(1, 50);
      RuleFor(model => model.Data.LastName).NotEmpty().Length(1, 50);
      RuleFor(model => model.Data.Password)
        .NotEmpty()
        .Length(8, 50)
        .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
        .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
        .Matches("[0-9]").WithMessage("Password must contain at least one number")
        .Matches(@"[!""#$%&'()*+,\-./:;<=>?@\[\\\]^_`{|}~]").WithMessage("Password must contain at least one special character of the followings: !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~");
  }
}
