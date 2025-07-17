import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocaleDataProvider } from '../services/locale-data.service';

@Injectable()
export class LanguageAppInterceptor implements HttpInterceptor {
    
    constructor( private localeDataProvider: LocaleDataProvider) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(this.addLanguageToHeader(req));
    }
    
    addLanguageToHeader(req: HttpRequest<any>){
        return req.clone({
            setHeaders: {
                "Accept-Language":  this.localeDataProvider.locale
            }
        });
    }
}