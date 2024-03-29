import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideApiService } from './server/configuration';
import {HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient} from "@angular/common/http";
import { BASE_PATH } from './server/variables';
import { environment } from './environments/environment';
import { UniversalAppInterceptor } from './core/interceptors/authorization-http.interceptor';


export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideClientHydration(),
      { provide: HTTP_INTERCEPTORS, useClass: UniversalAppInterceptor, multi: true },    
      provideApiService(), provideHttpClient(),
      importProvidersFrom(HttpClientModule),
    {provide: BASE_PATH, useFactory: () => {
        if(typeof window === 'undefined')
          return;
        if(environment.development){
            let apiPath = window.localStorage.getItem("development:api-path");
            if(apiPath)
                return apiPath;
        }
        return window?.location.origin;
      } 
    }]
};
