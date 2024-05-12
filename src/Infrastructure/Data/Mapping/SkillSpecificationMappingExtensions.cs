using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class SkillSpecificationMappingExtensions
{
    public static partial SkillSpecification ToSkillSpecification(this DbSkillSpecification dbSkillSpecification);
    public static partial DbSkillSpecification ToDbSkillSpecification(this SkillSpecification skillSpecification);
}