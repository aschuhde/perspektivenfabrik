import {Routes} from "@angular/router";
import { TestComponent } from "./pages/test/test.component";
import {AppRouteNames} from "../../app.routes.names";
import { UpdateProjectPageComponent } from "./pages/update-project-page/update-project-page.component";
import {InputProjectPageComponent} from "./pages/input-project-page/input-project-page.component";
import { UserAreaPageComponent } from "./pages/user-area-page/user-area-page.component";

export class RestrictedRouteNames{
    public static readonly TestName = "test";
    public static readonly TestUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.TestName}`;
    public static readonly UpdateProjectUrl = (projectIdentifier: string) => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.ProjectsName}/${projectIdentifier}`;
    public static readonly CreateProjectUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.ProjectsName}`;
    public static readonly TempOneName = "temp-one";
    public static readonly UpdateProjectName = "projects/:projectIdentifier";
    public static readonly ProjectsName = "projects";
    public static readonly UserAreaName = "my-projects";
    public static readonly TempOneUrl = () => `${AppRouteNames.RestrictedUrl()}/temp-one`;
    public static readonly UserAreaUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.UserAreaName}`;
}
export const RestrictedRoutes: Routes = [
    {path: RestrictedRouteNames.TestName, component: TestComponent},
    {path: RestrictedRouteNames.ProjectsName, component: InputProjectPageComponent},
    {path: RestrictedRouteNames.UserAreaName, component: UserAreaPageComponent},
    {path: RestrictedRouteNames.UpdateProjectName, component: UpdateProjectPageComponent}
]