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
}