using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class DescriptionSpecificationMappingExtensions
{
    public static partial DescriptionSpecification ToDescriptionSpecification(this DbDescriptionSpecification dbDescriptionSpecification);
    
    public static partial DbDescriptionSpecification ToDbDescriptionSpecification(this DescriptionSpecification descriptionSpecification);
}