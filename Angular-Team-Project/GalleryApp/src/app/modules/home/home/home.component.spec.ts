/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { RouterTestingModule } from '@angular/router/testing';

import { HomeComponent } from './home.component';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;


  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [HomeComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created successfully', () => {
    expect(component).toBeTruthy();
  });

  it('should property cautionPath return expected value', () => {
    // Arrange
    const testPath = '/test/path';
    // Act & Assert
    expect(component.wallPath = testPath).toEqual(testPath);
  });

  // integration tests
  it('should display the card-title text correctly', () => {
    // Arrange
    const debugElement =  fixture.debugElement.query(By.css('.card-title'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('Welcome');
  });

  it('should display the card-text text correctly', () => {
    // Arrange
    const debugElement =  fixture.debugElement.query(By.css('.card-text'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('To Use The Full Functionality Please');
  });

  it('should display login-link text correctly', () => {
    // Arrange
    const debugElement =  fixture.debugElement.query(By.css('.login-link'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('Log In');
  });

  it('should display signin-link text correctly', () => {
    // Arrange
    const debugElement =  fixture.debugElement.query(By.css('.signin-link'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('No Account?');
  });
});
