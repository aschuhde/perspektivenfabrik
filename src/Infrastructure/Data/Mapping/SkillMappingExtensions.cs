using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(SkillDto.NameTranslations))]
    public static partial SkillDto ToSkill(this DbSkill dbSkill);
    [MapperIgnoreSource(nameof(SkillDto.NameTranslations))]
    
    public static partial DbSkill ToDbSkill(this SkillDto skillDto);
}