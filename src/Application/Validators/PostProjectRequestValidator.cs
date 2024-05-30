using Application.Models;
using Application.PostProject.PostProject;
using FluentValidation;

namespace Application.Validators;

public class PostProjectRequestValidator : AbstractValidator<PostProjectRequest>
{
    public PostProjectRequestValidator()
    {
        RuleFor(model => model.Project).NotNull().SetValidator(new ProjectValidator());
        
        
    }
}