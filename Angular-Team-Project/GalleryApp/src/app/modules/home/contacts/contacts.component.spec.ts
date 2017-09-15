import { RouterTestingModule } from '@angular/router/testing';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ContactsComponent } from './contacts.component';

describe('ContactsComponent', () => {
  let component: ContactsComponent;
  let fixture: ComponentFixture<ContactsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [ ContactsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created successfully', () => {
    expect(component).toBeTruthy();
  });

  // integration tests
  it('should display the card-title text correctly', () => {
    // Arrange
    const debugElement =  fixture.debugElement.query(By.css('.card-title'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('Contacts');
  });

  it('should display the card-text text correctly', () => {
    // Arrange
    const debugElement =  fixture.debugElement.query(By.css('.card-text'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('Please do not contact us!');
  });

  it('should display login-link text correctly', () => {
    // Arrange
    const debugElement =  fixture.debugElement.query(By.css('.login-link'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('Log In');
  });

  it('should display contacts text correctly', () => {
    // Arrange
    const debugElement =  fixture.debugElement.query(By.css('.contacts'));
    const htmlElement = debugElement.nativeElement;
    // Act & Assert
    expect(htmlElement.textContent).toContain('Contact');
  });
});
