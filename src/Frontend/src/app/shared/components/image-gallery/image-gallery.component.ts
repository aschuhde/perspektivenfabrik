import {Component, CUSTOM_ELEMENTS_SCHEMA, ElementRef, ViewChild, model, effect} from '@angular/core';
import { GalleryImage } from '../../models/gallery-image';

@Component({
  selector: 'app-image-gallery',
  imports: [],
  templateUrl: './image-gallery.component.html',
  styleUrl: './image-gallery.component.scss',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class ImageGalleryComponent {
  @ViewChild('projectList')
  swiperContainer!: ElementRef;
  
  images = model.required<GalleryImage[]>();
  
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
  }
  
  get imagesArray(){
    return this.images();
  }
}
