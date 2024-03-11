import {Routes} from "@angular/router";
import { LoginComponent } from "./pages/login/login.component";
import { TestComponent } from "./pages/test/test.component";
import { AppRouteNames }  from "../../app.routes";

export class AuthorizationRouteNames{
    public static readonly LoginName = "";
    public static LoginUrl = () => `${AppRouteNames.UserUrl()}/${AuthorizationRouteNames.LoginName}`;

    public static readonly TestName = "";
    public static TestUrl = () => `${AppRouteNames.UserUrl()}/${AuthorizationRouteNames.TestName}`;
}
export const AuthorizationRoutes: Routes = [
    {path: AuthorizationRouteNames.LoginName, component: LoginComponent},
    {path: AuthorizationRouteNames.TestName, component: TestComponent}
]