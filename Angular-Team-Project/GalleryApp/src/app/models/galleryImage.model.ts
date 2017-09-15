import { User } from './user.model';
import { AuthService } from './../services/auth.service';
import { Observable } from 'rxjs/Observable';
import { AngularFireAuth } from 'angularfire2/auth';
import * as firebase from 'firebase/app';

export class GalleryImage {
    $key: string;
    name?: string;
    url?: string;
    uploadedOn?: string;
    uploadedBy?: string;
}
