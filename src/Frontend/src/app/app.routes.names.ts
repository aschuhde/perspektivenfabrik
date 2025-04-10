export class AppRouteNames {
    public static readonly HomeName = "";
    public static HomeUrl = () => "";
    public static readonly UserName = "user";
    public static UserUrl = () => `/${AppRouteNames.UserName}`;
    public static readonly RestrictedName = "user-area";
    public static RestrictedUrl = () => `/${AppRouteNames.RestrictedName}`;
}