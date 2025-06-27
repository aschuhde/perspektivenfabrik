import { RenderMode, provideServerRendering, withRoutes } from '@angular/ssr';
import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { appConfig } from './app.config';
import {AppRouteNames} from "./app.routes.names";

const serverConfig: ApplicationConfig = {
  providers: [provideServerRendering(withRoutes([{
      path: `${AppRouteNames.RestrictedName}/**`,
      renderMode: RenderMode.Client
    }, {
      path: '**',
      renderMode: RenderMode.Server
    }]))]
};

export const config = mergeApplicationConfig(appConfig, serverConfig);
