import {Routes} from "@angular/router";
import { TestComponent } from "./pages/test/test.component";
import {AppRouteNames} from "../../app.routes.names";
import { UpdateProjectPageComponent } from "./pages/update-project-page/update-project-page.component";
import {InputProjectPageComponent} from "./pages/input-project-page/input-project-page.component";

export class RestrictedRouteNames{
    public static readonly TestName = "test";
    public static readonly TestUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.TestName}`;
    public static readonly UpdateProjectUrl = (projectIdentifier: string) => `${AppRouteNames.RestrictedUrl()}/projects/${projectIdentifier}`;
    public static readonly TempOneName = "temp-one";
    public static readonly UpdateProjectName = "projects/:projectIdentifier";
    public static readonly InputProjectName = "projects";
    public static readonly TempOneUrl = () => `${AppRouteNames.RestrictedUrl()}/temp-one`;
}
export const RestrictedRoutes: Routes = [
    {path: RestrictedRouteNames.TestName, component: TestComponent},
    {path: RestrictedRouteNames.InputProjectName, component: InputProjectPageComponent},
    {path: RestrictedRouteNames.UpdateProjectName, component: UpdateProjectPageComponent}
]