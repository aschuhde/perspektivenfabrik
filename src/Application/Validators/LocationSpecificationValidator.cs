using Application.Models.ApiModels;
using FluentValidation;

namespace Application.Validators;

public class LocationSpecificationValidator : AbstractValidator<ApiLocationSpecification>
{
    public LocationSpecificationValidator()
    {
        
    }
}