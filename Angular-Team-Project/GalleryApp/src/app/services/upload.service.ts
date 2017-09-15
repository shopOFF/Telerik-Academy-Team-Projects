import { NavbarComponent } from './../modules/shared/navbar/navbar.component';
import { Upload } from './../models/upload.model';
import { GalleryImage } from './../models/galleryImage.model';
import { Injectable } from '@angular/core';
import { AngularFireDatabase, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2/database';
import { AngularFireModule } from 'angularfire2';
import * as firebase from 'firebase/app';

@Injectable()
export class UploadService {

    private basePath = '/uploads';
    private uploads: FirebaseListObservable<GalleryImage[]>;
    constructor(private ngFire: AngularFireModule, private afDB: AngularFireDatabase) { }

    uploadFile(upload: Upload) {
        const storageRef = firebase.storage().ref();
        const uploadTask = storageRef.child(`${this.basePath}/${upload.file.name}`).put(upload.file);

        uploadTask.on(firebase.storage.TaskEvent.STATE_CHANGED,

            (snapshot) => {
                upload.progress = (uploadTask.snapshot.bytesTransferred / uploadTask.snapshot.totalBytes) * 100;
                console.log(upload.progress);
            },
            (error) => {
                console.log(error);
            },
            (): any => {
                upload.url = uploadTask.snapshot.downloadURL;
                upload.name = upload.file.name;
                this.saveFileData(upload);
            });
    }

    saveFileData(upload: Upload) {
        this.afDB.list(`${this.basePath}/`).push(upload);
        console.log(`File saved! ${upload.url}`);
    }
}

