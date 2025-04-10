import {AppRouteNames} from "../../app.routes.names";

export class HomeRouteNames{
  public static readonly HomeName = "";
  public static readonly ProjectsName = "projects";
  public static readonly ProjectName = `${HomeRouteNames.ProjectsName}/:projectIdentifier`;
  public static readonly InternalName = "internal";
  public static readonly InternalProjectName = `${HomeRouteNames.InternalName}/${HomeRouteNames.ProjectsName}/:projectIdentifier`;
  public static readonly HomeUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.HomeName}`;

  public static ProjectUrl = (entityId: string) => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.ProjectsName}/${entityId}`;
  public static InternalProjectUrl = (entityId: string) => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.InternalName}/${HomeRouteNames.ProjectsName}/${entityId}`;
}