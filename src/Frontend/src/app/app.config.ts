import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideApiService } from './server/configuration';
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withFetch } from "@angular/common/http";
import { BASE_PATH } from './server/variables';
import { environment } from './environments/environment';
import { UniversalAppInterceptor } from './core/interceptors/authorization-http.interceptor';
import { provideTranslateService, TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

const httpLoaderFactory: (http: HttpClient) => TranslateHttpLoader = (http: HttpClient) =>
  new TranslateHttpLoader(http, './i18n/', '.json');

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideClientHydration(),
      { provide: HTTP_INTERCEPTORS, useClass: UniversalAppInterceptor, multi: true },    
      provideApiService(), provideHttpClient(withFetch()),
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
    }, provideTranslateService({
      loader: {
        provide: TranslateLoader,
        useFactory: httpLoaderFactory,
        deps: [HttpClient],
      }
    }), provideAnimationsAsync('noop'), provideAnimationsAsync()]
};
