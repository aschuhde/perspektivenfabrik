export class AppRouteNames {
    public static readonly RootName = "";
    public static RootUrl = () => `/${AppRouteNames.RootName}`;
    public static readonly HomeName = "home";
    public static HomeUrl = () => `/${AppRouteNames.HomeName}`;
    public static readonly UserName = "user";
    public static UserUrl = () => `/${AppRouteNames.UserName}`;
    public static readonly RestrictedName = "restricted";
    public static RestrictedUrl = () => `/${AppRouteNames.RestrictedName}`;
}