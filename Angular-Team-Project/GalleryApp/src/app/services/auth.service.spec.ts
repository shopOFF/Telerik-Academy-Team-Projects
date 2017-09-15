/* tslint:disable:no-unused-variable */
import { CoreExternalDependenciesModule } from './../core/core-external-dependencies.module';
import { CoreModule } from './../core/core.module';
import { RouterTestingModule } from '@angular/router/testing';
import { RouterModule } from '@angular/router';

import { TestBed, async, inject } from '@angular/core/testing';
import { AuthService } from './auth.service';
import { FirebaseApp, AngularFireModule } from 'angularfire2';
import * as firebase from 'firebase/app';

describe('Service: Auth', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        CoreModule,
        CoreExternalDependenciesModule
      ],
      providers: [],
    }).compileComponents();
  }));

  it('should be able to inject itself successfully...', inject([AuthService], (service: AuthService) => {
    expect(service).toBeTruthy();
  }));
});
