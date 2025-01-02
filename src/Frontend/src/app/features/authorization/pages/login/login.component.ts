import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import { AuthorizationService } from '../../services/auth.service';

@Component({
    selector: 'app-login',
    imports: [ReactiveFormsModule],
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
    providers: [AuthorizationService]
})
export class LoginComponent implements OnInit{
  loginForm:FormGroup = this.formBuilder.group({
    email: ['',Validators.required],
    password: ['',Validators.required]
  });

  private returnUrl: string = "/"
  constructor(private formBuilder:FormBuilder,
              private authService: AuthorizationService,
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

    if (val.email && val.password) {
      this.authService.login(val.email, val.password)
          .then(
              (response) => {
                //todo handle response
                this.router.navigateByUrl(this.returnUrl);
              }
          ).catch(() => {
            //todo
          });
    }
  }
}
