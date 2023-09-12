import { Component, OnInit } from '@angular/core';
import { UsersService } from '../apiServices/users.service';

@Component({
  selector: 'app-addusers',
  templateUrl: './addusers.component.html',
  styleUrls: ['./addusers.component.css']
})
export class AddusersComponent implements OnInit {
  public newNameToAdd : string = '';
  constructor(private userServ : UsersService)
  {
  }
  ngOnInit()
  {
  }
  sendName()
  {
    this.userServ.sendUserName(this.newNameToAdd);
    this.newNameToAdd = '';
  }
  backBtn()
  {
    this.userServ.sendUserName('');
  }
}
