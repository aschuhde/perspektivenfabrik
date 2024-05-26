using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial DescriptionTypeDto ToDescriptionType(this DbDescriptionType dbDescriptionType);
    public static partial DbDescriptionType ToDbDescriptionType(this DescriptionTypeDto descriptionTypeDto);
}