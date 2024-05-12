namespace Domain.Entities;

public class RequirementSpecification : BaseEntity
{
    public required bool TimeSpecificationSameAsProject { get; init; }
    public required TimeSpecification[] TimeSpecifications { get; init; }
    public required QuantitySpecification QuantitySpecification { get; init; }
}

public sealed class RequirementSpecificationPerson : RequirementSpecification
{
    public required SkillSpecification[] SkillSpecifications { get; init; }
    public required WorkAmountSpecification[] WorkAmountSpecifications { get; init; }
}

public sealed class RequirementSpecificationMaterial : RequirementSpecification
{
    public required MaterialSpecification[] MaterialSpecifications { get; init; }
}

public sealed class RequirementSpecificationMoney : RequirementSpecification
{
    public required MaterialSpecification[] MaterialSpecifications { get; init; }
}