namespace Domain.Entities;

public class BaseEntityDto : BaseEntityWithIdDto
{
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
    public PersonDto? CreatedBy { get; init; }
    public DateTimeOffset LastModifiedOn { get; init; } = DateTimeOffset.UtcNow;
    public PersonDto? LastModifiedBy { get; init; }
    public ModificationHistoryDto? History { get; init; }
}
