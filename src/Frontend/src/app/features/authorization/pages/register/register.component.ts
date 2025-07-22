import { Component } from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { MatCheckbox } from '@angular/material/checkbox';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {AuthorizationRouteNames} from "../../authorization.routes.names";
import { ApiService } from '../../../../server/api/api.service';
import { LanguageService } from '../../../../core/services/language-service.service';
import { catchError, of } from 'rxjs';
import {
  ApplicationPostRegisterUserPostRegisterUserPostRegisterUserResponse
} from "../../../../server/model/applicationPostRegisterUserPostRegisterUserPostRegisterUserResponse";
import {AuthorizationService} from "../../services/auth.service";
import {ActivatedRoute, Router } from '@angular/router';
import {RestrictedRouteNames} from "../../../restricted/restricted-route-names";
import {FooterComponent} from "../../../home/components/footer/footer.component";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, MatFormField, MatLabel, MatInput, TranslateModule, MatIcon, MatCheckbox, FooterComponent, NavigationBarFullComponent],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
  providers: [AuthorizationService]
})
export class RegisterComponent {
  registerForm:FormGroup = this.formBuilder.group({
    firstName: ['',Validators.required],
    lastName: ['',Validators.required],
    email: ['',Validators.required],
    password: ['',Validators.required],
    dateOfBirth: [''],
    consentPrivacy: ['']
  });

  mailAlreadyExists = false;
  errorMessage = "";
  hasError = false;
  showInvalidations = false;
  returnUrl = "/";


  constructor(private formBuilder:FormBuilder,
              private apiService: ApiService,
              private authService: AuthorizationService,
              private translateService: TranslateService,
              private languageService: LanguageService,
              private route: ActivatedRoute,
              private router: Router) {

  }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.returnUrl = params.get('returnUrl') ?? this.returnUrl;
    });
  }
  
  get firstnameInvalidMessage(){
    if(!this.showInvalidations){
      return "";
    }
    const firstName = this.registerForm.value.firstName;
    if(!firstName || firstName.length < 1){
      return this.translateService.instant("register.must-not-be-empty", {parameter: this.translateService.instant("register.firstname")});
    }
    if(firstName.length > 100){
      return this.translateService.instant("register.must-not-be-over-n-chars", {n: 100, parameter: this.translateService.instant("register.firstname")});
    }
    return "";
  }

  get lastnameInvalidMessage(){
    if(!this.showInvalidations){
      return "";
    }
    const lastName = this.registerForm.value.lastName;
    if(!lastName || lastName.length < 1){
      return this.translateService.instant("register.must-not-be-empty", {parameter: this.translateService.instant("register.lastname")});
    }
    if(lastName.length > 100){
      return this.translateService.instant("register.must-not-be-over-n-chars", {n: 100, parameter: this.translateService.instant("register.lastname")});
    }
    return "";
  }

  get emailInvalidMessage(){
    if(!this.showInvalidations){
      return "";
    }
    const email = this.registerForm.value.email;
    if(!email || email.length < 1){
      return this.translateService.instant("register.must-not-be-empty", {parameter: this.translateService.instant("register.e-mail")});
    }
    if(email.length > 100){
      return this.translateService.instant("register.must-not-be-over-n-chars", {n: 100, parameter: this.translateService.instant("register.e-mail")});
    }
    return "";
  }
  
  get privacyInvalidMessage(){
    if(!this.showInvalidations){
      return "";
    }
    const consentPrivacy = this.registerForm.value.consentPrivacy;
    if(!consentPrivacy){
      return this.translateService.instant("register.must-consent-privacy");
    }
    return "";
  }

  get passwordInvalidMessage(){
    if(!this.showInvalidations){
      return "";
    }
    const password = this.registerForm.value.password;
    if(!password || password.length < 1){
      return this.translateService.instant("register.must-not-be-empty", {parameter: this.translateService.instant("register.password")});
    }
    const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!"#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~])[A-Za-z\d!"#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~]{8,50}$/;
    if (!passwordPattern.test(password)) {
      return this.translateService.instant("register.password-policy", {n: 50, parameter: this.translateService.instant("register.password")});
    }
    return "";
  }


  onSubmit(): void{
    this.mailAlreadyExists = false;
    this.hasError = false;
    this.errorMessage = "";
    this.showInvalidations = true;
    if(this.firstnameInvalidMessage || this.lastnameInvalidMessage || this.emailInvalidMessage || this.passwordInvalidMessage || this.privacyInvalidMessage){
      return;
    }
    const val = this.registerForm.value;
    this.apiService.webApiEndpointsPostRegisterUser({
      data: {
        email: val.email,
        firstName:  val.firstName,
        lastName:  val.lastName,
        password: val.password,
        languageCode: this.languageService.currentLanguageCode,
        dateOfBirth: val.dateOfBirth,
        consentPrivacy: val.consentPrivacy,
      }
    }).pipe(catchError((error) => {
      this.errorMessage = this.translateService.instant("register.unknown-error-message");
      this.hasError = true;
      throw error;
    })).subscribe((response: ApplicationPostRegisterUserPostRegisterUserPostRegisterUserResponse) => {
      if(response.status == "MailAlreadyExists"){
        this.mailAlreadyExists = true;
        return;
      }
      if(response.status != "Ok"){
        this.errorMessage = this.translateService.instant("register.unknown-error-message");
        this.hasError = true;
        return;
      }
      this.authService.login(val.email, val.password).then(
          (response) => {
            this.router.navigateByUrl(RestrictedRouteNames.ConfirmMailUrl(this.returnUrl));
          }
      ).catch(() => {
        this.errorMessage = this.translateService.instant("register.unknown-error-message");
        this.hasError = true;
      });
    });
  }

  protected readonly AuthorizationRouteNames = AuthorizationRouteNames;
}
