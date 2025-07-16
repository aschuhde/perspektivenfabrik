import { Component, inject } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle } from '@angular/material/dialog';
import { TranslateModule } from '@ngx-translate/core';
import {JWTTokenService} from "../../../../core/services/jwt-token.service";
import {AuthorizationRouteNames} from "../../../authorization/authorization.routes.names";
import {Router} from '@angular/router';
import { MatFormField, MatInput } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../../../server/api/api.service';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-report-project-dialog',
    imports: [
      MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, TranslateModule, MatFormField, FormsModule, MatInput, MatIcon
    ],
  templateUrl: './report-project-dialog.component.html',
  styleUrl: './report-project-dialog.component.scss'
})
export class ReportProjectDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  projectEntityId: string = this.data.projectEntityId ?? "";
  projectTitle: string = this.data.projectTitle ?? "";
  onSubmitted: () => void = this.data.onSubmitted ?? (() => {});
  jwtTokenService = inject(JWTTokenService);
  router = inject(Router);
  apiService = inject(ApiService);
  
  canReport = false;
  reportReturnUrl = "";
  loginUrl= "";
  registerUrl = "";
  reason = "";

  ngOnInit(){
    this.canReport = this.jwtTokenService.hasValidToken() && !this.jwtTokenService.hasValidTokenButNeedToConfirmEmail();
    
    const [path, query] = this.router.url.split('?');
    const params = new URLSearchParams(query || '');
    if (!params.has('open-report-dialog')) {
      params.set('open-report-dialog', 'true');
    }
    this.reportReturnUrl = path + (params.toString() ? '?' + params.toString() : '');
    this.loginUrl = AuthorizationRouteNames.LoginUrl(this.reportReturnUrl);
    this.registerUrl = AuthorizationRouteNames.RegisterUrl(this.reportReturnUrl);
  }
  
  submit(){
    this.apiService.webApiEndpointsPostProjectReport({
      data: {
        reason: this.reason
      }
    }, this.projectEntityId).subscribe(() => {
          this.onSubmitted();
    });
  }
}
