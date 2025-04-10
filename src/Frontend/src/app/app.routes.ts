import { AppRouteNames } from './app.routes.names';
import { Routes } from '@angular/router';
import { AuthorizationRoutes } from './features/authorization/authorization.routes';
import { RestrictedRoutes } from './features/restricted/restricted.routes';
import { authenticationGuard } from './core/guards/authorize.guard';
import { HomeRoutes } from './features/home/home.routes';


export const routes: Routes = [   
    {path: AppRouteNames.HomeName, loadChildren: () => HomeRoutes },
    {path: AppRouteNames.UserName, loadChildren: () => AuthorizationRoutes },
    {path: AppRouteNames.RestrictedName, loadChildren: () => RestrictedRoutes, canActivateChild: [authenticationGuard] }
];
