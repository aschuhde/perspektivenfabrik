import { Component, model } from '@angular/core';
import { GalleryImage } from '../../models/gallery-image';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-image-gallery',
  imports: [MatIcon],
  templateUrl: './image-gallery.component.html',
  styleUrl: './image-gallery.component.scss'
})
export class ImageGalleryComponent {
  images = model.required<GalleryImage[]>();
  selectedIndex: number = 0
  get imagesArray(){
    return this.images();
  }
  
  get canShowNavigation(){
    return this.images().length > 1;
  }
  
  next(){
    if(this.selectedIndex >= this.images().length - 1){
      this.selectedIndex = 0;
    }else{
      this.selectedIndex++;
    }
  }

  prev(){
    if(this.selectedIndex <= 0){
      this.selectedIndex = this.images().length - 1;
    }else{
      this.selectedIndex--;
    }
  }
}
