using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Updaters;

public static class DescriptionSpecificationUpdater
{
    public static void UpdateDescriptionSpecification(this ApiDescriptionSpecification entity,
        DescriptionSpecificationDto? existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(updatingContext.IsCreating)
            UpdateChanges(entity, existingItem!, updatingContext);
        
        entity.UpdateBaseEntity(existingItem, updatingContext);
    }

    private static void UpdateChanges(this ApiDescriptionSpecification entity, DescriptionSpecificationDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(entity.Content.RawContentString != existingItem.Content.RawContentString)
            updatingContext.AddChange(nameof(ApiDescriptionSpecification.Content), entity.Content.RawContentString, existingItem.Content.RawContentString);
        
        if(entity.Type.EntityId != existingItem.Type.EntityId)
            updatingContext.AddChange(nameof(ApiDescriptionSpecification.Type), entity.Type.Name, existingItem.Type.Name);
    }
}
