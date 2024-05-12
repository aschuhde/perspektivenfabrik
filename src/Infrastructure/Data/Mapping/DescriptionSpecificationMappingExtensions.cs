using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial DescriptionSpecification ToDescriptionSpecification(this DbDescriptionSpecification dbDescriptionSpecification);
    
    public static partial DbDescriptionSpecification ToDbDescriptionSpecification(this DescriptionSpecification descriptionSpecification);
}