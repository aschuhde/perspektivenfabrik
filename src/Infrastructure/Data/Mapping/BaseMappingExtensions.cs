using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class MappingExtensions
{
    public static partial BaseEntityDto ToBaseEntity(this DbEntity dbEntity);
    public static partial DbEntity ToDbBaseEntity(this BaseEntityDto entityDto);


    public static partial BaseEntityWithIdDto ToBaseEntityWithId(this DbEntityWithId dbEntity);

    public static partial DbEntityWithId ToDbBaseEntityWithId(this BaseEntityWithIdDto entity);
}