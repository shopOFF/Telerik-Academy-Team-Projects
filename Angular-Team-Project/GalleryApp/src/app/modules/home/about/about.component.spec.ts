import { RouterTestingModule } from '@angular/router/testing';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AboutComponent } from './about.component';

describe('AboutComponent', () => {
  let component: AboutComponent;
  let fixture: ComponentFixture<AboutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [AboutComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created successfully', () => {
     // Arrange, Act & Assert
    expect(component).toBeTruthy();
  });

  it('should property wallPath return expected value', () => {
    // Arrange
    const testPath = '/test/path/wall';
    // Act & Assert
    expect(component.cautionPath = testPath).toEqual(testPath);
  });

  // integration tests
  it('should display the card-title text correctly', () => {
    // Arrange
    const debugElement = fixture.debugElement.query(By.css('.card-title'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('About Page');
  });

  it('should display paragraph text correctly', () => {
    // Arrange
    const debugElement = fixture.debugElement.query(By.css('p'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('application main purpose');
  });
});
