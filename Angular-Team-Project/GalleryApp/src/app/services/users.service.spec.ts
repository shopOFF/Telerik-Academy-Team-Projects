import { CoreExternalDependenciesModule } from './../core/core-external-dependencies.module';
import { CoreModule } from './../core/core.module';
import { RouterTestingModule } from '@angular/router/testing';
/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UsersService } from './users.service';

describe('Service: Users', () => {
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

  it('should be able to inject itself successfully...', inject([UsersService], (service: UsersService) => {
    expect(service).toBeTruthy();
  }));
});
