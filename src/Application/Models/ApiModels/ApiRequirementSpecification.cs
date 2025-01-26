using System.Text.Json.Serialization;

namespace Application.Models.ApiModels;

[JsonDerivedType(typeof(ApiRequirementSpecification), typeDiscriminator: "base")]
[JsonDerivedType(typeof(ApiRequirementSpecificationPerson), typeDiscriminator: "person")]
[JsonDerivedType(typeof(ApiRequirementSpecificationMaterial), typeDiscriminator: "material")]
[JsonDerivedType(typeof(ApiRequirementSpecificationMoney), typeDiscriminator: "money")]
public class ApiRequirementSpecification : ApiBaseEntity
{
    public required bool TimeSpecificationSameAsProject { get; init; }
    public required ApiTimeSpecification[] TimeSpecifications { get; init; }
    public required ApiQuantitySpecification QuantitySpecification { get; init; }
}

public sealed class ApiRequirementSpecificationPerson : ApiRequirementSpecification
{
    public required ApiSkillSpecification[] SkillSpecifications { get; init; }
    public required ApiLocationSpecification[] LocationSpecifications { get; init; }
    public required ApiWorkAmountSpecification[] WorkAmountSpecifications { get; init; }
}

public sealed class ApiRequirementSpecificationMaterial : ApiRequirementSpecification
{
    public required ApiMaterialSpecification[] MaterialSpecifications { get; init; }
    public required ApiLocationSpecification[] LocationSpecifications { get; init; }
}

public sealed class ApiRequirementSpecificationMoney : ApiRequirementSpecification
{
    public required ApiMaterialSpecification[] MaterialSpecifications { get; init; }
}