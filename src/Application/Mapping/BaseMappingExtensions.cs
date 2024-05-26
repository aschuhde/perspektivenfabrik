using Application.Models;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;

[Mapper]
public static partial class ApiMappingExtensions
{
    public static partial BaseEntityDto ToBaseEntity(this ApiBaseEntity apiBaseEntity);
    public static partial ApiBaseEntity ToApiBaseEntity(this BaseEntityDto entityDto);
    
    public static partial BaseEntityWithIdDto ToBaseEntityWithId(this ApiBaseEntityWithId apiBaseEntity);
    public static partial ApiBaseEntityWithId ToApiBaseEntityWithId(this BaseEntityWithIdDto entity);
}