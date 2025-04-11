using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;

public static partial class MappingExtensions
{
    public static partial MaterialDto ToMaterial(this DbMaterial dbMaterial);
    
    public static partial DbMaterial ToDbMaterial(this MaterialDto materialDto);
}