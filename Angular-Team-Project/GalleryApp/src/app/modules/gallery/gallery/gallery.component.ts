import { GalleryImage } from './../../../models/galleryImage.model';
import { ImageService } from './../../../services/image.service';
import { Component, OnInit, OnChanges } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AngularFireDatabase, FirebaseListObservable } from 'angularfire2/database';
import * as firebase from 'firebase/app';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit, OnChanges {
  public images: Observable<GalleryImage[]>;

  constructor(private imageService: ImageService) { }

  getImagesFromDB(imgs: any) {
    this.images = imgs;
  }
  ngOnInit() {
    this.getImagesFromDB(this.imageService.getImages());
  }
  ngOnChanges() {
    this.getImagesFromDB(this.imageService.getImages());
  }
}
