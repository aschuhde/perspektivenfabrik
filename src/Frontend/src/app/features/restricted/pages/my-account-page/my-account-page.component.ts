import { Component } from '@angular/core';
import {
    NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {UserAreaNavigationComponent} from "../../components/user-area-navigation/user-area-navigation.component";
import {FooterComponent} from "../../../home/components/footer/footer.component";
import {MyAccountComponent} from "../../components/my-account/my-account.component";

@Component({
  selector: 'app-my-account-page',
    imports: [
        NavigationBarFullComponent,
        UserAreaNavigationComponent,
        FooterComponent,
        MyAccountComponent
    ],
  templateUrl: './my-account-page.component.html',
  styleUrl: './my-account-page.component.scss'
})
export class MyAccountPageComponent {

}
