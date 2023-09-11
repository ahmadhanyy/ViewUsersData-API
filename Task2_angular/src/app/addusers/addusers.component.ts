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
  addUser()
  {
    this.userServ.postU(this.newNameToAdd).subscribe(data => console.log(data));
    console.log(this.newNameToAdd);
    this.newNameToAdd = ''
  }
}
