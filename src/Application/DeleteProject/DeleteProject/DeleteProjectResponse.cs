using System.Net;
using Application.Common.Response;
using Application.Messages;
using Common;

namespace Application.DeleteProject.DeleteProject;

public class DeleteProjectResponse : JsonResponse
{
    
}

public class DeleteProjectOkResponse : DeleteProjectResponse
{
    public DeleteProjectOkResponse()
    {
        StatusCode = HttpStatusCode.OK;
    }
}

public class DeleteProjectEntityNotFoundResponse : DeleteProjectResponse
{
    public DeleteProjectEntityNotFoundResponse(Guid entity)
    {
        StatusCode = HttpStatusCode.NotFound;
        Error = new ErrorResponseData() { Message = ProjectMessages.EntityNotFound(entity) };
    }
}


public class DeleteProjectNotAllowedResponse : DeleteProjectResponse
{
    public DeleteProjectNotAllowedResponse(Message reason)
    {
        StatusCode = HttpStatusCode.Forbidden;
        Error = new ErrorResponseData() { Message = reason };
    }
}

