import { ChangeButtonColorDirective } from './../../directives/change-button-color.directive';
import { ChangeBackColorOnHoverDirective } from './../../directives/hide-element.directive';
import { ChangeBackgroundDirective } from './../../directives/change-background.directive';
import { EmailLoginComponent } from './login/email-login/email-login.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgForm, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { UserAdministrationRoutingModule } from './user-administration-routing.module';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { UserComponent } from './user/user.component';
import { UsersComponent } from './users/users.component';

@NgModule({
  imports: [
    CommonModule,
    UserAdministrationRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    LoginComponent,
    SignupComponent,
    EmailLoginComponent,
    UserComponent,
    ChangeBackgroundDirective,
    ChangeBackColorOnHoverDirective,
    ChangeButtonColorDirective,
    UsersComponent
],
  exports: [
    LoginComponent,
    SignupComponent,
    UserComponent,
    EmailLoginComponent,
    UsersComponent
  ]
})
export class UserAdministrationModule { }
