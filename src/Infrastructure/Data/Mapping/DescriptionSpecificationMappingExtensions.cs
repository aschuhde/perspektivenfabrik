using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial DescriptionSpecificationDto ToDescriptionSpecification(this DbDescriptionSpecification dbDescriptionSpecification);
    
    public static partial DbDescriptionSpecification ToDbDescriptionSpecification(this DescriptionSpecificationDto descriptionSpecificationDto);
}