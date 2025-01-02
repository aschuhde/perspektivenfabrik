using Application.Models.ApiModels;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;

[Mapper]
public static partial class ApiMappingExtensions
{
    public static partial BaseEntityDto ToBaseEntity(this ApiBaseEntity apiBaseEntity);
    public static partial ApiBaseEntity ToApiBaseEntity(this BaseEntityDto entityDto);
    
    public static BaseEntityWithIdDto ToBaseEntityWithId(this ApiBaseEntityWithId apiBaseEntity)
    {
        return new BaseEntityWithIdDto
        {
            EntityId = apiBaseEntity.EntityId ?? Guid.NewGuid()
        };
    }
    
    public static partial ApiBaseEntityWithId ToApiBaseEntityWithId(this BaseEntityWithIdDto entity);
}
