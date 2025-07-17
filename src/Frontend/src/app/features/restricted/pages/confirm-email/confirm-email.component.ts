import {Component, ElementRef, inject, ViewChild, PLATFORM_ID} from '@angular/core';
import { ApiService } from '../../../../server/api/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import {RestrictedRouteNames} from "../../restricted-route-names";
import {stringEmptyPropagate} from "../../../../shared/tools/null-tools";
import { MatFormField, MatInput } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { catchError } from 'rxjs';
import { MatIcon } from '@angular/material/icon';
import {RefreshTokenService} from "../../../../core/services/refresh-token.service";
import {JWTTokenService} from "../../../../core/services/jwt-token.service";
import { TranslatePipe } from '@ngx-translate/core';
import {LogoutService} from "../../../../core/services/logout.service";

@Component({
  selector: 'app-confirm-email',
  imports: [MatFormField, MatInput, FormsModule, MatIcon, TranslatePipe],
  templateUrl: './confirm-email.component.html',
  styleUrl: './confirm-email.component.scss'
})
export class ConfirmEmailComponent {
  private apiService = inject(ApiService)
  private platformId = inject(PLATFORM_ID);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  returnUrl = stringEmptyPropagate(this.route.snapshot.queryParams['returnUrl'], RestrictedRouteNames.MyProjectsUrl());
  private refreshTokenService = inject(RefreshTokenService);
  private jwtTokenService = inject(JWTTokenService);
  private newOtpRequestDate: Date | null = null;
  private logoutService = inject(LogoutService);
  newOtpWaitingSeconds: number | null = null;
  otpWrong = false;
  otpExpired = false;
  errorOccured = false;
  otpConfirmationRunning = false;
  otp1 = "";
  otp2 = "";
  otp3 = "";
  otp4 = "";
  otp5 = "";
  otp6 = "";

  @ViewChild('otp1Input')
  otp1Element!: ElementRef;
  @ViewChild('otp2Input')
  otp2Element!: ElementRef;
  @ViewChild('otp3Input')
  otp3Element!: ElementRef;
  @ViewChild('otp4Input')
  otp4Element!: ElementRef;
  @ViewChild('otp5Input')
  otp5Element!: ElementRef;
  @ViewChild('otp6Input')
  otp6Element!: ElementRef;
  
  get otp(){
    return this.otp1 + this.otp2 + this.otp3 + this.otp4 + this.otp5 + this.otp6;
  }

  onOtp1KeyDown(event: KeyboardEvent) {
    this.onKeyDown(event, this.otp1Element, this.otp2Element);
  }

  onOtp2KeyDown(event: KeyboardEvent) {
    this.onKeyDown(event, this.otp2Element, this.otp3Element);
  }

  onOtp3KeyDown(event: KeyboardEvent) {
    this.onKeyDown(event, this.otp3Element, this.otp4Element);
  }

  onOtp4KeyDown(event: KeyboardEvent) {
    this.onKeyDown(event, this.otp4Element, this.otp5Element);
  }

  onOtp5KeyDown(event: KeyboardEvent) {
    this.onKeyDown(event, this.otp5Element, this.otp6Element);
  }

  onPaste(event: ClipboardEvent) {
    const digits = event.clipboardData?.getData('text')?.trim() ?? "";
    event.preventDefault();
    if(digits.length !== 6 || digits.match(/[^0-9]/g)){
      return;
    }
    this.distributeClipboardText(digits);
  }

  onOtp6KeyDown(event: KeyboardEvent) {
    this.onKeyDown(event, this.otp6Element);
    
    setTimeout(() => {
      this.confirmOtp();
    }, 500);
  }

  confirmOtp(otpText: string = ""){
    const otp = stringEmptyPropagate(otpText, this.otp);
    if(otp.length !== 6){
      return;
    }
    this.otpWrong = false;
    this.otpExpired = false;
    this.errorOccured = false;
    this.otpConfirmationRunning = true;
    this.apiService.webApiEndpointsPostConfirmOtp({
      data: {
        otp: otp
      }
    }).pipe(catchError((error) => {
      this.errorOccured = true;
      throw error;
    })).subscribe(x => {
      if(x.status === "Confirmed" || x.status === "NotRequired"){
        this.refreshTokenService.refreshToken(this.jwtTokenService.getJwtToken()!, this.jwtTokenService.getRefreshToken()!).then(() => {
          this.router.navigateByUrl(this.returnUrl).then();
        });
        return;
      }
      if(x.status === "Wrong"){
        this.otpWrong = true;
      }else if(x.status === "Expired"){
        this.otpExpired = true;
      }
      this.otpConfirmationRunning = false;
    });
  }
  
  private focusNext(next?: ElementRef) {
    if (next) {
      next.nativeElement.focus();
    }
  }

  private async distributeClipboardText(text: string) {
    const digits = text.trim();
    if(digits.length !== 6){
      return;
    }
    
    for(let i = 0; i < digits.length; i++){
      if(i === 0){
        this.otp1 = digits[i];
      }else if(i === 1){
        this.otp2 = digits[i];
      }else if(i === 2){
        this.otp3 = digits[i];
      }else if(i === 3){
        this.otp4 = digits[i];
      }else if(i === 4){
        this.otp5 = digits[i];
      }else if(i === 5){
        this.otp6 = digits[i];
      }
      
    }
    this.confirmOtp(digits);
  }

  onKeyDown(event: KeyboardEvent, current: ElementRef, next?: ElementRef) {
    if (event.key >= '0' && event.key <= '9') {
      if(current.nativeElement.value){
        current.nativeElement.value = "";
      }
      setTimeout(() => this.focusNext(next), 0);
      return;
    }
    if(event.key === "v" && (event.ctrlKey || event.metaKey)){
      return;
    }
    if (event.key !== 'Tab' && event.key !== 'Shift') {
      event.preventDefault();
    }
  }

  get canRequestNewOtp(){
    return !this.newOtpRequestDate || this.newOtpRequestDate <= new Date();
  }
  
  
  
  ngOnInit(){
    this.apiService.webApiEndpointsGetOtpStatus().pipe(catchError((error) => {
      this.errorOccured = true;
      throw error;
    })).subscribe(
      x => {
        if(!x.emailConfirmationRequired){
          this.refreshTokenService.refreshToken(this.jwtTokenService.getJwtToken()!, this.jwtTokenService.getRefreshToken()!).then(() => {
            this.router.navigateByUrl(this.returnUrl).then();
          });
          return;
        }
        if(!x.otpPending){
          this.requestOtp();
          return;
        }
        this.newOtpRequestDate = x.canRequestNewOtpAtUtc ? new Date(x.canRequestNewOtpAtUtc) : null;
      }
    )
    
    
    setInterval(() => {
      if(this.canRequestNewOtp){
        this.newOtpWaitingSeconds = null;
        return;
      }
      this.newOtpWaitingSeconds = Math.floor((this.newOtpRequestDate!.getTime() - (new Date()).getTime()) / 1000);
    }, 1000);
    
  }
  
  ngAfterViewInit(){
    setTimeout(() => {
      this.focusNext(this.otp1Element);
    }, 500);
  }
  
  requestOtp(){
    this.errorOccured = false;
    this.apiService.webApiEndpointsPostRequestOtp({
      
    }).pipe(catchError((error) => {
      this.errorOccured = true;
      throw error;
    })).subscribe(x => {
       this.newOtpRequestDate = x.canRequestNewOtpAtUtc ? new Date(x.canRequestNewOtpAtUtc) : null;
    });
  }

  async signOut(){
    await this.logoutService.signOut();
  }
}
