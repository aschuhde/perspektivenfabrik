using Application.Models;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial OrganizationDto ToOrganization(this ApiOrganization apiOrganization);
    public static partial ApiOrganization ToApiOrganization(this OrganizationDto organizationDto);
}