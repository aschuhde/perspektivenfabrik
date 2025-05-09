using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(MaterialDto.NameTranslations))]
    public static partial MaterialDto ToMaterial(this DbMaterial dbMaterial);
    [MapperIgnoreSource(nameof(MaterialDto.NameTranslations))]
    public static partial DbMaterial ToDbMaterial(this MaterialDto materialDto);
}