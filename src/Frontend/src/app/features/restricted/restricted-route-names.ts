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
  public static readonly UserAreaName = "my-projects";
  public static readonly TempOneUrl = () => `${AppRouteNames.RestrictedUrl()}/temp-one`;
  public static readonly UserAreaUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.UserAreaName}`;
}