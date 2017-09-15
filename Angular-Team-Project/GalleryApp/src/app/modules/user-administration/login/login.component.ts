import { User } from './../../../models/user.model';
import { AuthService } from './../../../services/auth.service';
import { Component, OnInit, HostBinding } from '@angular/core';
import { Router } from '@angular/router';
import { AngularFireAuth } from 'angularfire2/auth';
import * as firebase from 'firebase/app';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: Observable<firebase.User>;
  constructor(private authService: AuthService, private router: Router) { }
  googleLogin() {
    this.authService.googleLogin()
      .then(resolve => this.router.navigate(['/gallery']))
      .catch(error => console.log(error));
  }

  facebookLogin() {
    this.authService.facebookLogin()
      .then(resolve => this.router.navigate(['/gallery']))
      .catch(error => console.log(error));
  }
  logOut() {
    this.authService.signOut();
  }
  ngOnInit() {
  }
}
