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
}

public sealed class RequirementSpecificationDtoMoney : RequirementSpecificationDto
{

}