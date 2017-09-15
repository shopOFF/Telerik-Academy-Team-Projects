import { NgModule } from '@angular/core';
import { MaterializeModule } from 'angular2-materialize';
import { AlertModule } from 'ngx-bootstrap';

import { ToastModule } from 'ng2-toastr/ng2-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AngularFireModule } from 'angularfire2';
import { AngularFireDatabaseModule, AngularFireDatabase, FirebaseListObservable } from 'angularfire2/database';
import { AngularFireAuthModule } from 'angularfire2/auth';
import { environment } from '../../environments/environment';


@NgModule({
  imports: [
    AlertModule.forRoot(),
    MaterializeModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFireDatabaseModule,
    AngularFireAuthModule,
    ToastModule.forRoot(),
    BrowserAnimationsModule
  ]
})
export class CoreExternalDependenciesModule { }
