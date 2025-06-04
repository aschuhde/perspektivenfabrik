import { Component } from '@angular/core';

import { TranslatePipe } from '@ngx-translate/core';
import { MatIcon } from '@angular/material/icon';
import { HomeRouteNames } from '../../home-route-names';
import {InstaIconComponent} from "../../../../shared/components/insta-icon/insta-icon.component";
import {GithubIconComponent} from "../../../../shared/components/github-icon/github-icon.component";

@Component({
  selector: 'app-footer',
    imports: [TranslatePipe, InstaIconComponent, MatIcon, GithubIconComponent],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {

    protected readonly HomeRouteNames = HomeRouteNames;
}
