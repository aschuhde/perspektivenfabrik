using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(TagDto.NameTranslations))]
    public static partial TagDto ToTag(this DbTag dbTag);
    [MapperIgnoreSource(nameof(TagDto.NameTranslations))]
    
    public static partial DbTag ToDbTag(this TagDto tagDto);
}