import { Injectable } from '@angular/core';
import { JWTTokenService } from '../../../core/services/jwt-token.service';
import { ApiService } from '../../../server/api/api.service';
import { catchError } from 'rxjs';

@Injectable()
export class AuthorizationService {
    constructor(private apiService: ApiService,
                private tokenService: JWTTokenService) {
    }
    
    login(email:string, password:string) {
        return new Promise<boolean>((resolve, reject) => {
            this.apiService.webApiEndpointsJwtToken({
                password: password,
                email: email
            }).subscribe({
                next: (response) => {
                    if(response.token) {
                        this.tokenService.updateToken(response.token, response.refreshToken);
                        resolve(true);
                    }
                },
                error: error => {
                    reject(error);
                }
            });  
        })
    }
}