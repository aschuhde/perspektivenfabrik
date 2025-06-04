import { Component, inject } from '@angular/core';
import { LanguageService } from '../../../../core/services/language-service.service';
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {FooterComponent} from "../../components/footer/footer.component";

@Component({
  selector: 'app-privacy-policy',
  imports: [
    NavigationBarFullComponent,
    FooterComponent
  ],
  templateUrl: './privacy-policy.component.html',
  styleUrl: './privacy-policy.component.scss'
})
export class PrivacyPolicyComponent {

  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
