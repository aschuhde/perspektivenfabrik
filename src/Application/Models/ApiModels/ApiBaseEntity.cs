namespace Application.Models.ApiModels;

public class ApiBaseEntity : ApiBaseEntityWithId
{
    public DateTimeOffset? CreatedOn { get; set; } = null;
    public ApiPerson? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; } = null;
    public ApiPerson? LastModifiedBy { get; set; }
    public ApiModificationHistory? History { get; set; }
}
