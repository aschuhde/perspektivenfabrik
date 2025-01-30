using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Updaters;

public static class ProjectUpdater
{
    public static void PrepareEntityForNewProject(this ApiProjectBody entity, EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(null, updatingContext);

        foreach (var x in entity.LocationSpecifications)
        {
            x.PrepareMetadataForNewEntry(updatingContext);
        }
        foreach (var x in entity.ContactSpecifications)
        {
            x.PrepareMetadataForNewEntry(updatingContext);
        }
        foreach (var x in entity.DescriptionSpecifications)
        {
            x.PrepareMetadataForNewEntry(updatingContext);
        }
        foreach (var x in entity.GraphicsSpecifications)
        {
            x.PrepareMetadataForNewEntry(updatingContext);
        }
        foreach (var x in entity.ProjectTags)
        {
            x.PrepareMetadataForNewEntry(updatingContext);
        }
        foreach (var x in entity.TimeSpecifications)
        {
            x.PrepareMetadataForNewEntry(updatingContext);
        }
        foreach (var x in entity.RequirementSpecifications)
        {
            x.PrepareMetadataForNewEntry(updatingContext);
        }
    }
    private static void PrepareMetadataForNewEntry(this ApiLocationSpecification entity, EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(null, updatingContext);
    }
    private static void PrepareMetadataForNewEntry(this ApiContactSpecification entity, EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(null, updatingContext);
    }
    private static void PrepareMetadataForNewEntry(this ApiDescriptionSpecification entity, EntityUpdatingContext updatingContext)
    {
        entity.Type.PrepareBaseEntity(null, updatingContext);
        entity.PrepareBaseEntity(null, updatingContext);
    }
    private static void PrepareMetadataForNewEntry(this ApiGraphicsSpecification entity, EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(null, updatingContext);
    }
    private static void PrepareMetadataForNewEntry(this ApiProjectTag entity, EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(null, updatingContext);
    }
    private static void PrepareMetadataForNewEntry(this ApiTimeSpecification entity, EntityUpdatingContext updatingContext)
    {
        if (entity is ApiTimeSpecificationPeriod period)
        {
            period.Start.PrepareMetadataForNewEntry(updatingContext);
            period.End.PrepareMetadataForNewEntry(updatingContext);
        }
        entity.PrepareBaseEntity(null, updatingContext);
    }
    private static void PrepareMetadataForNewEntry(this ApiRequirementSpecification entity, EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(null, updatingContext);
        foreach (var x in entity.TimeSpecifications)
        {
            x.PrepareMetadataForNewEntry(updatingContext);
        }
        entity.QuantitySpecification.PrepareBaseEntity(null, updatingContext);
        if (entity is ApiRequirementSpecificationMaterial specificationMaterial)
        {
            foreach (var x in specificationMaterial.LocationSpecifications)
            {
                x.PrepareMetadataForNewEntry(updatingContext);
            }
            foreach (var x in specificationMaterial.MaterialSpecifications)
            {
                x.PrepareMetadataForNewEntry(updatingContext);
            }
        }
        if (entity is ApiRequirementSpecificationPerson specificationPerson)
        {
            foreach (var x in specificationPerson.LocationSpecifications)
            {
                x.PrepareMetadataForNewEntry(updatingContext);
            }
            foreach (var x in specificationPerson.SkillSpecifications)
            {
                x.PrepareMetadataForNewEntry(updatingContext);
            }
            specificationPerson.WorkAmountSpecification.PrepareBaseEntity(null, updatingContext);
        }
    }

    private static void PrepareMetadataForNewEntry(this ApiMaterialSpecification entity, EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(null, updatingContext);
    }

    private static void PrepareMetadataForNewEntry(this ApiSkillSpecification entity, EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(null, updatingContext);
    }
    
