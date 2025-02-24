import {Routes} from "@angular/router";
import { TestComponent } from "./pages/test/test.component";
import {AppRouteNames} from "../../app.routes.names";
import { TempOneComponent } from "./pages/temp-one/temp-one.component";
import { UpdateProjectPageComponent } from "./pages/update-project-page/update-project-page.component";

export class RestrictedRouteNames{
    public static readonly TestName = "test";
    public static readonly TestUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.TestName}`;
    public static readonly TempOneName = "temp-one";
    public static readonly UpdateProjectName = "projects/:projectIdentifier/update";
    public static readonly TempOneUrl = () => `${AppRouteNames.RestrictedUrl()}/temp-one`;
}
export const RestrictedRoutes: Routes = [
    {path: RestrictedRouteNames.TestName, component: TestComponent},
    {path: RestrictedRouteNames.TempOneName, component: TempOneComponent},
    {path: RestrictedRouteNames.UpdateProjectName, component: UpdateProjectPageComponent}
]