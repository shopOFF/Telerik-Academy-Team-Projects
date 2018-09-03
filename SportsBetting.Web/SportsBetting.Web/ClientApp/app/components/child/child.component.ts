import { Component, Inject, Input } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'child',
    templateUrl: './child.component.html'
})

export class ChildComponent {
    @Input()
    showMePartially: boolean;
    @Input()
    showMe: boolean;
    // don't forget to import Input from '@angular/core'
}
