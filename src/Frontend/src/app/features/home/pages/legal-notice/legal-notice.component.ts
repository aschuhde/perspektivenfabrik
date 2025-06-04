import { Component } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {FooterComponent} from "../../components/footer/footer.component";

@Component({
  selector: 'app-legal-notice',
  imports: [
    NavigationBarFullComponent,
    TranslatePipe,
    FooterComponent
  ],
  templateUrl: './legal-notice.component.html',
  styleUrl: './legal-notice.component.scss'
})
export class LegalNoticeComponent {

}
