import {AppRouteNames} from "../../app.routes.names";

export class RestrictedRouteNames{
  public static readonly TestName = "test";
  public static readonly TestUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.TestName}`;
  public static readonly UpdateProjectUrl = (projectIdentifier: string) => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.ProjectsName}/${projectIdentifier}`;
  public static readonly PreviewProjectUrl = (projectIdentifier: string) => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.ProjectsName}/${projectIdentifier}/${RestrictedRouteNames.PreviewName}`;
  public static readonly CreateProjectUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.ProjectsName}`;
  public static readonly TempOneName = "temp-one";
  public static readonly UpdateProjectName = "projects/:projectIdentifier";
  public static readonly PreviewName = "preview";
  public static readonly PreviewProjectName = "projects/:projectIdentifier/preview";
  public static readonly ProjectsName = "projects";
  public static readonly MyProjectsName = "my-projects";
  public static readonly MyAccountName = "my-account";
  public static readonly PendingApprovalsName = "pending-approvals";
  public static readonly TempOneUrl = () => `${AppRouteNames.RestrictedUrl()}/temp-one`;
  public static readonly MyProjectsUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.MyProjectsName}`;
  public static readonly MyAccountUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.MyAccountName}`;
  public static readonly PendingApprovalsUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.PendingApprovalsName}`;

  public static readonly ConfirmMailName = "confirm-email";
  public static readonly ConfirmMailUrl = (returnUrl = "") => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.ConfirmMailName}${(returnUrl ? `?returnUrl=${encodeURIComponent(returnUrl)}` : "")}`;
}