import { Component, ElementRef, inject, makeStateKey, PLATFORM_ID, TransferState, ViewChild } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {shuffle} from "../../../../shared/tools/array-tools";
import {isPlatformBrowser, isPlatformServer } from '@angular/common';
import { RouterLink } from '@angular/router';
import {
    IconThreeHatsTiltedComponent
} from "../../../../shared/components/icon-three-hats-tilted/icon-three-hats-tilted.component";
import {IconStarComponent} from "../../../../shared/components/icon-star/icon-star.component";
import {IconRainbowComponent} from "../../../../shared/components/icon-rainbow/icon-rainbow.component";
import {IconMountainComponent} from "../../../../shared/components/icon-mountain/icon-mountain.component";

const SHUFFLED_PEOPLE_KEY = makeStateKey<any[]>('shuffledPeople');


@Component({
  selector: 'app-about-us',
  imports: [TranslateModule, MatIcon, RouterLink, IconThreeHatsTiltedComponent, IconStarComponent, IconRainbowComponent, IconMountainComponent],
  templateUrl: './about-us.component.html',
  styleUrl: './about-us.component.scss'
})
export class AboutUsComponent {
  peopleSorted = [
    {
      name: "Anton Schuh",
      title: "aboutUs.anton-software-developer",
      imagePath: "/images/about-us/anton.jpg"
    },
    {
      name: "Anna Schuierer",
      title: "aboutUs.anna-designer",
      imagePath: "/images/about-us/anna.jpg"
    },
    {
      name: "Dominik Pazeller",
      title: "aboutUs.dominik-social-media",
      imagePath: "/images/about-us/dominik.jpg"
    },
    {
      name: "Fabian Oberhofer",
      title: "aboutUs.fabian-social-media",
      imagePath: "/images/about-us/fabian.jpg"
    }
  ];
  platformId = inject(PLATFORM_ID)
  transferState = inject(TransferState)
  translateService = inject(TranslateService)
  people: {
    name: string,
    title: string
    imagePath: string
  }[] = [];
  hasInstaConsent = false;
  isInstaLoaded = false;
  instaWasLoaded = false;
  waitingForInsta = true;
  
  @ViewChild('instaContainer')
  instaContainer!: ElementRef
  
  constructor() {
    if(isPlatformServer(this.platformId)){
      const shuffledPeople = shuffle(this.peopleSorted);
      this.transferState.set(SHUFFLED_PEOPLE_KEY, shuffledPeople);
      this.people = shuffledPeople;
    }else{
      this.people = this.transferState.get(SHUFFLED_PEOPLE_KEY, this.peopleSorted);
      this.transferState.remove(SHUFFLED_PEOPLE_KEY);
    }
  }
  
  ngOnInit(){
    
  }

  loadInstagramEmbed(){
    this.waitingForInsta = false;
    if(window.localStorage.getItem("instagram-consent") != "true"){
      return;
    }
    if(this.isInstaLoaded){
      return;
    }
    if(this.instaWasLoaded){
      window.location.hash = "#insta";
      window.location.reload();
    }
    this.isInstaLoaded = true;
    this.hasInstaConsent = true;
    this.instaWasLoaded = true;
    
    
    this.instaContainer.nativeElement.innerHTML = `<blockquote
                    class="instagram-media w-100"
                    data-instgrm-permalink="https://www.instagram.com/perspektivenfabrik/"
                    data-instgrm-version="14">
            </blockquote>`;
    
    const script = document.createElement('script');
    script.async = true;
    script.src = '//www.instagram.com/embed.js';
    this.instaContainer.nativeElement.appendChild(script);
  };
  
  ngAfterViewInit(){
    if(isPlatformBrowser(this.platformId)){
      setTimeout(() => {
        this.loadInstagramEmbed();
      }, 500); 
    }
  }
  
  get language(){
    return this.translateService.currentLang;
  }
  
  consentInsta(){
    window.localStorage.setItem("instagram-consent", "true");
    this.loadInstagramEmbed();
  }
  
  banInsta(){
    window.localStorage.setItem("instagram-consent", "false");
    this.hasInstaConsent = false;
    this.isInstaLoaded = false;
    this.instaContainer.nativeElement.innerHTML = "";
  }
}
