namespace Domain.Entities;

public class RequirementSpecificationDto : BaseEntityDto
{
    public required bool TimeSpecificationSameAsProject { get; init; }
    public required TimeSpecificationDto[] TimeSpecifications { get; init; }
    public required QuantitySpecificationDto QuantitySpecification { get; init; }
}

public sealed class RequirementSpecificationDtoPerson : RequirementSpecificationDto
{
    public required SkillSpecificationDto[] SkillSpecifications { get; init; }
    public required WorkAmountSpecificationDto[] WorkAmountSpecifications { get; init; }
}

public sealed class RequirementSpecificationDtoMaterial : RequirementSpecificationDto
{
    public required MaterialSpecificationDto[] MaterialSpecifications { get; init; }
}

public sealed class RequirementSpecificationDtoMoney : RequirementSpecificationDto
{
    public required MaterialSpecificationDto[] MaterialSpecifications { get; init; }
}