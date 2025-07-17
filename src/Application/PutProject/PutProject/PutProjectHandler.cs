using System.Net;
using Application.Common;
using Application.Mapping;
using Application.Messages;
using Application.Models.ApiModels;
using Application.Services;
using Application.Updaters;
using Domain.Enums;
using FluentValidation;

namespace Application.PutProject.PutProject;

public sealed class PutProjectHandler(IServiceProvider serviceProvider, IValidator<PutProjectRequest> validator, IProjectService projectService, INotificationService notificationService) : BaseHandler<PutProjectRequest, PutProjectResponse>(serviceProvider)
{
    public override async Task<PutProjectResponse> ExecuteAsync(PutProjectRequest command, CancellationToken ct)
    {
        var validationResult = await validator.ValidateAsync(command, ct);
        if (!validationResult.IsValid)
            return new PutProjectValidationFailedResponse(validationResult);
        
        if (command.Project.EntityId == null)
            return new PutProjectNotAllowedResponse(ProjectMessages.FieldIsNull(nameof(ApiProject.EntityId)));
        
        var userCanChangeMetadata = await UserAccessService.UserCanEditBaseMetadata();
        var userCanChangeResult = CheckIfUserCanChange(command.Project, userCanChangeMetadata);
        if (userCanChangeResult != null)
        {
            return userCanChangeResult;
        }
        if (!userCanChangeMetadata)
        {
            if (command.Project.Owner != null)
                return new PutProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.Owner)));
            if(command.Project.Contributors.Length > 0)
                return new PutProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.Contributors)));
        }
        
        var existingProject = await projectService.GetProjectWithHistoryByIdAndCacheDbProject(command.Project.EntityId.Value, ct);
        if (existingProject == null)
        {
            return new PutProjectEntityNotFoundResponse(command.Project.EntityId.Value);
        }
        command.Project.Owner ??= ApiPersonReference.WithUserId(existingProject.Owner.EntityId);
        command.Project.Contributors = existingProject.Contributors.Select(x => ApiPersonReference.WithUserId(x.EntityId)).ToArray();;

        if (existingProject.Owner.EntityId != CurrentUserId &&
            existingProject.Contributors.All(c => c.EntityId != CurrentUserId))
        {
            return new PutProjectNotAllowedResponse(ProjectMessages.EntityCannotBeEditedDueToMissingRights());
        }
        
        var updatingContext = new EntityUpdatingContext()
        {
            IsCreating = false,
            Changes = new List<ApiModificationHistoryItem>(),
            CurrentUserId = CurrentUserId,
            UserCanChangeMetadata = userCanChangeMetadata,
            HasChanged = false
        };
        command.Project.PrepareEntityAndCollectChanges(existingProject, updatingContext);
        
        var projectDto = command.Project.ToProject(existingProject);
        
        var result = await projectService.CreateOrUpdateProject(projectDto, updatingContext, ct);
        if (!result.Success)
            return new PutProjectUpdateFailedResponse(result);
        
        notificationService.ProjectUpdated(projectDto.EntityId, CurrentUserService.CurrentUserId, CurrentUserService.DisplayName);
        
        return new PutProjectOkResponse()
        {
            StatusCode = HttpStatusCode.OK,
            Project = result.Project!.ToApiProject()
        };
    }
    
    private PutProjectResponse? CheckIfUserCanChange(ApiBaseEntity entity, bool userCanEditMetadata)
    {
      if (userCanEditMetadata)
      {
        return null;
      }

      if (entity.History != null)
          return new PutProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.History)));
      if (entity.LastModifiedBy != null)
          return new PutProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.LastModifiedBy)));
      if (entity.LastModifiedOn != null)
          return new PutProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.LastModifiedOn)));
      if (entity.CreatedBy != null)
          return new PutProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.CreatedBy)));
      if (entity.CreatedOn != null)
          return new PutProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.CreatedOn)));

      return null;
    }
}
