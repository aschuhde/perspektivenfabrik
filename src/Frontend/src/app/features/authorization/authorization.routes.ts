import {Routes} from "@angular/router";
import { LoginComponent } from "./pages/login/login.component";
import { AuthorizationRouteNames } from "./authorization.routes.names";
import { RegisterComponent } from "./pages/register/register.component";
import { ForgotPasswordComponent } from "./pages/forgot-password/forgot-password.component";

export const AuthorizationRoutes: Routes = [
    {path: AuthorizationRouteNames.LoginName, component: LoginComponent},
    {path: AuthorizationRouteNames.RegisterName, component: RegisterComponent},
    {path: AuthorizationRouteNames.ForgotPasswordName, component: ForgotPasswordComponent},
]