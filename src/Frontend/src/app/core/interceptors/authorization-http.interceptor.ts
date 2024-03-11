import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { JWTTokenService } from '../services/jwt-token.service';
@Injectable()
export class UniversalAppInterceptor implements HttpInterceptor {

    constructor( private jwtTokenService: JWTTokenService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        
        if(!this.jwtTokenService.hasValidToken()){
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
    }
}