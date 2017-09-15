import { Directive, HostListener, ElementRef } from '@angular/core';

@Directive({
  selector: '[appChangeButtonColor]'
})
export class ChangeButtonColorDirective {

  constructor(private elementRef: ElementRef) { }
  @HostListener('mouseenter') onItemMouseenter() {
    this.elementRef.nativeElement.style.color = 'blue';
  }
  @HostListener('mouseleave') onItemMouseleave() {
    this.elementRef.nativeElement.style.color = null;
  }
}
