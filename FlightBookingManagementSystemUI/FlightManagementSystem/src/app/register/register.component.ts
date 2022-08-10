import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterModel } from '../Models/RegisterModel';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private user:UserService,private _router:Router) { }
  modalText:string="";
  modalHeader:string="";
  registerModel:RegisterModel = new RegisterModel();
  ngOnInit(): void {
  }

  hasError(typeofvalidator:string,controlname:string):Boolean{
    return this.registerModel.formRegisterGroup.controls[controlname].hasError(typeofvalidator);
  
  }
DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}

RegisterUser()
{
  let request = {
    fullName: this.registerModel.fullName,
    //lastName: this.registerModel.lastName,
   // genderId: this.selectedGenderType.id,
    emailId: this.registerModel.emailId,
    userName: this.registerModel.userName,
    password: this.registerModel.password
  }

this.user.RegisterUser(request).subscribe(res => { window.alert("User registered successfully, please login to access your account"), this._router.navigate(['Login'])},
err => { this.DisplayModalPopup("Error", err.error), console.log(err)});
}




}
