using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial DescriptionImageDto ToDescriptionImage(this DbDescriptionImage dbDescriptionImage);
    
    public static partial DbDescriptionImage ToDbDescriptionImage(this DescriptionImageDto descriptionImageDto);
}