import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { FooterComponent } from './footer/footer.component';
import { MustLogInComponent } from './must-log-in/must-log-in.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [
    NavbarComponent,
    NotFoundComponent,
    FooterComponent,
    MustLogInComponent
],
  exports: [
    NavbarComponent,
    NotFoundComponent,
    FooterComponent,
    MustLogInComponent
  ]
})
export class SharedModule { }
