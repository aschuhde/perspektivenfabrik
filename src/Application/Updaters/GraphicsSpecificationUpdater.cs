using Application.Models.ApiModels;
using Common;
using Domain.Entities;

namespace Application.Updaters;

public static class GraphicsSpecificationUpdater
{
    public static void UpdateGraphicsSpecifications(this ApiGraphicsSpecification entity,
        GraphicsSpecificationDto? existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(existingItem != null)
            UpdateChanges(entity, existingItem, updatingContext);

        entity.PrepareBaseEntity(existingItem, updatingContext);
    }
    
    private static void UpdateChanges(this ApiGraphicsSpecification entity, GraphicsSpecificationDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(entity.Content.Content != existingItem.Content.Content)
            updatingContext.AddChange(nameof(ApiGraphicsSpecification.Content), entity.Content.Content.ToBase64(), existingItem.Content.Content.ToBase64());
        
        if(entity.Type != existingItem.Type)
            updatingContext.AddChange(nameof(ApiGraphicsSpecification.Type), entity.Type.ToString(), existingItem.Type.ToString());
    }
}
