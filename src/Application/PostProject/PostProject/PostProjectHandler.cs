using System.Net;
using Application.Common;
using Application.Mapping;
using Application.Messages;
using Application.Models.ApiModels;
using Application.Services;
using Application.Updaters;
using Domain.Enums;
using FluentValidation;

namespace Application.PostProject.PostProject;

public class PostProjectHandler(IServiceProvider serviceProvider, IValidator<PostProjectRequest> validator, IProjectService projectService) : BaseHandler<PostProjectRequest, PostProjectResponse>(serviceProvider)
{
    public override async Task<PostProjectResponse> ExecuteAsync(PostProjectRequest command, CancellationToken ct)
    {
        var validationResult = await validator.ValidateAsync(command, ct);
        if (!validationResult.IsValid)
            return new PostProjectValidationFailedResponse(validationResult);

        if (command.Project.EntityId != null)
            return new PostProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEdited(nameof(ApiProject.EntityId)));

        var userCanChangeMetadata = await UserAccessService.UserCanEditBaseMetadata();
        var userCanChangeResult = CheckIfUserCanChange(command.Project, userCanChangeMetadata);
        if (userCanChangeResult != null)
        {
            return userCanChangeResult;
        }
        if (!userCanChangeMetadata)
        {
            if (command.Project.Owner != null)
                return new PostProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.Owner)));
        }
        command.Project.Owner ??= ApiPerson.WithUserId(CurrentUserId);
            
        var projectDto = command.Project.ToProject();
        
        var result = await projectService.CreateOrUpdateProject(projectDto, ct);
        if (!result.Success)
            return new PostProjectCreationFailedResponse(result);
        
        return new PostProjectOkResponse()
        {
            StatusCode = HttpStatusCode.OK,
            Project = result.Project!.ToApiProject()
        };
    }

    private PostProjectResponse? CheckIfUserCanChange(ApiBaseEntity entity, bool userCanEditMetadata)
    {
        if (!userCanEditMetadata)
        {
            if (entity.History != null)
                return new PostProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.History)));
            if (entity.LastModifiedBy != null)
                return new PostProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.LastModifiedBy)));
            if (entity.LastModifiedOn != null)
                return new PostProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.LastModifiedOn)));
            if (entity.CreatedBy != null)
                return new PostProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.CreatedBy)));
            if (entity.CreatedOn != null)
                return new PostProjectNotAllowedResponse(ProjectMessages.FieldCannotBeEditedDueToMissingRights(nameof(ApiProject.CreatedOn)));
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
