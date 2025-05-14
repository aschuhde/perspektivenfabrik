using Domain.Extensions;

namespace Domain.Entities;

public class RequirementSpecificationDto : BaseEntityWithIdDto
{
    public required bool TimeSpecificationSameAsProject { get; init; }
    public required TimeSpecificationDto[] TimeSpecifications { get; init; }
    public required QuantitySpecificationDto QuantitySpecification { get; init; }

    public virtual void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        QuantitySpecification.ValueTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == this.EntityId && x.PropertyPath == nameof(QuantitySpecification)).Select(x => x.ToTranslationValue()).ToArray();
    }

    public virtual FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        return QuantitySpecification.ValueTranslations.CreateFieldTranslationDtos(projectId, EntityId,
            nameof(QuantitySpecification));
    }
}

public sealed class RequirementSpecificationDtoPerson : RequirementSpecificationDto
{
    public required bool LocationSpecificationsSameAsProject { get; init; }
    public required SkillSpecificationDto[] SkillSpecifications { get; init; }
    public required WorkAmountSpecificationDto WorkAmountSpecification { get; init; }
    public required LocationSpecificationDto[] LocationSpecifications { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        base.ApplyTranslations(fieldTranslations);
        foreach (var skillSpecification in SkillSpecifications)
        {
            skillSpecification.ApplyTranslations(fieldTranslations);
        }
        foreach (var locationSpecification in LocationSpecifications)
        {
            locationSpecification.ApplyTranslations(fieldTranslations);
        }
    }
    public override FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        var result = new List<FieldTranslationDto>();
        result.AddRange(base.CollectTranslations(projectId));
        foreach (var skillSpecification in SkillSpecifications)
        {
            result.AddRange(skillSpecification.CollectTranslations(projectId));
        }
        foreach (var locationSpecification in LocationSpecifications)
        {
            result.AddRange(locationSpecification.CollectTranslations(projectId));
        }
        return result.ToArray();
    }
}

public sealed class RequirementSpecificationDtoMaterial : RequirementSpecificationDto
{
    public required bool LocationSpecificationsSameAsProject { get; init; }
    public required MaterialSpecificationDto[] MaterialSpecifications { get; init; }
    public required LocationSpecificationDto[] LocationSpecifications { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        base.ApplyTranslations(fieldTranslations);
        foreach (var materialSpecification in MaterialSpecifications)
        {
            materialSpecification.ApplyTranslations(fieldTranslations);
        }
        foreach (var locationSpecification in LocationSpecifications)
        {
            locationSpecification.ApplyTranslations(fieldTranslations);
        }
    }
    public override FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        var result = new List<FieldTranslationDto>();
        result.AddRange(base.CollectTranslations(projectId));
        foreach (var materialSpecification in MaterialSpecifications)
        {
            result.AddRange(materialSpecification.CollectTranslations(projectId));
        }
        foreach (var locationSpecification in LocationSpecifications)
        {
            result.AddRange(locationSpecification.CollectTranslations(projectId));
        }
        return result.ToArray();
    }
}

public sealed class RequirementSpecificationDtoMoney : RequirementSpecificationDto
{

}