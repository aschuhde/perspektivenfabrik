using Application.Common;
using Application.Messages;
using Application.Services;

namespace Application.DeleteProject.DeleteProject;

public class DeleteProjectHandler(IServiceProvider serviceProvider, IProjectService projectService, INotificationService notificationService) : BaseHandler<DeleteProjectRequest, DeleteProjectResponse>(serviceProvider)
{
    public override async Task<DeleteProjectResponse> ExecuteAsync(DeleteProjectRequest command, CancellationToken ct)
    {
        var entityId = Guid.Parse(command.ProjectIdentifier);
        var existingProject = await projectService.GetProjectWithHistoryByIdAndCacheDbProject(entityId, ct);
        if (existingProject == null)
        {
            return new DeleteProjectEntityNotFoundResponse(entityId);
        }

        if (existingProject.Owner.EntityId != CurrentUserId &&
            existingProject.Contributors.All(c => c.EntityId != CurrentUserId))
        {
            return new DeleteProjectNotAllowedResponse(ProjectMessages.EntityCannotBeDeletedDueToMissingRights());
        }
        notificationService.ProjectDeleted(entityId, CurrentUserService.CurrentUserId, CurrentUserService.DisplayName);
        
        await projectService.SoftDeleteProject(entityId, ct);
        return new DeleteProjectOkResponse();
    }
}
