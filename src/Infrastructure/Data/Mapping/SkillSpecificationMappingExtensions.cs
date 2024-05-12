using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial SkillSpecification ToSkillSpecification(this DbSkillSpecification dbSkillSpecification);
    public static partial DbSkillSpecification ToDbSkillSpecification(this SkillSpecification skillSpecification);
}