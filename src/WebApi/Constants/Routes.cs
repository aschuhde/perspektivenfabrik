namespace WebApi.Constants;

public static class Routes
{
    public const string ApiRoute = "/api";
    public const string Example = $"{ApiRoute}/example";
    public const string JwtToken = $"{ApiRoute}/token";
    public const string NotFound = $"{ApiRoute}/{{**catchall}}";
    public const string GetExampleAnonymous = $"{ApiRoute}/example-anonymous";
    public const string JwtRefreshToken = $"{ApiRoute}/refresh-token";
    public const string GetProjects = $"{ApiRoute}/projects";
    public const string GetProject = $"{ApiRoute}/projects/{{ProjectIdentifier}}";
    public const string PostProject = $"{ApiRoute}/projects";
    public const string PutProject = $"{ApiRoute}/projects/{{EntityId:Guid}}";
    public const string GetJsonTypeDiscriminatorNames = $"{ApiRoute}/json-type-discriminator-names";
    public const string GetUsersProjects = $"{ApiRoute}/my/projects";
    public const string GetUsersProject = $"{ApiRoute}/my/projects/{{ProjectIdentifier}}";
    public const string DeleteProject = $"{ApiRoute}/projects/{{ProjectIdentifier}}";
    public const string GetInternalProject = $"{ApiRoute}/shared/projects/{{ProjectIdentifier}}";
    public const string GetAutocompleteEntries = $"{ApiRoute}/autocomplete-entries";
    public const string PostProjectImage = $"{ApiRoute}/projects/{{ProjectIdentifier}}/project-images";
    public const string GetProjectImage = $"{ApiRoute}/projects/{{ProjectIdentifier}}/project-images/{{ImageIdentifier}}";
    public const string PutProjectApprovalStatus = $"{ApiRoute}/projects/{{EntityId:Guid}}/approval-status";
    public const string GetPendingApprovalProjects = $"{ApiRoute}/approval-projects";
    public const string PostProjectReport = $"{ApiRoute}/projects/{{EntityId:Guid}}/report";
    public const string PostRegisterUser = $"{ApiRoute}/users";
    public const string PostRequestOtp = $"{ApiRoute}/users/me/otp-request";
    public const string PostConfirmOtp = $"{ApiRoute}/users/me/otp-confirm";
    public const string GetOtpStatus = $"{ApiRoute}/users/me/otp";
    public const string PutTags = $"{ApiRoute}/tags";
    public const string PutMaterials = $"{ApiRoute}/materials";
    public const string PutSkills = $"{ApiRoute}/skills";
}