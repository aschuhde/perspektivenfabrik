using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Updaters;

public static class RequirementSpecificationUpdater
{
    public static void UpdateRequirementSpecification(this ApiRequirementSpecification entity,
        RequirementSpecificationDto? existingItem,
        EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(existingItem, updatingContext);
    }
}
