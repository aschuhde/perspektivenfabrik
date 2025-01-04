import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import {TranslateModule} from "@ngx-translate/core";
import {TranslateService} from "@ngx-translate/core";
import {BreakpointObserver, Breakpoints} from "@angular/cdk/layout";

@Component({
    selector: 'app-root',
    imports: [CommonModule, RouterOutlet, TranslateModule],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss'
})
export class AppComponent {
    title = 'frontend';
    screenSize: "small" | "medium" | "large" = "small"
    get isSmallScreen(){
        return this.screenSize == "small";
    }
    get isMediumScreen(){
        return this.screenSize == "medium";
    }
    get isLargeScreen(){
        return this.screenSize == "large";
    }
    constructor(private translate: TranslateService,
        private breakpointObserver: BreakpointObserver
    ) {
        this.translate.addLangs(['en', 'de', 'it']);
        this.translate.setDefaultLang('en');
        this.translate.use('de');

        breakpointObserver.observe([Breakpoints.XSmall, Breakpoints.Small, Breakpoints.Medium, Breakpoints.Large, Breakpoints.XLarge])
            .subscribe(() => {
                this.screenSizeUpdated(breakpointObserver);
        });
        this.screenSizeUpdated(breakpointObserver);
      }

      private screenSizeUpdated(breakpointObserver: BreakpointObserver){
        if(breakpointObserver.isMatched(Breakpoints.XSmall)){
            this.screenSize = "small";
        }
        else if(breakpointObserver.isMatched(Breakpoints.Medium) || breakpointObserver.isMatched(Breakpoints.Small)){
            this.screenSize = "medium";
        }
        else if(breakpointObserver.isMatched(Breakpoints.Large) || breakpointObserver.isMatched(Breakpoints.XLarge)){
            this.screenSize = "large";
        }
      }
}
