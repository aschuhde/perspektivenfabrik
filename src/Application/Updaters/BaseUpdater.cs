using Application.Models.ApiModels;
using Domain.Entities;
using Domain.Enums;

namespace Application.Updaters;

public static class BaseUpdater
{
    public static void PrepareBaseEntity(this ApiBaseEntity entity, BaseEntityDto? existingItem, EntityUpdatingContext updatingContext)
    {
        var isCreating = updatingContext.IsCreating;
        if(entity.EntityId == null && !isCreating)
            return; // entity id required
        if(isCreating && entity.EntityId != existingItem!.EntityId)
            return; // entity id cannot be changed
        var hasChanged = updatingContext.HasChanged;

        entity.History ??= isCreating ? new ApiModificationHistory()
        {
            HistoryItems = [new ApiModificationHistoryItem()
            {
                HistoryEntryType = HistoryEntryType.Created
            }]
        } : new ApiModificationHistory()
        {
            HistoryItems = updatingContext.Changes.ToArray()
        };
        entity.EntityId ??= Guid.NewGuid();
        entity.CreatedBy ??= isCreating ? ApiPerson.WithUserId(updatingContext.CurrentUserId) : 
            (existingItem?.CreatedBy != null ? ApiPerson.WithUserId(existingItem.CreatedBy!.EntityId) : null);
        entity.LastModifiedBy ??= hasChanged ? ApiPerson.WithUserId(updatingContext.CurrentUserId) : 
            (existingItem?.LastModifiedBy != null ? ApiPerson.WithUserId(existingItem.LastModifiedBy!.EntityId) : null);
        entity.CreatedOn ??= DateTimeOffset.UtcNow;
        entity.LastModifiedOn ??= hasChanged ? DateTimeOffset.UtcNow : existingItem?.LastModifiedOn;
    }
}
