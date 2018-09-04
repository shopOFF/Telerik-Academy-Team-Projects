import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { GetEventsComponent } from './components/getevents/getevents.component';


@NgModule({
    declarations: [
        AppComponent,
        GetEventsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'get-events', pathMatch: 'full' },
            { path: 'get-events', component: GetEventsComponent },
            { path: '**', redirectTo: 'get-events' }
        ])
    ]
})
export class AppModuleShared {
}
