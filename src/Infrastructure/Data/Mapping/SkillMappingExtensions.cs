using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;

public static partial class MappingExtensions
{
    public static partial SkillDto ToSkill(this DbSkill dbSkill);
    
    public static partial DbSkill ToDbSkill(this SkillDto skillDto);
}