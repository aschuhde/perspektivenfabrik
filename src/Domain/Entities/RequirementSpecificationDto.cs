namespace Domain.Entities;

public class RequirementSpecificationDto : BaseEntityWithIdDto
{
    public required bool TimeSpecificationSameAsProject { get; init; }
    public required TimeSpecificationDto[] TimeSpecifications { get; init; }
    public required QuantitySpecificationDto QuantitySpecification { get; init; }
}

public sealed class RequirementSpecificationDtoPerson : RequirementSpecificationDto
{
    public required bool LocationSpecificationsSameAsProject { get; init; }
    public required SkillSpecificationDto[] SkillSpecifications { get; init; }
    public required WorkAmountSpecificationDto WorkAmountSpecification { get; init; }
    public required LocationSpecificationDto[] LocationSpecifications { get; init; }
}

public sealed class RequirementSpecificationDtoMaterial : RequirementSpecificationDto
{
    public required bool LocationSpecificationsSameAsProject { get; init; }
    public required MaterialSpecificationDto[] MaterialSpecifications { get; init; }
    public required LocationSpecificationDto[] LocationSpecifications { get; init; }
}

public sealed class RequirementSpecificationDtoMoney : RequirementSpecificationDto
{

}