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
import {SpeechBubbleComponent} from "../../../../shared/components/speech-bubble/speech-bubble.component";
import {InstaIconComponent} from "../../../../shared/components/insta-icon/insta-icon.component";

const SHUFFLED_PEOPLE_KEY = makeStateKey<any[]>('shuffledPeople');
const SHUFFLED_PARTNERS_KEY = makeStateKey<any[]>('shuffledPartners');
const SHUFFLED_PARTNER_POSITIONS_KEY = makeStateKey<any[]>('shuffledPartnerPositions');

interface Partner{
  left: string,
  right: string,
  top: string,
  bottom: string,
  name: string,
  verticalAlign: "flex-start" | "center" | "flex-end"
  horizontalAlign: "flex-start" | "center" | "flex-end"
}

@Component({
  selector: 'app-about-us',
  imports: [TranslateModule, MatIcon, RouterLink, IconThreeHatsTiltedComponent, IconStarComponent, IconRainbowComponent, IconMountainComponent, SpeechBubbleComponent, InstaIconComponent],
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
      title: "aboutUs.dominik-idea-concetto",
      imagePath: "/images/about-us/dominik.jpg"
    },
    {
      name: "Fabian Oberhofer",
      title: "aboutUs.fabian-social-media",
      imagePath: "/images/about-us/fabian.jpg"
    }
  ];
  partnersSorted = [
      "Ghali Egger",
      "Marinus Heindl",
      "Patrizia Raffeiner",
      "Lisa Tappeiner",
      "Marina Pazeller",
      "Marion Gurschler",
      "Gabriel Höllrigl",
      "Valentjna Juric",
      "Daria Habicher",
      "Hannes Götsch"
  ];
  partnerPositions: Partner[] = [];
  platformId = inject(PLATFORM_ID)
  transferState = inject(TransferState)
  translateService = inject(TranslateService)
  people: {
    name: string,
    title: string
    imagePath: string
  }[] = [];
  partners: Partner[] = [];
  hasInstaConsent = false;
  isInstaLoaded = false;
  instaWasLoaded = false;
  waitingForInsta = true;
  
  @ViewChild('instaContainer')
  instaContainer!: ElementRef
  
  constructor() {
    if(isPlatformServer(this.platformId)){
      const shuffledPeople = shuffle(this.peopleSorted);
      const shuffledPartners = shuffle(this.partnersSorted);
      const shuffledPartnerPositions = shuffle(this.getPartnerPositions(this.partnersSorted.length));
      this.transferState.set(SHUFFLED_PEOPLE_KEY, shuffledPeople);
      this.transferState.set(SHUFFLED_PARTNERS_KEY, shuffledPartners);
      this.transferState.set(SHUFFLED_PARTNER_POSITIONS_KEY, shuffledPartnerPositions);
      this.people = shuffledPeople;
      this.partners = this.getPartners(shuffledPartners, shuffledPartnerPositions);
      for(let i = 0; i < this.partners.length; i++){
        
      }
    }else{
      this.people = this.transferState.get(SHUFFLED_PEOPLE_KEY, this.peopleSorted);
      const partners = this.transferState.get(SHUFFLED_PARTNERS_KEY, this.partnersSorted);
      const partnerPositions = this.transferState.get(SHUFFLED_PARTNER_POSITIONS_KEY, this.getPartnerPositions(this.partnersSorted.length));
      this.transferState.remove(SHUFFLED_PEOPLE_KEY);
      this.transferState.remove(SHUFFLED_PARTNERS_KEY);
      this.transferState.remove(SHUFFLED_PARTNER_POSITIONS_KEY);
      this.partners = this.getPartners(partners, partnerPositions);
    }
  }
  getRandomAlign(){
    const random = Math.random();
    if(random < 0.33){
      return "flex-start";
    }else if(random < 0.66){
      return "center";
    }else{
      return "flex-end";
    }
  }
  getPartnerPositions(length: number): Partner[]{
    const positions: Partner[] = [];
    for(let i = 0; i < length; i++){
      positions.push({
        left: Math.random() * 3 + .2 + "rem",
        right: Math.random() * 3 + .2 + "rem",
        top: Math.random() * 3 + .2 + "rem",
        bottom: Math.random() * 3 + .2 + "rem",
        horizontalAlign: this.getRandomAlign(),
        verticalAlign: this.getRandomAlign(),
        name: i.toString()
      });
    }
    return positions;
  }
  getPartners(partners: string[], partnerPositions:Partner[]){
    const result: Partner[] = [];
    for(let i = 0; i < partners.length; i++){
      result.push({
        left: partnerPositions[i].left,
        top: partnerPositions[i].top,
        right: partnerPositions[i].right,
        bottom: partnerPositions[i].bottom,
        name: partners[i],
        horizontalAlign: partnerPositions[i].horizontalAlign,
        verticalAlign: partnerPositions[i].verticalAlign
      });
    }
    return result;
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
  
  reshuffle(){
    this.partners = this.getPartners(shuffle(this.partnersSorted), this.getPartnerPositions(this.partnersSorted.length));
  }
}
