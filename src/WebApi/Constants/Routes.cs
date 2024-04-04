namespace WebApi.Constants;

public static class Routes
{
    public const string ApiRoute = "/api";
    public const string Example = $"{ApiRoute}/example";
    public const string JwtToken = $"{ApiRoute}/token";
    public const string NotFound = $"{ApiRoute}/{{**catchall}}";
    public const string GetExampleAnonymous = $"{ApiRoute}/example-anonymous";
    public const string JwtRefreshToken = $"{ApiRoute}/refresh-token";
}