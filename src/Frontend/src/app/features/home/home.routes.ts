import {Routes} from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { AppRouteNames } from "../../app.routes.names";
import { TempOneComponent } from "./pages/temp-one/temp-one.component";

export class HomeRouteNames{
    public static readonly HomeName = "";
    public static readonly TempOneName = "temp-one";
    public static readonly HomeUrl = () => `${AppRouteNames.HomeUrl()}/${HomeRouteNames.HomeName}`;
    public static readonly TempOneUrl = () => `${AppRouteNames.HomeUrl()}/temp-one`;
}
export const HomeRoutes: Routes = [
    {path: HomeRouteNames.HomeName, component: HomeComponent, pathMatch: "full"},
    {path: HomeRouteNames.TempOneName, component: TempOneComponent}
]