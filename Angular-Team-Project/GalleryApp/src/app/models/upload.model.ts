import { AuthService } from './../services/auth.service';
import { AngularFireAuth } from 'angularfire2/auth';
import { User } from './user.model';
import { Observable } from 'rxjs/Observable';
import * as firebase from 'firebase/app';

export class Upload {
    $key: string;
    name: string;
    file: File;
    url: string;
    progress: number;
    uploadedOn: string;
    uploadedBy: string;

    constructor(private currentFile: File, authService: AuthService) {
        this.file = currentFile;
        authService.getCurrentAuthUser().subscribe(auth => {
            if (auth !== undefined && auth !== null) {
                this.uploadedBy = auth.email;
            }
        });
        this.uploadedOn = (new Date()).toString();
    }
}
