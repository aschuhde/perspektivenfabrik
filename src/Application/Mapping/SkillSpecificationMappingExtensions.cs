using Application.Models;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial SkillSpecificationDto ToSkillSpecification(this ApiSkillSpecification apiSkillSpecification);
    public static partial ApiSkillSpecification ToApiSkillSpecification(this SkillSpecificationDto skillSpecificationDto);
}