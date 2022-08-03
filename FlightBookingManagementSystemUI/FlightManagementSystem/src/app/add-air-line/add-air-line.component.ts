import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AirlineService } from '../Services/airline.service';
import { AddAirlineModel } from '../Models/AddAirlineModel';

@Component({
  selector: 'app-add-air-line',
  templateUrl: './add-air-line.component.html',
  styleUrls: ['./add-air-line.component.css']
})
export class AddAirLineComponent implements OnInit {

  constructor(private _airline:AirlineService, private _router:Router) { }
  AddAirlineRequest:AddAirlineModel = new AddAirlineModel();
  modalText:string="";
modalHeader:string="";

  ngOnInit(): void {
  }

  
ToggleDisplay(page:string)
{
  switch(page)
  {
      case 'ManageAirline':
        {
          this._router.navigate(['airLinemasterlist'])
          break;
        }
  }
}
hasError(typeofvalidator:string,controlname:string):Boolean{
  return this.AddAirlineRequest.formAirlineAddGroup.controls[controlname].hasError(typeofvalidator);
}
  AddAirline()
  {
    if(this.AddAirlineRequest.airlineName == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline name");
      return;
    }
    if(this.AddAirlineRequest.contactNo == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline contact");
      return;
    }
    if(this.AddAirlineRequest.address == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline address");
      return;
    }
    if(this.AddAirlineRequest.airlineCode == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline address");
      return;
    }
  
    let airlineAddRequest = {
      airlineName:this.AddAirlineRequest.airlineName,
    airlineCode:this.AddAirlineRequest.airlineCode,
    contactNo:this.AddAirlineRequest.contactNo,
    emailId:this.AddAirlineRequest.emailId,
    address:this.AddAirlineRequest.address
  }
  this._airline.AddAirline(airlineAddRequest).subscribe(res=> { this.DisplayModalPopup("Success", "Airline Added Successfully")},res=> {  this.DisplayModalPopup("Error", "An Error occurred while adding the airline")});

  // this._airline.AddAirline(airlineAddRequest).subscribe(res=> { 
  //   if(res=="Success")
  //   {
  //     this.DisplayModalPopup("Success", "Airline Added Successfully")
  //   }
  //   else{
  //     this.DisplayModalPopup("Error", "An Error occurred while adding the airline")
  //   }
  //   });
  this.AddAirlineRequest = new AddAirlineModel();

}
DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}
}
