using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(SkillSpecificationDto.NameTranslations))]
    public static partial SkillSpecificationDto ToSkillSpecification(this DbSkillSpecification dbSkillSpecification);
    [MapperIgnoreSource(nameof(SkillSpecificationDto.NameTranslations))]
    public static partial DbSkillSpecification ToDbSkillSpecification(this SkillSpecificationDto skillSpecificationDto);
}