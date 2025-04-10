using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial SkillSpecificationDto ToSkillSpecification(this DbSkillSpecification dbSkillSpecification);
    public static partial DbSkillSpecification ToDbSkillSpecification(this SkillSpecificationDto skillSpecificationDto);
}