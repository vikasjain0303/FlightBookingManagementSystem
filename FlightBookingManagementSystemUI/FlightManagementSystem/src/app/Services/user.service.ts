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

  loginUser(userDetails:any)
  {
    return this.http.post<any>(this._baseurl +"/Login", userDetails);
  }

  adminLoggedIn()
  {
    return !!localStorage.getItem('userRole') && localStorage.getItem('userRole') == '1';
  }

  userLoggedIn()
  {
    return !!localStorage.getItem('userRole') && localStorage.getItem('userRole') == '2';
  }


  isLoggedIn()
  {
    return !!localStorage.getItem('token');
  }

  LogoutUser()
  {
    localStorage.removeItem('token');
    localStorage.removeItem('userRole')
    this._router.navigate(['/Home']);
  }

  GetToken()
  {
    return localStorage.getItem('token');
  }
}
