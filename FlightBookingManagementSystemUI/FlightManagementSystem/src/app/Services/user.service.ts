import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private _baseurl="https://localhost:44339/api/User";
  constructor(private http:HttpClient, private _router:Router) { }

  RegisterUser(request:any)
  {
    return this.http.post<any>(this._baseurl+"/AddUser", request);
  }
}
