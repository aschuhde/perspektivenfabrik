namespace Domain.Entities;

public class BaseEntity : BaseEntityWithId
{
    public required DateTimeOffset CreatedOn { get; init; }
    public required Person? CreatedBy { get; init; }
    public required DateTimeOffset LastModifiedOn { get; init; }
    public required Person? LastModifiedBy { get; init; }
    public required ModificationHistory? History { get; init; }
}
