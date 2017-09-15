import { Directive, HostListener, ElementRef } from '@angular/core';

@Directive({
  selector: '[appChangeBackground]'
})
export class ChangeBackgroundDirective {

  constructor(private elementRef: ElementRef) { }
  @HostListener('click') onItemClick() {
    this.elementRef.nativeElement.style.background = 'lightgrey';
  }
}
