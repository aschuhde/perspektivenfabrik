import {inject, Injectable} from "@angular/core";
import { Router} from "@angular/router";
import {HomeRouteNames} from "../../features/home/home-route-names";
import {JWTTokenService} from "./jwt-token.service";

@Injectable({
    providedIn: "root"
})
export class LogoutService {
    tokenService = inject(JWTTokenService)
    constructor(private router: Router) {
    }
    signOut(): Promise<boolean>{
        this.tokenService.deleteToken();
        return this.router.navigate([HomeRouteNames.HomeUrl()]);
    }
}