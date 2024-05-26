using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial ProjectTagDto ToProjectTag(this DbProjectTag dbProjectTag);
    public static partial DbProjectTag ToDbProjectTag(this ProjectTagDto projectTagDto);
}