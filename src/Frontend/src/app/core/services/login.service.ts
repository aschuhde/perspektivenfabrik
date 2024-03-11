import {Injectable} from "@angular/core";
import {ActivatedRoute, Router} from "@angular/router";
import { AuthorizationRouteNames } from "../../features/authorization/authorization.routes";

@Injectable({
    providedIn: "root"
})
export class LoginService {
    constructor(private router: Router) {
    }
    signIn(returnUrl? : string): Promise<boolean>{
        return this.router.navigate([AuthorizationRouteNames.LoginUrl()], {queryParams: {returnUrl: returnUrl ?? this.router.url}});
    }
}