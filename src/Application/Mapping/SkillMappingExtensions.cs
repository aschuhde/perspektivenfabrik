using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial SkillDto ToSkill(this ApiSkill apiSkill);
    
    public static partial ApiSkill ToApiSkill(this SkillDto skillDto);
}