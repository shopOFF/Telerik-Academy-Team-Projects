import { UsersService } from './../services/users.service';
import { ToastrService } from './../services/toastr.service';
import { AuthGuard } from './../services/guards/auth-guard.service';
import { AuthService } from './../services/auth.service';
import { NgModule, Optional, SkipSelf, ViewContainerRef } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  providers: [AuthService, AuthGuard, ToastrService, UsersService ]
})
export class CoreModule {
  constructor( @Optional() @SkipSelf() parent: CoreModule) {
    if (parent) {
      throw new Error('Core module has already been provided elswhere!');
    }
  }
}

