import {Component, CUSTOM_ELEMENTS_SCHEMA, ElementRef, ViewChild, model, effect, PLATFORM_ID, inject} from '@angular/core';
import { GalleryImage } from '../../models/gallery-image';
import { isPlatformBrowser } from '@angular/common';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-image-gallery',
  imports: [MatIcon],
  templateUrl: './image-gallery.component.html',
  styleUrl: './image-gallery.component.scss',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class ImageGalleryComponent {
  @ViewChild('projectList')
  swiperContainer!: ElementRef;
  
  images = model.required<GalleryImage[]>();
  isPreviewShown = false;
  platformId = inject(PLATFORM_ID)
  
  constructor() {
    effect(() => {
      if(this.images().length === 0) {
        return;
      }
      if(!this.swiperContainer?.nativeElement){
        return;
      }
      setTimeout(() => {
        this.swiperContainer.nativeElement.loop = this.images().length > 1;
      }, 100);
    });
    
    if(isPlatformBrowser(this.platformId)){
      document.addEventListener('keydown', (e) => {
        if(e.key === 'Escape'){
          this.hidePreview();
        }
      });
    }
  }
  
  get imagesArray(){
    return this.images();
  }
  
  imageClicked(){
    this.showPreview();
  }
  
  showPreview(){
    this.isPreviewShown = true;
  }
  
  hidePreview(){
    this.isPreviewShown = false;
  }
}
