import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from '../Models/LoginModel';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private user:UserService, private _router:Router) { }
  loginModel:LoginModel = new LoginModel();
  modalText:string="";
  modalHeader:string="";
  ngOnInit(): void {
  }




  hasError(typeofvalidator:string,controlname:string):Boolean{
    return this.loginModel.formLoginGroup.controls[controlname].hasError(typeofvalidator);
  }

  DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}

Login()
  {
    if(this.loginModel.userName == '' || this.loginModel.password == '')
    {
      this.DisplayModalPopup("Error", "Please enter the username and password.")
      return;
    }
   // this.ShowSpinner();
    let loginRequest = {
      username:this.loginModel.userName,
      password:this.loginModel.password
    };
    //  this._auth.loginUser(loginRequest).subscribe(res=>{this.HideSpinner(), localStorage.setItem('token', res.token);
    // localStorage.setItem('userRole', res.role); this._router.navigate(['/Dashboard'])}
    //  ,res=>{console.log(res), this.HideSpinner(), this.DisplayModalPopup("Unauthorised", "Authorisation for the user failed!")});
  }
}
