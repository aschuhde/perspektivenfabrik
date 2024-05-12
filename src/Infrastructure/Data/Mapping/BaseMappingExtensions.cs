using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class MappingExtensions
{
    public static partial BaseEntity ToBaseEntity(this DbEntity dbEntity);
    public static partial DbEntity ToDbBaseEntity(this BaseEntity entity);
    
    public static partial BaseEntityWithId ToBaseEntityWithId(this DbEntityWithId dbEntity);
    public static partial DbEntityWithId ToDbBaseEntityWithId(this BaseEntityWithId entity);
}