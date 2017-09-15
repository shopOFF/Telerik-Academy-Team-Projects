import { Observable } from 'rxjs/Observable';
import { UsersService } from './../../../services/users.service';
import { User } from './../../../models/user.model';
import { Component, OnInit, OnChanges } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit, OnChanges {

  public users: Observable<User[]>;
  constructor(private usersService: UsersService) { }
  ngOnInit() {
    this.users = this.usersService.getUsers();
  }
  ngOnChanges() {
    this.users = this.usersService.getUsers();
  }
}
