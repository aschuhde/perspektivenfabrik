import { inject } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot} from '@angular/router';
import { JWTTokenService } from '../services/jwt-token.service';
import { LoginService } from '../services/login.service';
import { RefreshTokenService } from '../services/refresh-token.service';

export const authenticationGuard: CanActivateFn = (_: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
        const loginService = inject(LoginService);
        const jwtService = inject(JWTTokenService);
        const refreshTokenService = inject(RefreshTokenService);

        if (jwtService.hasValidToken())
            return true;
        
        if(jwtService.hasRefreshToken()){
            let token = jwtService.getJwtToken();
            let refreshToken = jwtService.getRefreshToken();
            if(token && refreshToken)
                return new Promise((resolve) => {
                    refreshTokenService.refreshToken(token, refreshToken).then((value) => {
                        if(value){
                            resolve(true);
                            return
                        }
                        loginService.signIn(state.url).then((e) => {
                            resolve(false);
                        }).catch((e) => {
                            resolve(false);
                        }); 
                    });
                });
        }
        
        return new Promise((resolve) => {
            loginService.signIn(state.url).then((e) => {
                resolve(false);
            }).catch((e) => {
                resolve(false);
            });
        });
}