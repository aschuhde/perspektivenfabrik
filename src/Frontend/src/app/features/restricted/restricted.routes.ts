import {Routes} from "@angular/router";
import { TestComponent } from "./pages/test/test.component";
import { UpdateProjectPageComponent } from "./pages/update-project-page/update-project-page.component";
import {InputProjectPageComponent} from "./pages/input-project-page/input-project-page.component";
import { UserAreaPageComponent } from "./pages/user-area-page/user-area-page.component";
import { RestrictedRouteNames } from "./restricted-route-names";
import {PreviewProjectPageComponent} from "./pages/preview-project-page/preview-project-page.component";


export const RestrictedRoutes: Routes = [
    {path: RestrictedRouteNames.TestName, component: TestComponent},
    {path: RestrictedRouteNames.ProjectsName, component: InputProjectPageComponent},
    {path: RestrictedRouteNames.UserAreaName, component: UserAreaPageComponent},
    {path: RestrictedRouteNames.UpdateProjectName, component: UpdateProjectPageComponent},
    {path: RestrictedRouteNames.PreviewProjectName, component: PreviewProjectPageComponent}
]