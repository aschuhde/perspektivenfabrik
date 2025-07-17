import { ApplicationConfig } from '@angular/core';
import { provideRouter, withInMemoryScrolling } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideApiService } from './server/configuration';
import { HTTP_INTERCEPTORS, provideHttpClient, withFetch, withInterceptorsFromDi } from "@angular/common/http";
import { BASE_PATH } from './server/variables';
import { environment } from './environments/environment';
import { UniversalAppInterceptor } from './core/interceptors/authorization-http.interceptor';
import { provideTranslateService, TranslateLoader } from '@ngx-translate/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { registerLocaleData } from '@angular/common';
import localeDe from '@angular/common/locales/de';
import localeEn from '@angular/common/locales/en';
import localeIt from '@angular/common/locales/it';
import {TranslateJsonLoader} from "./shared/loaders/translate-json.loader";
import {LanguageAppInterceptor} from "./core/interceptors/language-http.interceptor";

registerLocaleData(localeDe);
registerLocaleData(localeEn);
registerLocaleData(localeIt);

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes, withInMemoryScrolling({
      anchorScrolling: 'enabled',
      scrollPositionRestoration: 'enabled'
  })), provideClientHydration(),
      { provide: HTTP_INTERCEPTORS, useClass: UniversalAppInterceptor, multi: true },    
      { provide: HTTP_INTERCEPTORS, useClass: LanguageAppInterceptor, multi: true },    
      provideApiService(), provideHttpClient(withFetch(), withInterceptorsFromDi()),
      {provide: BASE_PATH, useFactory: () => {
        if(typeof window === 'undefined')
          return "localhost";
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
        useFactory: () => {
            return new TranslateJsonLoader();
        }
      }
    }),
    provideAnimationsAsync('noop'), 
    provideAnimationsAsync()]
};
