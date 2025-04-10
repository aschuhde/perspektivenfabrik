using Application.PutProject.PutProject;
using FluentValidation;

namespace Application.Validators;

public class PutProjectRequestValidator : AbstractValidator<PutProjectRequest>
{
    public PutProjectRequestValidator()
    {
        RuleFor(model => model.Project).NotNull().SetValidator(new ProjectValidator());
    }
}