import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './Services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FlightManagementSystem';


  constructor(private _auth:UserService, private _router:Router) {}
  ngOnInit(): void {
  }

  LoggedIn(input:boolean):boolean
  {
    if(input)
    {
      return this._auth.isLoggedIn();
    }
    else
    {
      return !this._auth.isLoggedIn();
    }
  }

  Logout()
  {
     this._auth.LogoutUser();
     //this._router.navigate(['/Home']);
  }

  IsAdminLogin():boolean
  {
     return this._auth.adminLoggedIn();
  }

  IsUserLogin():boolean
  {
    return this._auth.userLoggedIn();
  }

  
}
