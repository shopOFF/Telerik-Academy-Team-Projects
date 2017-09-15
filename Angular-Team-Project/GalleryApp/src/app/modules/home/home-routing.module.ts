import { AboutComponent } from './about/about.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { AuthGuard } from './../../services/guards/auth-guard.service';
import { ContactsComponent } from './contacts/contacts.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'contacts', component: ContactsComponent },
  { path: 'contacts/details', component: ContactDetailsComponent, canActivate: [AuthGuard] },
  { path: 'about', component: AboutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
