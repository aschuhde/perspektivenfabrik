import { inject } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot} from '@angular/router';
import { JWTTokenService } from '../services/jwt-token.service';
import { LoginService } from '../services/login.service';
import { RefreshTokenService } from '../services/refresh-token.service';
import { OtpService } from '../services/otp.service';
import {RestrictedRouteNames} from "../../features/restricted/restricted-route-names";

export const authenticationGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
        const loginService = inject(LoginService);
        const otpService = inject(OtpService);
        const jwtService = inject(JWTTokenService);
        const refreshTokenService = inject(RefreshTokenService);
        const isConfirmMailPage = route.url.length !== 0 && route.url[0].path?.toLowerCase() === RestrictedRouteNames.ConfirmMailName.toLowerCase();
        if(!isConfirmMailPage && jwtService.hasValidTokenButNeedToConfirmEmail()){
            return new Promise((resolve) => {
                otpService.confirmEmail(state.url).then((e) => {
                    resolve(false);
                }).catch((e) => {
                    resolve(false);
                });
            });
        }
        
        if (jwtService.hasValidToken())
            return true;
        
        if(jwtService.hasRefreshToken()){
            let token = jwtService.getJwtToken();
            let refreshToken = jwtService.getRefreshToken();
            if(token && refreshToken)
                return new Promise((resolve) => {
                    refreshTokenService.refreshToken(token, refreshToken).then((value) => {
                        if(value){
                            if(!isConfirmMailPage && jwtService.hasValidTokenButNeedToConfirmEmail()){
                                otpService.confirmEmail(state.url).then((e) => {
                                    resolve(false);
                                }).catch((e) => {
                                    resolve(false);
                                });
                            }
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