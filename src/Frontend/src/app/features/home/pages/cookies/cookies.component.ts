import { Component, inject } from '@angular/core';
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {FooterComponent} from "../../components/footer/footer.component";
import {LanguageService} from "../../../../core/services/language-service.service";

@Component({
  selector: 'app-cookies',
  imports: [NavigationBarFullComponent,
    FooterComponent],
  templateUrl: './cookies.component.html',
  styleUrl: './cookies.component.scss'
})
export class CookiesComponent {
  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
