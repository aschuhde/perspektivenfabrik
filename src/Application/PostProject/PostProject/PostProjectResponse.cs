using System.Net;
using Application.Common;
using Application.Common.Response;
using Application.Models;
using Application.Models.ApiModels;
using Application.Models.ProjectService;
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

public class PostProjectCreationFailedResponse : PostProjectResponse
{
    public PostProjectCreationFailedResponse(CreateProjectResult createProjectResult)
    {
        StatusCode = createProjectResult.DesiredStatusCode ?? HttpStatusCode.BadRequest;
        Error = createProjectResult.ToErrorResponseData();
    }
}

