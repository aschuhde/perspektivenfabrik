using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial ProjectImageDto ToProjectImage(this DbProjectImage dbProjectImage);
    
    public static partial DbProjectImage ToDbProjectImage(this ProjectImageDto projectImageDto);
}