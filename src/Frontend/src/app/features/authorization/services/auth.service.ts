import { Injectable } from '@angular/core';
import { JWTTokenService } from '../../../core/services/jwt-token.service';
import { ApiService } from '../../../server/api/api.service';

@Injectable()
export class AuthorizationService {
    constructor(private apiService: ApiService,
                private tokenService: JWTTokenService) {
    }
    
    login(email:string, password:string) {
        return new Promise<boolean>((resolve) => {
            this.apiService.webApiEndpointsJwtToken({
                password: password,
                email: email
            }).subscribe((response) => {
                if(response.token) {
                    this.tokenService.updateToken(response.token, response.refreshToken);
                    resolve(true);
                }
            });  
        })
    }
}