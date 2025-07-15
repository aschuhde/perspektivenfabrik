import {Injectable} from "@angular/core";
import {Router} from "@angular/router";
import { AuthorizationRouteNames } from "../../features/authorization/authorization.routes.names";
import {RestrictedRouteNames} from "../../features/restricted/restricted-route-names";

@Injectable({
    providedIn: "root"
})
export class OtpService {
    constructor(private router: Router) {
    }
    confirmEmail(returnUrl? : string): Promise<boolean>{
        return this.router.navigate([RestrictedRouteNames.ConfirmMailUrl()], {queryParams: {returnUrl: returnUrl ?? this.router.url}});
    }
}