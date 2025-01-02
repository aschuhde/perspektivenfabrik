using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Updaters;

public static class TimeSpecificationUpdater
{
    public static void UpdateTimeSpecifications(this ApiTimeSpecification entity,
        TimeSpecificationDto? existingItem,
        EntityUpdatingContext updatingContext)
    {
        entity.UpdateBaseEntity(existingItem, updatingContext);
    }
    
}
