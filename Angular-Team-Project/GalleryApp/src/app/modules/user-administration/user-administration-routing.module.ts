import { UsersComponent } from './users/users.component';
import { SignupComponent } from './signup/signup.component';
import { AuthGuard } from './../../services/guards/auth-guard.service';
import { UserComponent } from './user/user.component';
import { EmailLoginComponent } from './login/email-login/email-login.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: UserComponent, canActivate: [AuthGuard] },
  { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'email-login', component: EmailLoginComponent },
  { path: 'signup', component: SignupComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAdministrationRoutingModule { }
