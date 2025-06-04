import { Component } from '@angular/core';
import {AboutUsComponent} from "../../components/about-us/about-us.component";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {FooterComponent} from "../../components/footer/footer.component";

@Component({
  selector: 'app-about-us-page',
    imports: [
        AboutUsComponent,
        NavigationBarFullComponent,
        FooterComponent
    ],
  templateUrl: './about-us-page.component.html',
  styleUrl: './about-us-page.component.scss'
})
export class AboutUsPageComponent {

}
