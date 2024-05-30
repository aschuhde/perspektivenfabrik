using Application.Common.Response;
using FluentValidation.Results;

namespace Application.Common;

public static class ValidationResultExtensions
{
    public static ErrorResponseData ToErrorResponseData(this ValidationResult validationResult)
    {
        validationResult.Errors.Select(x => x.)
    }
}