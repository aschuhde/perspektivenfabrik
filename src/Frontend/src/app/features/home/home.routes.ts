import {Routes} from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { ProjectDetailPageComponent } from "./pages/project-detail-page/project-detail-page.component";
import { HomeRouteNames } from "./home-route-names";


export const HomeRoutes: Routes = [
    {path: HomeRouteNames.HomeName, component: HomeComponent, pathMatch: "full"},
    {path: "projects/:projectIdentifier", component: ProjectDetailPageComponent},
]