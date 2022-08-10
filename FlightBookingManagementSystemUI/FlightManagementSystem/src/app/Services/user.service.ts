import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient, private _router:Router) { }

  RegisterUser(request:any)
  {
    return this.http.post<any>("https://localhost:44339/api/User/AddUser", request);
  }
}
