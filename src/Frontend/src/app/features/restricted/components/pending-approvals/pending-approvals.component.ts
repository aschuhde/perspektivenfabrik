import { Component, inject } from '@angular/core';
import {ProjectSectionComponent} from "../../../home/components/project-section/project-section.component";
import {Router} from "@angular/router";
import {JWTTokenService} from "../../../../core/services/jwt-token.service";
import {RestrictedRouteNames} from "../../restricted-route-names";

@Component({
  selector: 'app-pending-approvals',
    imports: [
        ProjectSectionComponent
    ],
  templateUrl: './pending-approvals.component.html',
  styleUrl: './pending-approvals.component.scss'
})
export class PendingApprovalsComponent {

  router = inject(Router)
  tokenService = inject(JWTTokenService)
  
  ngOnInit(){
    if(!this.tokenService.userHasOnRoleOf(["Admin", "ApprovalUser"])){
      this.router.navigateByUrl(RestrictedRouteNames.MyProjectsUrl());
    }
  }
}
