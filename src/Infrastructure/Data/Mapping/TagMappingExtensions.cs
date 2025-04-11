using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;

public static partial class MappingExtensions
{
    public static partial TagDto ToTag(this DbTag dbTag);
    
    public static partial DbTag ToDbTag(this TagDto tagDto);
}