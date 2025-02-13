import { Component, model } from '@angular/core';
import { GalleryImage } from '../../models/gallery-image';

@Component({
  selector: 'app-image-gallery',
  imports: [],
  templateUrl: './image-gallery.component.html',
  styleUrl: './image-gallery.component.scss'
})
export class ImageGalleryComponent {
  images = model.required<GalleryImage[]>();

  get imagesArray(){
    return this.images();
  }
}
