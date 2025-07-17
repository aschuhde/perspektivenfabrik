import { Component, inject, PLATFORM_ID } from '@angular/core';
import { WelcomeSectionComponent } from '../../components/welcome-section/welcome-section.component';
import { MotivationSectionComponent } from '../../components/motivation-section/motivation-section.component';
import { ProjectSectionComponent } from '../../components/project-section/project-section.component';
import {FooterComponent} from "../../components/footer/footer.component";
import {isPlatformBrowser} from "@angular/common";
import {MatIcon} from "@angular/material/icon";
import {TranslatePipe} from "@ngx-translate/core";

@Component({
    selector: 'app-home',
    imports: [WelcomeSectionComponent, MotivationSectionComponent, ProjectSectionComponent, FooterComponent, MatIcon, TranslatePipe],
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss'
})
export class HomeComponent {
    showFeedbackDiv = false;
    canShowFeedbackDiv = false;
    platformId = inject(PLATFORM_ID);
    
    ngOnInit(){
        if(isPlatformBrowser(this.platformId)) {
            if(window.localStorage.getItem("showFeedbackDiv") !== "false") {
                this.canShowFeedbackDiv = true;
                setTimeout(() => {
                    this.showFeedbackDiv = true;
                }, 500);
            }
        }
    }
    
    hideFeedbackDiv(){
        this.showFeedbackDiv = false;
        this.canShowFeedbackDiv = false;
        window.localStorage.setItem("showFeedbackDiv", "false");
    }
}
