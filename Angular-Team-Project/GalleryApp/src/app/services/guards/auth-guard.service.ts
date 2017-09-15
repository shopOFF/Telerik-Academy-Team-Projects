import { AuthService } from './../auth.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/take';
import * as firebase from 'firebase/app';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {

    user: Observable<firebase.User>;

    constructor(private authService: AuthService, private router: Router) {
        this.user = authService.getCurrentAuthUser();
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.user.map((auth) => {
            if (!auth) {
                this.router.navigateByUrl('/must-login');
                return false;
            }
            return true;
        }).take(1);
    }
}
