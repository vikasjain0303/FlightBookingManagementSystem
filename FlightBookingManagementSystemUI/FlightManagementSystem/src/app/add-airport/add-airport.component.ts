import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AddAirPortModel } from '../Models/AddAirportModel';
import { AirportService } from '../Services/airport.service';

@Component({
  selector: 'app-add-airport',
  templateUrl: './add-airport.component.html',
  styleUrls: ['./add-airport.component.css']
})
export class AddAirportComponent implements OnInit {

  constructor(private airportService:AirportService,private _router:Router) { }
  AddAirportRequest:AddAirPortModel = new AddAirPortModel();
  modalText:string="";
modalHeader:string="";
  ngOnInit(): void {
  }

  ToggleDisplay(page:string)
{
  switch(page)
  {
      case 'ManageAirport':
        {
          this._router.navigate(['airportmasterlist'])
          break;
        }
  }
}
hasError(typeofvalidator:string,controlname:string):Boolean{
  return this.AddAirportRequest.formAirportAddGroup.controls[controlname].hasError(typeofvalidator);
}
  AddAirPort()
  {
    if(this.AddAirportRequest.airportName == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline name");
      return;
    }
    if(this.AddAirportRequest.airportCode == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline contact");
      return;
    }
    if(this.AddAirportRequest.country == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline address");
      return;
    }
    if(this.AddAirportRequest.state == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline address");
      return;
    }
  
    let airportAddRequest = {
      airportName:this.AddAirportRequest.airportName,
      country:this.AddAirportRequest.country,
      state:this.AddAirportRequest.state,
      city:this.AddAirportRequest.city,
      airportCode:this.AddAirportRequest.airportCode
  }
 // this.airportService.AddAirport(airportAddRequest).subscribe(res=> { res=> { this.DisplayModalPopup("Success", "Airline Added Successfully")},err=> {  this.DisplayModalPopup("Error", "An Error occurred while adding the airline")});
  this.airportService.AddAirport(airportAddRequest).subscribe(res=> { this.DisplayModalPopup("Success", "AirPort Added Successfully")},err=> {  this.DisplayModalPopup("Error", "An Error occurred while adding the Airport")});
  
  // if(res=="Success")
    // {
    //   this.DisplayModalPopup("Success", "Airport Added Successfully")
    // }
    // else{
    //   this.DisplayModalPopup("Error", "An Error occurred while adding the airport")
    // }
    // })
    
  this.AddAirportRequest = new AddAirPortModel();

}
DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}
}

