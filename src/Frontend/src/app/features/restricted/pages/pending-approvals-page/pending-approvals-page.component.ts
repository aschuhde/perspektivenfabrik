import { Component } from '@angular/core';
import {
    NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {UserAreaNavigationComponent} from "../../components/user-area-navigation/user-area-navigation.component";
import {FooterComponent} from "../../../home/components/footer/footer.component";
import {PendingApprovalsComponent} from "../../components/pending-approvals/pending-approvals.component";

@Component({
  selector: 'app-pending-approvals-page',
    imports: [
        NavigationBarFullComponent,
        UserAreaNavigationComponent,
        FooterComponent,
        PendingApprovalsComponent
    ],
  templateUrl: './pending-approvals-page.component.html',
  styleUrl: './pending-approvals-page.component.scss'
})
export class PendingApprovalsPageComponent {

}
