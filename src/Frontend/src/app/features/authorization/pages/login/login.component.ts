import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import { AuthorizationService } from '../../services/auth.service';
import {MatInput, MatLabel} from "@angular/material/input";
import {MatFormField} from "@angular/material/form-field";
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { MatIcon } from '@angular/material/icon';
import {AuthorizationRouteNames} from "../../authorization.routes.names";

@Component({
    selector: 'app-login',
  imports: [ReactiveFormsModule, MatFormField, MatLabel, MatInput, TranslateModule, MatIcon],
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
    providers: [AuthorizationService]
})
export class LoginComponent implements OnInit{
  loginForm:FormGroup = this.formBuilder.group({
    email: ['',Validators.required],
    password: ['',Validators.required]
  });

  private returnUrl: string = "/";
  wrongCredentials = false;
  userDoesNotExist = false;
    hasGeneralError = false;
  constructor(private formBuilder:FormBuilder,
              private authService: AuthorizationService,
              private translateService: TranslateService,
              private route: ActivatedRoute,
              private router: Router) {

  }

  ngOnInit(): void {
      this.route.queryParamMap.subscribe(params => {
        this.returnUrl = params.get('returnUrl') ?? this.returnUrl;
      })
    }
    
  onSubmit(): void{
      this.login();
  }
  

  login() {
    const val = this.loginForm.value;
    this.wrongCredentials = false;
    this.userDoesNotExist = false;
    this.hasGeneralError = false;
    if (val.email && val.password) {
      this.authService.login(val.email, val.password)
          .then(
              (response) => {
                this.router.navigateByUrl(this.returnUrl);
              }
          ).catch((error) => {
              if(error.status == 400){
                  this.wrongCredentials = true;   
              }else if(error.status == 404){
                  this.userDoesNotExist = true; 
              }else{
                  this.hasGeneralError = true;
              }
          });
    }
  }
  
    protected readonly AuthorizationRouteNames = AuthorizationRouteNames;
}
