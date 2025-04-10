using System.Net;
using Application.Common;
using Application.Common.Response;
using Application.Messages;
using Application.Models.ApiModels;
using Application.Models.ProjectService;
using Common;
using FluentValidation.Results;

namespace Application.PostProject.PostProject;

public class PostProjectResponse : JsonResponse
{
    
}

public class PostProjectOkResponse : PostProjectResponse
{
    public required ApiProject Project { get; init; }
}

public class PostProjectValidationFailedResponse : PostProjectResponse
{
    public PostProjectValidationFailedResponse(ValidationResult validationResult)
    {
        StatusCode = HttpStatusCode.BadRequest;
        Error = validationResult.ToErrorResponseData();
    }
}

public class PostProjectNotAllowedResponse : PostProjectResponse
{
    public PostProjectNotAllowedResponse(Message reason)
    {
        StatusCode = HttpStatusCode.Forbidden;
        Error = new ErrorResponseData() { Message = reason };
    }
}


public class PostProjectCreationFailedResponse : PostProjectResponse
{
    public PostProjectCreationFailedResponse(CreateorUpdateProjectResult createorUpdateProjectResult)
    {
        StatusCode = HttpStatusCode.InternalServerError;
        Error = new ErrorResponseData()
        {
            Message = CommonMessages.InternalServerError(),
            RelatedException = createorUpdateProjectResult.Exception
        };
    }
}

