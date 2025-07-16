import { AppRouteNames }  from "../../app.routes.names";

export class AuthorizationRouteNames{
    public static readonly LoginName = "";
    public static LoginUrl = (returnUrl = "") => `${AppRouteNames.UserUrl()}/${AuthorizationRouteNames.LoginName}${(returnUrl ? `?returnUrl=${encodeURIComponent(returnUrl)}` : "")}`;

    public static readonly RegisterName = "register";
    public static RegisterUrl = (returnUrl = "") => `${AppRouteNames.UserUrl()}/${AuthorizationRouteNames.RegisterName}${(returnUrl ? `?returnUrl=${encodeURIComponent(returnUrl)}` : "")}`;

    public static readonly ForgotPasswordName = "forgot-password";
    public static ForgotPasswordUrl = (returnUrl = "") => `${AppRouteNames.UserUrl()}/${AuthorizationRouteNames.ForgotPasswordName}${(returnUrl ? `?returnUrl=${encodeURIComponent(returnUrl)}` : "")}`;
}