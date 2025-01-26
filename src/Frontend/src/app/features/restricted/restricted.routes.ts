import {Routes} from "@angular/router";
import { TestComponent } from "./pages/test/test.component";
import {AppRouteNames} from "../../app.routes.names";

export class RestrictedRouteNames{
    public static readonly TestName = "test";
    public static readonly TestUrl = () => `${AppRouteNames.RestrictedUrl()}/${RestrictedRouteNames.TestName}`;
}
export const RestrictedRoutes: Routes = [
    {path: RestrictedRouteNames.TestName, component: TestComponent}
]