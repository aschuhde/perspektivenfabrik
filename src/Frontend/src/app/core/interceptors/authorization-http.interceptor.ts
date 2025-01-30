import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { JWTTokenService } from '../services/jwt-token.service';
import { RefreshTokenService } from '../services/refresh-token.service';
import { Observable, from, switchMap } from 'rxjs';

@Injectable()
export class UniversalAppInterceptor implements HttpInterceptor {

    constructor( private jwtTokenService: JWTTokenService, private refreshTokenService: RefreshTokenService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        const handle: (sendToken: boolean) => Observable<HttpEvent<any>> = (sendToken: boolean) => {
            if(!sendToken){
                return next.handle(req);    
            }
            const token = this.jwtTokenService.getJwtToken();
            req = req.clone({
                url:  req.url,
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
            return next.handle(req);
        };

        if(!this.jwtTokenService.hasValidToken()){
            if(this.jwtTokenService.hasToken() && this.jwtTokenService.hasRefreshToken() && this.refreshTokenService.isReady()){
                const token = this.jwtTokenService.getJwtToken();
                const refreshToken = this.jwtTokenService.getRefreshToken();
                if(token && refreshToken){                                       
                    return from(this.refreshTokenService.refreshToken(token, refreshToken).then((result) => {
                        return handle(result);
                    }).catch(() => {
                        return handle(false);
                    })).pipe(switchMap(x => x));                    
                }
            }            
            return handle(false);
        }
        return handle(true);
    }
}