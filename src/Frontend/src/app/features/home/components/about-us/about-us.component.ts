import { Component, inject, makeStateKey, PLATFORM_ID, TransferState } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {shuffle} from "../../../../shared/tools/array-tools";
import { isPlatformServer } from '@angular/common';
import { RouterLink } from '@angular/router';

const SHUFFLED_PEOPLE_KEY = makeStateKey<any[]>('shuffledPeople');


@Component({
  selector: 'app-about-us',
  imports: [TranslateModule, MatIcon, RouterLink],
  templateUrl: './about-us.component.html',
  styleUrl: './about-us.component.scss'
})
export class AboutUsComponent {
  peopleSorted = [
    {
      name: "Anton Schuh",
      title: "aboutUs.anton-software-developer",
      imagePath: "/images/about-us/anton.png"
    },
    {
      name: "Anna Schuierer",
      title: "aboutUs.anna-designer",
      imagePath: "/images/about-us/anna.png"
    },
    {
      name: "Dominik Pazeller",
      title: "aboutUs.dominik-social-media",
      imagePath: "/images/about-us/dominik.png"
    },
    {
      name: "Fabian Oberhofer",
      title: "aboutUs.fabian-social-media",
      imagePath: "/images/about-us/fabian.png"
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
  
  get language(){
    return this.translateService.currentLang;
  }
}
