namespace Application.Models.ApiModels;

public class ApiBaseEntity : ApiBaseEntityWithId
{
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
    public ApiPerson? CreatedBy { get; init; }
    public DateTimeOffset LastModifiedOn { get; init; } = DateTimeOffset.UtcNow;
    public ApiPerson? LastModifiedBy { get; init; }
    public ApiModificationHistory? History { get; init; }
}
