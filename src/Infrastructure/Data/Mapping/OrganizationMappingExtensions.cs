using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class OrganizationMappingExtensions
{
    public static partial Organization ToOrganization(this DbOrganization dbOrganization);
    public static partial DbOrganization ToDbOrganization(this Organization organization);
}