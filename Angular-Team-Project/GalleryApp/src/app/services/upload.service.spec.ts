/* tslint:disable:no-unused-variable */
import { RouterTestingModule } from '@angular/router/testing';
import { CoreModule } from './../core/core.module';
import { CoreExternalDependenciesModule } from './../core/core-external-dependencies.module';
import { GalleryModule } from './../modules/gallery/gallery.module';

import { TestBed, async, inject } from '@angular/core/testing';
import { UploadService } from './upload.service';

describe('Service: Upload', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        CoreModule,
        CoreExternalDependenciesModule,
        GalleryModule
      ],
      providers: [],
    }).compileComponents();
  }));

  it('should be able to inject itself successfully...', inject([UploadService], (service: UploadService) => {
    expect(service).toBeTruthy();
  }));
});
