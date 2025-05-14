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
        if(entity.ImageId != existingItem.ImageId)
            updatingContext.AddChange(nameof(ApiGraphicsSpecification.ImageId), entity.ImageId.ToString(), existingItem.ImageId.ToString());
        
        if(entity.Type != existingItem.Type)
            updatingContext.AddChange(nameof(ApiGraphicsSpecification.Type), entity.Type.ToString(), existingItem.Type.ToString());
    }
}
