import {AppRouteNames} from "../../app.routes.names";

export class HomeRouteNames{
  public static readonly HomeName = "";
  public static readonly ProjectsName = "projects";
  public static readonly HomeUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.HomeName}`;

  public static ProjectUrl = (entityId: string) => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.ProjectsName}/${entityId}`;
}