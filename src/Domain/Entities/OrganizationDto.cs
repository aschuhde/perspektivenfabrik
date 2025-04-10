namespace Domain.Entities;

public sealed class OrganizationDto : BaseEntityDto
{
    public required string Name { get; init; }
}