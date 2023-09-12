import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IUser, IUserDetailes } from '../userInterface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private _url : string = 'https://localhost:7235/api/Users';
  public newNameToAdd : string = '';
  constructor(private http: HttpClient)
  {
  }
  getU() : Observable<IUser[]>
  {
    return this.http.get<IUser[]>(this._url);
  }
  postU(username: IUserDetailes) : Observable<IUser[]>
  {
    return this.http.post<IUser[]>(this._url, username);
  }
  putU(user: IUser) : Observable<IUser[]>
  {
    return this.http.put<IUser[]>(this._url, user);
  }
  deleteU(id: any) : Observable<IUser[]>
  {
    return this.http.delete<IUser[]>(this._url + '/' + id);
  }
  sendUserName(username : any)
  {
    this.newNameToAdd = username;
  }
  getUserName()
  {
    return this.newNameToAdd;
  }
}
