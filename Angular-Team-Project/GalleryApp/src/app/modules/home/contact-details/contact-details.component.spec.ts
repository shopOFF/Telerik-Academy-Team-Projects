import { RouterTestingModule } from '@angular/router/testing';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ContactDetailsComponent } from './contact-details.component';

describe('ContactDetailsComponent', () => {
  let component: ContactDetailsComponent;
  let fixture: ComponentFixture<ContactDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [ContactDetailsComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created successfully', () => {
    expect(component).toBeTruthy();
  });

  // integration tests
  it('should display the card-title text correctly', () => {
    // Arrange
    const debugElement = fixture.debugElement.query(By.css('.card-title'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('Contacts');
  });

  it('should display a different title after title change is done', () => {
    // Arrange
    const debugElement = fixture.debugElement.query(By.css('.card-title'));
    const htmlElement = debugElement.nativeElement;
    // Act
    component.title = 'Test Title';
    fixture.detectChanges();
    // Assert
    expect(htmlElement.textContent).toContain('Test Title');
  });

  it('should display the card-text text correctly', () => {
    // Arrange
    const debugElement = fixture.debugElement.query(By.css('.card-text'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('Shopov');
  });

  it('should display the card-text text correctly', () => {
    // Arrange
    const debugElement = fixture.debugElement.query(By.css('strong'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('GitHub Profile');
  });

});
