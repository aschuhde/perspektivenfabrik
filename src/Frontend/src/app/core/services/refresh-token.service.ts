import { Injectable } from '@angular/core';
import { ApiService } from '../../server/api/api.service';
import { JWTTokenService } from './jwt-token.service';

@Injectable({
    providedIn: "root"
})
export class RefreshTokenService {
    constructor(private apiService: ApiService, private tokenService: JWTTokenService) {
    }
    refreshToken(token:string, refreshToken:string) {
        return new Promise<boolean>((resolve) => {
            this.apiService.webApiEndpointsJwtRefreshToken({
                token: token,
                refreshToken: refreshToken
            }).subscribe((response) => {
                if(response?.token) {
                    this.tokenService.updateToken(response.token, response.refreshToken);
                    resolve(true);
                }else{
                    resolve(false);
                }
            });
        })
    }
}