using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(ProjectTagDto.TagNameTranslations))]
    public static partial ProjectTagDto ToProjectTag(this DbProjectTag dbProjectTag);
    [MapperIgnoreSource(nameof(ProjectTagDto.TagNameTranslations))]
    public static partial DbProjectTag ToDbProjectTag(this ProjectTagDto projectTagDto);
}