import {AppRouteNames} from "../../app.routes.names";

export class HomeRouteNames{
  
  public static readonly HomeName = "";
  public static readonly ProjectsName = "projects";
  public static readonly AboutUsName = "about-us";
  public static readonly OurMissionName = "our-mission";
  public static readonly PrivacyPolicyName = "privacy";
  public static readonly CookiesName = "cookies";
  public static readonly LegalNoticeName = "legal-notice";
  public static readonly ProjectName = `${HomeRouteNames.ProjectsName}/:projectIdentifier`;
  public static readonly InternalName = "internal";
  public static readonly InternalProjectName = `${HomeRouteNames.InternalName}/${HomeRouteNames.ProjectsName}/:projectIdentifier`;
  public static readonly HomeUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.HomeName}`;
  public static readonly AboutUsUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.AboutUsName}`;
  public static readonly OurMissionUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.OurMissionName}`;
  public static readonly LegalNoticeUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.LegalNoticeName}`;
  public static readonly PrivacyPolicyUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.PrivacyPolicyName}`;
  public static readonly CookiesUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.CookiesName}`;

  public static ProjectUrl = (entityId: string) => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.ProjectsName}/${entityId}`;
  public static InternalProjectUrl = (entityId: string) => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.InternalName}/${HomeRouteNames.ProjectsName}/${entityId}`;
}