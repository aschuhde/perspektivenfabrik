import {Routes} from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { ProjectDetailPageComponent } from "./pages/project-detail-page/project-detail-page.component";
import { HomeRouteNames } from "./home-route-names";
import {InternalProjectPageComponent} from "./pages/internal-project-page/internal-project-page.component";
import {AboutUsPageComponent} from "./pages/about-us-page/about-us-page.component";
import {PrivacyPolicyComponent} from "./pages/privacy-policy/privacy-policy.component";
import {LegalNoticeComponent} from "./pages/legal-notice/legal-notice.component";
import { CookiesComponent } from "./pages/cookies/cookies.component";


export const HomeRoutes: Routes = [
    {path: HomeRouteNames.HomeName, component: HomeComponent, pathMatch: "full"},
    {path: HomeRouteNames.ProjectName, component: ProjectDetailPageComponent},
    {path: HomeRouteNames.InternalProjectName, component: InternalProjectPageComponent},
    {path: HomeRouteNames.AboutUsName, component: AboutUsPageComponent},
    {path: HomeRouteNames.PrivacyPolicyName, component: PrivacyPolicyComponent},
    {path: HomeRouteNames.LegalNoticeName, component: LegalNoticeComponent},
    {path: HomeRouteNames.CookiesName, component: CookiesComponent},
]