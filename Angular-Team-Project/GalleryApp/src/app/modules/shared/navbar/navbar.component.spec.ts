import { CoreExternalDependenciesModule } from './../../../core/core-external-dependencies.module';
/* tslint:disable:no-unused-variable */
import { CoreModule } from './../../../core/core.module';
import { RouterTestingModule } from '@angular/router/testing';
import { AngularFireDatabase } from 'angularfire2/database';
import { AngularFireAuth } from 'angularfire2/auth';
import { AuthService } from './../../../services/auth.service';
import { AngularFireModule } from 'angularfire2';
import { Router } from '@angular/router';

import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NavbarComponent } from './navbar.component';

describe('NavbarComponent', () => {
  let component: NavbarComponent;
  let fixture: ComponentFixture<NavbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [NavbarComponent],
      imports: [
        RouterTestingModule,
        CoreModule,
        CoreExternalDependenciesModule
      ],
      providers: [AngularFireAuth, AngularFireDatabase],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created successfully', () => {
    // Arrange, Act & Assert
    expect(component).toBeTruthy();
  });

  it('should returnUserNameOutofAEmail method get correct user name from email', () => {
    // Arrange
    const email = 'pesho@abv.bg';
    // Act & Assert
    expect(component.returnUserNameOutofAEmail(email)).toContain('pesho');
  });

  it('should returnUserNameOutofAEmail method throw error email is invalid', () => {
    // Arrange
    const invalidEmail = null;
    // Act & Assert
    expect(error => component.returnUserNameOutofAEmail(invalidEmail)).toThrowError('Email is invalid!');
  });
});
