import { Component, OnInit } from '@angular/core';
import { UsersService } from '../apiServices/users.service';
import { IUser, IUserDetailes } from '../userInterface';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public usersList: any = [];
  public startEdit: any = [];
  public user : IUser | undefined;
  public userDetailes : IUserDetailes | undefined;
  public newNameToAdd : string = '';
  public newName : string = '';
  constructor(private userService : UsersService)
  {
  }
  ngOnInit()
  {
    this.getUser();
    this.addUser();
  }
  addUser()
  {
    this.newNameToAdd = this.userService.getUserName();
    this.userDetailes = {
      "name": this.newNameToAdd
    };
    this.userService.postU(this.userDetailes).subscribe(data => {this.getUser()});
    console.log(this.newNameToAdd);
    this.newNameToAdd = ''
  }
  getUser()
  {
    this.userService.getU().subscribe(data => this.usersList = data);
  }
  deleteUser(id : any)
  {
    this.userService.deleteU(id).subscribe(data => {this.getUser()});
  }
  editUser(id:any, index:any)
  {
    this.user = {
      "id": id,
      "name": this.newName,
      "isActive": true
    };
    this.userService.putU(this.user).subscribe(data => {this.getUser()});
    this.startEdit[index] = false;
    this.newName="";
  }
  closeEditView(index:any)
  {
    this.newName="";
    this.startEdit[index]=false;
  }
  openEditView(index:any)
  {
    this.startEdit[index]=true;
  }
}
