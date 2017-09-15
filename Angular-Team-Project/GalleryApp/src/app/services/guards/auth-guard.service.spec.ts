/* tslint:disable:no-unused-variable */
import { CoreExternalDependenciesModule } from './../../core/core-external-dependencies.module';
import { CoreModule } from './../../core/core.module';
import { RouterTestingModule } from '@angular/router/testing';

import { TestBed, async, inject } from '@angular/core/testing';
import { AuthGuard } from './auth-guard.service';

describe('Service: AuthGuard', () => {
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

  it('should be able to inject itself successfully...', inject([AuthGuard], (service: AuthGuard) => {
    expect(service).toBeTruthy();
  }));
});
