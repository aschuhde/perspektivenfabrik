﻿import { Injectable } from '@angular/core';
import { ApiService } from '../../server/api/api.service';
import { JWTTokenService } from './jwt-token.service';
import { catchError, of, throwError } from 'rxjs';

@Injectable({
    providedIn: "root"
})
export class RefreshTokenService {
    private _isReady: boolean = true;
    constructor(private apiService: ApiService, private tokenService: JWTTokenService) {
    }
    refreshToken(token:string, refreshToken:string) {
        return new Promise<boolean>((resolve, reject) => {     
            this._isReady = false;   
            this.apiService.webApiEndpointsJwtRefreshToken({
                token: token,
                refreshToken: refreshToken
            }).pipe(catchError(() => {
                return of(null);
            })).subscribe((response) => {
                if(response?.token) {
                    this.tokenService.updateToken(response.token, response.refreshToken);
                    this._isReady = true;
                    resolve(true);
                }else{
                    this._isReady = true;
                    resolve(false);
                }
            });
        })
    }

    isReady(){
        return this._isReady;
    }
}