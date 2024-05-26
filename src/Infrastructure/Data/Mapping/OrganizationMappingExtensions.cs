using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial OrganizationDto ToOrganization(this DbOrganization dbOrganization);
    public static partial DbOrganization ToDbOrganization(this OrganizationDto organizationDto);
}