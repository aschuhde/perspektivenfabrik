using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(OrganizationDto.NameTranslations))]
    public static partial OrganizationDto ToOrganization(this DbOrganization dbOrganization);
    [MapperIgnoreSource(nameof(OrganizationDto.NameTranslations))]
    public static partial DbOrganization ToDbOrganization(this OrganizationDto organizationDto);
}