import {Routes} from "@angular/router";
import { TestComponent } from "./pages/test/test.component";
import { UpdateProjectPageComponent } from "./pages/update-project-page/update-project-page.component";
import {InputProjectPageComponent} from "./pages/input-project-page/input-project-page.component";
import { RestrictedRouteNames } from "./restricted-route-names";
import {PreviewProjectPageComponent} from "./pages/preview-project-page/preview-project-page.component";
import {MyAccountPageComponent} from "./pages/my-account-page/my-account-page.component";
import {PendingApprovalsPageComponent} from "./pages/pending-approvals-page/pending-approvals-page.component";
import {MyProjectsPageComponent} from "./pages/my-projects-page/my-projects-page.component";
import {ConfirmEmailComponent} from "./pages/confirm-email/confirm-email.component";


export const RestrictedRoutes: Routes = [
    {path: RestrictedRouteNames.TestName, component: TestComponent},
    {path: RestrictedRouteNames.ProjectsName, component: InputProjectPageComponent},
    {path: RestrictedRouteNames.MyProjectsName, component: MyProjectsPageComponent},
    {path: RestrictedRouteNames.MyAccountName, component: MyAccountPageComponent},
    {path: RestrictedRouteNames.PendingApprovalsName, component: PendingApprovalsPageComponent},
    {path: RestrictedRouteNames.UpdateProjectName, component: UpdateProjectPageComponent},
    {path: RestrictedRouteNames.PreviewProjectName, component: PreviewProjectPageComponent},
    {path: RestrictedRouteNames.ConfirmMailName, component: ConfirmEmailComponent},
]