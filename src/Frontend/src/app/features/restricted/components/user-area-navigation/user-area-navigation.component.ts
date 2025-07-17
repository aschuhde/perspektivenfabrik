import { Component, inject } from '@angular/core';
import {RestrictedRouteNames} from "../../restricted-route-names";
import { TranslatePipe } from '@ngx-translate/core';
import {LogoutService} from "../../../../core/services/logout.service";
import {JWTTokenService} from "../../../../core/services/jwt-token.service";

@Component({
  selector: 'app-user-area-navigation',
  imports: [TranslatePipe],
  templateUrl: './user-area-navigation.component.html',
  styleUrl: './user-area-navigation.component.scss'
})
export class UserAreaNavigationComponent {

  protected readonly RestrictedRouteNames = RestrictedRouteNames;
  logoutService = inject(LogoutService)
  jwtTokenService = inject(JWTTokenService)

  canApproveProjects(){
    return this.jwtTokenService.userHasOnRoleOf(["Admin", "ApprovalUser"]); 
  }

  async signOut() {
    await this.logoutService.signOut();
  }
}
