import { CoreExternalDependenciesModule } from './../../../core/core-external-dependencies.module';
import { GalleryModule } from './../gallery.module';
import { ImageDetailTitlePipe } from './../../../pipes/imageDetailTitle.pipe';
import { UploadedOnPipe } from './../../../pipes/uploadedOn.pipe';
import { UploadedByPipe } from './../../../pipes/uploadedBy.pipe';
import { AngularFireDatabase } from 'angularfire2/database';
import { AngularFireAuth } from 'angularfire2/auth';
import { AngularFireModule } from 'angularfire2';
import { CoreModule } from './../../../core/core.module';
import { RouterTestingModule } from '@angular/router/testing';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GalleryComponent } from './gallery.component';

describe('GalleryComponent', () => {
  let component: GalleryComponent;
  let fixture: ComponentFixture<GalleryComponent>;

  beforeEach(async(() => {

    TestBed.configureTestingModule({
      declarations: [],
      imports: [
        RouterTestingModule,
        CoreModule,
        GalleryModule,
        CoreExternalDependenciesModule
      ],
      providers: [AngularFireAuth, AngularFireDatabase],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GalleryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be create successfully', () => {
    expect(component).toBeTruthy();
  });
});
