using System.Net;
using Application.Common;
using Application.Common.Response;
using Application.Messages;
using Application.Models.ApiModels;
using Application.Models.ProjectService;
using Common;
using FluentValidation.Results;

namespace Application.PutProject.PutProject;

public class PutProjectResponse : JsonResponse
{
    
}

public class PutProjectOkResponse : PutProjectResponse
{
    public required ApiProject Project { get; init; }
}

public sealed class PutProjectValidationFailedResponse : PutProjectResponse
{
    public PutProjectValidationFailedResponse(ValidationResult validationResult)
    {
        StatusCode = HttpStatusCode.BadRequest;
        Error = validationResult.ToErrorResponseData();
    }
}

public sealed class PutProjectNotAllowedResponse : PutProjectResponse
{
    public PutProjectNotAllowedResponse(Message reason)
    {
        StatusCode = HttpStatusCode.Forbidden;
        Error = new ErrorResponseData() { Message = reason };
    }
}

public sealed class PutProjectEntityNotFoundResponse : PutProjectResponse
{
    public PutProjectEntityNotFoundResponse(Guid entity)
    {
        StatusCode = HttpStatusCode.NotFound;
        Error = new ErrorResponseData() { Message = ProjectMessages.EntityNotFound(entity) };
    }
}

public sealed class PutProjectUpdateFailedResponse : PutProjectResponse
{
    public PutProjectUpdateFailedResponse(CreateorUpdateProjectResult updateProjectResult)
    {
        StatusCode = HttpStatusCode.InternalServerError;
        Error = new ErrorResponseData()
        {
            Message = CommonMessages.InternalServerError(),
            RelatedException = updateProjectResult.Exception
        };
    }
}