    public static void PrepareEntityAndCollectChanges(this ApiProjectBody entity, ProjectDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if (!updatingContext.IsCreating)
        {
            CollectChanges(entity, existingItem, updatingContext);
        }

        entity.PrepareBaseEntity(existingItem, updatingContext);
    }

    private static void CollectChanges(ApiProjectBody entity, ProjectDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(entity.Owner?.PersonEntityId != existingItem.Owner.EntityId)
            updatingContext.AddChange(nameof(entity.Owner), entity.Owner?.ToString(), existingItem.Owner.ToString());
        
        if(entity.Phase != existingItem.Phase)
            updatingContext.AddChange(nameof(entity.Phase), entity.Phase.ToString(), existingItem.Phase.ToString());
        
        if(entity.Type != existingItem.Type)
            updatingContext.AddChange(nameof(entity.Type), entity.Type.ToString(), existingItem.Type.ToString());
        
        if(entity.Visibility != existingItem.Visibility)
            updatingContext.AddChange(nameof(entity.Visibility), entity.Visibility.ToString(), existingItem.Visibility.ToString());
        
        if(entity.ProjectName != existingItem.ProjectName)
            updatingContext.AddChange(nameof(entity.ProjectName), entity.ProjectName, existingItem.ProjectName);
        
        if(entity.ProjectTitle.RawContentString != existingItem.ProjectTitle.RawContentString)
            updatingContext.AddChange(nameof(entity.ProjectTitle), entity.ProjectTitle.ToString(), existingItem.ProjectTitle.ToString());
        
        if(entity.ConnectedOrganizationsSameAsOwner != existingItem.ConnectedOrganizationsSameAsOwner)
            updatingContext.AddChange(nameof(entity.ConnectedOrganizationsSameAsOwner), entity.ConnectedOrganizationsSameAsOwner.ToString(), existingItem.ConnectedOrganizationsSameAsOwner.ToString());

        foreach (var contributor in entity.Contributors)
        {
            if(existingItem.Contributors.All(x => x.EntityId != contributor.PersonEntityId))
                updatingContext.AddChangeForAddedItemToListProperty(nameof(entity.Contributors), contributor.ToString());
        }
        foreach (var contributor in existingItem.Contributors)
        {
            if(entity.Contributors.All(x => x.PersonEntityId != contributor.EntityId))
                updatingContext.AddChangeForDeletedItemFromListProperty(nameof(entity.Contributors), contributor.ToString());
        }
        
        foreach (var organization in entity.ConnectedOrganizations)
        {
            if(existingItem.ConnectedOrganizations.All(x => x.EntityId != organization.OrganizationEntityId))
                updatingContext.AddChangeForAddedItemToListProperty(nameof(entity.ConnectedOrganizations), organization.ToString());
        }
        foreach (var organization in existingItem.ConnectedOrganizations)
        {
            if(entity.ConnectedOrganizations.All(x => x.OrganizationEntityId != organization.EntityId))
                updatingContext.AddChangeForDeletedItemFromListProperty(nameof(entity.ConnectedOrganizations), organization.ToString());
        }
        
        foreach (var relatedProject in entity.RelatedProjects)
        {
            if(existingItem.RelatedProjects.All(x => x.EntityId != relatedProject.ProjectId))
                updatingContext.AddChangeForAddedItemToListProperty(nameof(entity.RelatedProjects), relatedProject.ToString());
        }
        foreach (var relatedProject in existingItem.RelatedProjects)
        {
            if(entity.RelatedProjects.All(x => x.ProjectId != relatedProject.EntityId))
                updatingContext.AddChangeForDeletedItemFromListProperty(nameof(entity.RelatedProjects), relatedProject.ToString());
        }
        
        foreach (var projectTag in entity.ProjectTags)
        {
            if(existingItem.ProjectTags.All(x => x.EntityId != projectTag.EntityId))
                updatingContext.AddChangeForAddedItemToListProperty(nameof(entity.ProjectTags), projectTag.ToString());
        }
        foreach (var projectTag in existingItem.ProjectTags)
        {
            if(entity.ProjectTags.All(x => x.EntityId != projectTag.EntityId))
                updatingContext.AddChangeForDeletedItemFromListProperty(nameof(entity.ProjectTags), projectTag.ToString());
        }
        
        UpdateChangesList(entity.ContactSpecifications, existingItem.ContactSpecifications, updatingContext, nameof(entity.ContactSpecifications),
            (collectionEntity, collectionExistingEntity, collectionUpdatingContext) =>
            {
                collectionEntity.UpdateContactSpecification(collectionExistingEntity, collectionUpdatingContext);
            });
        
        UpdateChangesList(entity.DescriptionSpecifications, existingItem.DescriptionSpecifications, updatingContext, nameof(entity.DescriptionSpecifications),
            (collectionEntity, collectionExistingEntity, collectionUpdatingContext) =>
            {
                collectionEntity.UpdateDescriptionSpecification(collectionExistingEntity, collectionUpdatingContext);
            });
        
        UpdateChangesList(entity.LocationSpecifications, existingItem.LocationSpecifications, updatingContext, nameof(entity.LocationSpecifications),
            (collectionEntity, collectionExistingEntity, collectionUpdatingContext) =>
            {
                collectionEntity.UpdateLocationSpecification(collectionExistingEntity, collectionUpdatingContext);
            });
        
        UpdateChangesList(entity.RequirementSpecifications, existingItem.RequirementSpecifications, updatingContext, nameof(entity.RequirementSpecifications),
            (collectionEntity, collectionExistingEntity, collectionUpdatingContext) =>
            {
                collectionEntity.UpdateRequirementSpecification(collectionExistingEntity, collectionUpdatingContext);
            });
        
        UpdateChangesList(entity.TimeSpecifications, existingItem.TimeSpecifications, updatingContext, nameof(entity.TimeSpecifications),
            (collectionEntity, collectionExistingEntity, collectionUpdatingContext) =>
            {
                collectionEntity.UpdateTimeSpecifications(collectionExistingEntity, collectionUpdatingContext);
            });
        
        UpdateChangesList(entity.GraphicsSpecifications, existingItem.GraphicsSpecifications, updatingContext, nameof(entity.GraphicsSpecifications),
            (collectionEntity, collectionExistingEntity, collectionUpdatingContext) =>
            {
                collectionEntity.UpdateGraphicsSpecifications(collectionExistingEntity, collectionUpdatingContext);
            });
        
        
    }

