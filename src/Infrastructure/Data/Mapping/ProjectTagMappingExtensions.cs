using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class ProjectTagMappingExtensions
{
    public static partial ProjectTag ToProjectTag(this DbProjectTag dbProjectTag);
    public static partial DbProjectTag ToDbProjectTag(this ProjectTag projectTag);
}