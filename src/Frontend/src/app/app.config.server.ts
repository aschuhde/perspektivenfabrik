import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { appConfig } from './app.config';
import { provideServerRouting, RenderMode } from '@angular/ssr';
import {AppRouteNames} from "./app.routes.names";

const serverConfig: ApplicationConfig = {
  providers: [
    provideServerRendering(),
    provideServerRouting([{
      path: `${AppRouteNames.RestrictedName}/**`,
      renderMode: RenderMode.Client
    }, {
      path: '**',
      renderMode: RenderMode.Server
    }]),
  ]
};

export const config = mergeApplicationConfig(appConfig, serverConfig);
