/* tslint:disable:no-unused-variable */
import { GalleryModule } from './../modules/gallery/gallery.module';
import { CoreExternalDependenciesModule } from './../core/core-external-dependencies.module';
import { CoreModule } from './../core/core.module';
import { RouterTestingModule } from '@angular/router/testing';


import { TestBed, async, inject } from '@angular/core/testing';
import { ImageService } from './image.service';

describe('Service: Image', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        CoreModule,
        GalleryModule,
        CoreExternalDependenciesModule
      ],
      providers: [],
    }).compileComponents();
  }));

  it('should be able to inject itself successfully...', inject([ImageService], (service: ImageService) => {
    expect(service).toBeTruthy();
  }));
});
