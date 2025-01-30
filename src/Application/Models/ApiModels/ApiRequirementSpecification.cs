using System.Text.Json.Serialization;

namespace Application.Models.ApiModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiRequirementSpecificationTypes
{
    Base, Person, Material, Money,
}
[JsonPolymorphic(TypeDiscriminatorPropertyName = "classType")]
[JsonDerivedType(typeof(ApiRequirementSpecification), typeDiscriminator: nameof(ApiRequirementSpecificationTypes.Base))]
[JsonDerivedType(typeof(ApiRequirementSpecificationPerson), typeDiscriminator: nameof(ApiRequirementSpecificationTypes.Person))]
[JsonDerivedType(typeof(ApiRequirementSpecificationMaterial), typeDiscriminator: nameof(ApiRequirementSpecificationTypes.Material))]
[JsonDerivedType(typeof(ApiRequirementSpecificationMoney), typeDiscriminator: nameof(ApiRequirementSpecificationTypes.Money))]
public class ApiRequirementSpecification : ApiBaseEntity
{
    public required bool TimeSpecificationSameAsProject { get; init; }
    public required ApiTimeSpecification[] TimeSpecifications { get; init; }
    public required ApiQuantitySpecification QuantitySpecification { get; init; }
}

public sealed class ApiRequirementSpecificationPerson : ApiRequirementSpecification
{
    public required bool LocationSpecificationsSameAsProject { get; init; }
    public required ApiSkillSpecification[] SkillSpecifications { get; init; }
    public required ApiLocationSpecification[] LocationSpecifications { get; init; }
    public required ApiWorkAmountSpecification WorkAmountSpecification { get; init; }
}

public sealed class ApiRequirementSpecificationMaterial : ApiRequirementSpecification
{
    public required bool LocationSpecificationsSameAsProject { get; init; }
    public required ApiMaterialSpecification[] MaterialSpecifications { get; init; }
    public required ApiLocationSpecification[] LocationSpecifications { get; init; }
}

public sealed class ApiRequirementSpecificationMoney : ApiRequirementSpecification
{

}