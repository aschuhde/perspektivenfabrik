import { Routes } from '@angular/router';
import { AuthorizationRoutes } from './features/authorization/authorization.routes';
import { RestrictedRoutes } from './features/restricted/restricted.routes';
import { HomeComponent } from './features/home/pages/home/home.component';
import { authenticationGuard } from './core/guards/authorize.guard';

export class AppRouteNames{
    public static readonly RootName = "";
    public static RootUrl = () => `/${AppRouteNames.RootName}`;
    public static readonly HomeName = "home";
    public static HomeUrl = () => `/${AppRouteNames.HomeName}`;
    public static readonly UserName = "user";
    public static UserUrl = () => `/${AppRouteNames.UserName}`;
    public static readonly RestrictedName = "restricted";
    public static RestrictedUrl = () => `/${AppRouteNames.RestrictedName}`;
}

export const routes: Routes = [
    {path: AppRouteNames.RootName, redirectTo: "home", pathMatch: "full"},
    {path: AppRouteNames.HomeName, component: HomeComponent },
    {path: AppRouteNames.UserName, loadChildren: () => AuthorizationRoutes },
    {path: AppRouteNames.RestrictedName, loadChildren: () => RestrictedRoutes, canActivateChild: [authenticationGuard] }
];
