import {Routes} from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { ProjectDetailPageComponent } from "./pages/project-detail-page/project-detail-page.component";
import { HomeRouteNames } from "./home-route-names";
import {InternalProjectPageComponent} from "./pages/internal-project-page/internal-project-page.component";
import {AboutUsPageComponent} from "./pages/about-us-page/about-us-page.component";


export const HomeRoutes: Routes = [
    {path: HomeRouteNames.HomeName, component: HomeComponent, pathMatch: "full"},
    {path: HomeRouteNames.ProjectName, component: ProjectDetailPageComponent},
    {path: HomeRouteNames.InternalProjectName, component: InternalProjectPageComponent},
    {path: HomeRouteNames.AboutUsName, component: AboutUsPageComponent}
]