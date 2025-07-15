import { AppRouteNames }  from "../../app.routes.names";

export class AuthorizationRouteNames{
    public static readonly LoginName = "";
    public static LoginUrl = () => `${AppRouteNames.UserUrl()}/${AuthorizationRouteNames.LoginName}`;

    public static readonly RegisterName = "register";
    public static RegisterUrl = () => `${AppRouteNames.UserUrl()}/${AuthorizationRouteNames.RegisterName}`;

    public static readonly ForgotPasswordName = "forgot-password";
    public static ForgotPasswordUrl = () => `${AppRouteNames.UserUrl()}/${AuthorizationRouteNames.ForgotPasswordName}`;
}