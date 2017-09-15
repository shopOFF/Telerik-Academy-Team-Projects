import { User } from './../models/user.model';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { AngularFireDatabase, FirebaseListObservable } from 'angularfire2/database';
import { AngularFireAuth } from 'angularfire2/auth';
import { FirebaseApp } from 'angularfire2';

@Injectable()
export class UsersService {
    private uid: string;
    private email: string;
    users: any;
    private basePath = '/users';
    constructor(private afAuth: AngularFireAuth, private afDB: AngularFireDatabase) {
        afAuth.authState.subscribe(auth => {
            if (auth !== undefined && auth !== null) {
                this.uid = auth.uid;
                this.email = auth.email;
            }
        });
    }

    addUserToDb() {
        this.users = this.afDB.list(`${this.basePath}/`).push({ email: this.email });
    }
    getUsers(): Observable<User[]> {
        return this.afDB.list('users');
    }
}
