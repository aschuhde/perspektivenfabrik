import { Injectable } from '@angular/core';
import * as jwt_decode from 'jwt-decode';
import { LocalStorageService } from './local-storage.service';

@Injectable({
    providedIn: "root"
})
export class JWTTokenService {

    private jwtToken: string | null | undefined = null;
    private refreshToken: string | null | undefined = null;
    private decodedToken: { [key: string]: string } | null = null;

    constructor(private storageService: LocalStorageService) {
    }

    updateToken(token: string, refreshToken?: string) {
        this.jwtToken = token;
        this.refreshToken = refreshToken;
        this.decodeToken();
        this.storageService.set("id_token", this.jwtToken);
        if(this.refreshToken)
            this.storageService.set("refresh_token", this.refreshToken);
    }

    getJwtToken(){
        if(!this.jwtToken)
            this.jwtToken = this.storageService.get("id_token");
            
        return this.jwtToken;
    }

    getRefreshToken(){
        if(!this.refreshToken)
            this.refreshToken = this.storageService.get("refresh_token");

        return this.refreshToken;
    }
    
    private getDecodedToken(){
        if(!this.decodedToken)
            this.decodeToken();
        
        return this.decodedToken;
    }
    
    private decodeToken() {
        const jwtToken = this.getJwtToken(); 
        this.decodedToken = jwtToken ? jwt_decode.jwtDecode(jwtToken) : null;
    }
    
    getExpiryTime() {
        const token = this.getDecodedToken();
        return token ? (parseInt(token["exp"]) || null) : null;
    }

    hasToken(): boolean{
        return !!this.getJwtToken();
    }
    hasRefreshToken(): boolean{
        return !!this.getRefreshToken();
    }
    hasValidToken(): boolean{
        return this.hasToken() && this.isTokenValid();
    }
    
    isTokenValid(): boolean {
        const expiryTime = this.getExpiryTime();
        if (expiryTime) {
            return ((1000 * expiryTime) - (new Date()).getTime()) > 5000;
        } else {
            return false;
        }
    }
}