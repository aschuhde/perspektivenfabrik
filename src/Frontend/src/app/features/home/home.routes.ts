import {Routes} from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { AppRouteNames } from "../../app.routes.names";
import { ProjectDetailPageComponent } from "./pages/project-detail-page/project-detail-page.component";

export class HomeRouteNames{
    public static readonly HomeName = "";
    public static readonly HomeUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.HomeName}`;    
}
export const HomeRoutes: Routes = [
    {path: HomeRouteNames.HomeName, component: HomeComponent, pathMatch: "full"},
    {path: "projects/:projectIdentifier", component: ProjectDetailPageComponent},
]