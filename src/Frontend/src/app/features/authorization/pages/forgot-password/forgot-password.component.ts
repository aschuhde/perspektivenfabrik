import { Component } from '@angular/core';
import {ApiService} from "../../../../server/api/api.service";
import {AuthorizationService} from "../../services/auth.service";
import {LanguageService} from "../../../../core/services/language-service.service";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-forgot-password',
  imports: [],
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.scss'
})
export class ForgotPasswordComponent {

  returnUrl = "/";


  constructor(private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.returnUrl = params.get('returnUrl') ?? this.returnUrl;
    });
  }
}
