import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home/home.component';
import { ContactsComponent } from './contacts/contacts.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { AboutComponent } from './about/about.component';

@NgModule({
  imports: [
    CommonModule,
    HomeRoutingModule
  ],
  declarations: [
    HomeComponent,
    ContactsComponent,
    ContactDetailsComponent,
    AboutComponent
],
  exports: [
    HomeComponent,
    ContactsComponent,
    ContactDetailsComponent,
    AboutComponent
  ]
})
export class HomeModule { }
