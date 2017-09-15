import { UsersService } from './../../../services/users.service';
import { ToastrService } from './../../../services/toastr.service';
import { AuthService } from './../../../services/auth.service';
import { Component, OnInit, HostBinding, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import * as firebase from 'firebase/app';
import { Observable } from 'rxjs/Observable';
import { NgForm, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private router: Router, private authService: AuthService, private toastrService: ToastrService,
    vcr: ViewContainerRef, private usersService: UsersService) {
    this.toastrService.initToasterService(vcr);
  }
  signUp(formData) {
    if (formData.valid) {
      console.log(formData.value);
      this.authService.emailSignUp({ email: formData.value.email, password: formData.value.password })
        .then(resolve => this.router.navigate(['/user']))
        .then(resolve => this.usersService.addUserToDb())
        .catch(error => this.toastrService.getErrorMessage(error.message));
    }
  }
  ngOnInit() {
  }
}
