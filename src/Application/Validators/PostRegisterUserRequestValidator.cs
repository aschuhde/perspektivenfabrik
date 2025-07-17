using Application.Messages;
using Application.PostRegisterUser.PostRegisterUser;
using FluentValidation;

namespace Application.Validators;

public class PostRegisterUserRequestValidator : AbstractValidator<PostRegisterUserRequest>
{
  public PostRegisterUserRequestValidator()
  {
      RuleFor(model => model.Data.ConsentPrivacy).Must(x => x);
      RuleFor(model => model.Data.Email).EmailAddress().Length(4, 100);
      RuleFor(model => model.Data.FirstName).NotEmpty().Length(1, 100);
      RuleFor(model => model.Data.LastName).NotEmpty().Length(1, 100);
      RuleFor(model => model.Data.Password)
        .NotEmpty()
        .Length(8, 50)
        .Matches("[a-z]").WithMessage(UserMessages.PasswordNeedsLowercaseLetter().Content)
        .Matches("[A-Z]").WithMessage(UserMessages.PasswordNeedsUppercaseLetter().Content)
        .Matches("[0-9]").WithMessage(UserMessages.PasswordNeedsNumber().Content)
        .Matches(@"[!""#$%&'()*+,\-./:;<=>?@\[\\\]^_`{|}~]").WithMessage(UserMessages.PasswordNeedsSpecialCharacter("!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~").Content);
  }
}
