namespace Domain.Entities;

public class BaseEntity : BaseEntityWithId
{
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
    public Person? CreatedBy { get; init; }
    public DateTimeOffset LastModifiedOn { get; init; } = DateTimeOffset.UtcNow;
    public Person? LastModifiedBy { get; init; }
    public ModificationHistory? History { get; init; }
}
