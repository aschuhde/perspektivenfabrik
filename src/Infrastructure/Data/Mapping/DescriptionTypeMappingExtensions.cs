using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class DescriptionTypeMappingExtensions
{
    public static partial DescriptionType ToDescriptionType(this DbDescriptionType dbDescriptionType);
    public static partial DbDescriptionType ToDbDescriptionType(this DescriptionType descriptionType);
}