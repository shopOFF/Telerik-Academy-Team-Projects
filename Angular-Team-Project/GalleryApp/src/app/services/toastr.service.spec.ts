import { CoreExternalDependenciesModule } from './../core/core-external-dependencies.module';
import { GalleryModule } from './../modules/gallery/gallery.module';
import { CoreModule } from './../core/core.module';
import { RouterTestingModule } from '@angular/router/testing';
/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ToastrService } from './toastr.service';

describe('Service: Toastr', () => {
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

  it('should be able to inject itself successfully...', inject([ToastrService], (service: ToastrService) => {
    expect(service).toBeTruthy();
  }));
});