    private static void UpdateChangesList<T1, T2>(IEnumerable<T1> entities, IEnumerable<T2> existingEntities, EntityUpdatingContext updatingContext,
        string propertyName, Action<T1, T2?, EntityUpdatingContext> onUpdateEntity) 
        where T1 : ApiBaseEntity where T2 : BaseEntityDto
    {
        foreach (var entity in entities)
        {
            var existingEntity = entity.EntityId == null ? null :
                existingEntities.FirstOrDefault(x => x.EntityId == entity.EntityId);
            var context = new EntityUpdatingContext()
            {
                Changes = new(),
                IsCreating = existingEntity == null,
                CurrentUserId = updatingContext.CurrentUserId,
                HasChanged = existingEntity == null,
                UserCanChangeMetadata = updatingContext.UserCanChangeMetadata
            };
            onUpdateEntity(entity, existingEntity, context);
            if(existingEntity == null)
                updatingContext.AddChangeForAddedItemToListProperty(propertyName, entity.ToString());
            else
            {
                if(context.HasChanged)
                    updatingContext.AddChangeForUpdatedItemInListProperty(propertyName, entity.ToString());
            }
        }
        foreach (var existingEntity in existingEntities)
        {
            if(entities.All(x => x.EntityId != existingEntity.EntityId))
                updatingContext.AddChangeForDeletedItemFromListProperty(propertyName, existingEntity.ToString());
        }
    }
    
}
