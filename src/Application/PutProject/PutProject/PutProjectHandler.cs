using Application.Common;
using Application.Messages;
using Application.Models.ApiModels;
using Application.Services;
using Domain.Enums;
using FluentValidation;

namespace Application.PutProject.PutProject;

public sealed class PutProjectHandler(IServiceProvider serviceProvider, IValidator<PutProjectRequest> validator, IProjectService projectService) : BaseHandler<PutProjectRequest, PutProjectResponse>(serviceProvider)
{
    public override async Task<PutProjectResponse> ExecuteAsync(PutProjectRequest command, CancellationToken ct)
    {
        var v = validator;
        var s = projectService;
        return await Task.FromResult(new PutProjectResponse()); 
        // var validationResult = await validator.ValidateAsync(command, ct);
        // if (!validationResult.IsValid)
        //     return new PutProjectValidationFailedResponse(validationResult);
        //
        // if (command.Project.EntityId == null)
        //     return new PutProjectNotAllowedResponse(ProjectMessages.FieldIsNull(nameof(ApiProject.EntityId)));
        //
        // var userCanChangeMetadata = await UserAccessService.UserCanEditBaseMetadata();
        // var userCanChangeResult = CheckIfUserCanChange(command.Project, userCanChangeMetadata);
        // if (userCanChangeResult != null)
        // {
        //     return userCanChangeResult;
        // }
        // if (!userCanChangeMetadata)
        // {
        //     if (command.Project.Owner != null)
        //         return new PutProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.Owner)));
        // }
        // command.Project.Owner ??= ApiPerson.WithUserId(CurrentUserId);
        //
        // var existingProject = await projectService.GetProjectById(command.Project.EntityId.Value, ct);
        // if (existingProject == null)
        // {
        //     return new PutProjectEntityNotFoundResponse(command.Project.EntityId.Value);
        // }
        //
        // var updatingContext = new EntityUpdatingContext()
        // {
        //     IsCreating = false,
        //     Changes = new List<ApiModificationHistoryItem>(),
        //     CurrentUserId = CurrentUserId,
        //     UserCanChangeMetadata = userCanChangeMetadata,
        //     HasChanged = false
        // };
        // command.Project.PrepareEntityAndCollectChanges(existingProject, updatingContext);
        //
        // var projectDto = command.Project.ToProject();
        //
        // var result = await projectService.CreateOrUpdateProject(projectDto, updatingContext, ct);
        // if (!result.Success)
        //     return new PutProjectUpdateFailedResponse(result);
        //
        // return new PutProjectOkResponse()
        // {
        //     StatusCode = HttpStatusCode.OK,
        //     Project = result.Project!.ToApiProject()
        // };
    }
    
    private PutProjectResponse? CheckIfUserCanChange(ApiBaseEntity entity, bool userCanEditMetadata)
    {
        if (!userCanEditMetadata)
        {
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
        }

        entity.History ??= new ApiModificationHistory()
        {
            HistoryItems = [new ApiModificationHistoryItem()
            {
                HistoryEntryType = HistoryEntryType.Created
            }]
        };
        entity.EntityId ??= Guid.NewGuid();
        entity.CreatedBy ??= ApiPerson.WithUserId(CurrentUserId);
        entity.LastModifiedBy ??= ApiPerson.WithUserId(CurrentUserId);
        entity.CreatedOn ??= DateTimeOffset.UtcNow;
        entity.LastModifiedOn ??= DateTimeOffset.UtcNow;

        return null;
    }
}
