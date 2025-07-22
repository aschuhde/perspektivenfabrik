import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {FooterComponent} from "../../../home/components/footer/footer.component";
import {TranslatePipe} from "@ngx-translate/core";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";

@Component({
  selector: 'app-forgot-password',
  imports: [
    FooterComponent, TranslatePipe, NavigationBarFullComponent
  ],
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
