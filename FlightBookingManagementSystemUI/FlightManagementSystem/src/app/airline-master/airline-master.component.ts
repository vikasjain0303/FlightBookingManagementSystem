import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AirlineModel } from '../Models/airlineModel';
import { AirlineService } from '../Services/airline.service';

@Component({
  selector: 'app-airline-master',
  templateUrl: './airline-master.component.html',
  styleUrls: ['./airline-master.component.css']
})
export class AirlineMasterComponent implements OnInit {

  constructor(private _router:Router, private _airline:AirlineService) { }
  AirlinesList:Array<AirlineModel> = new Array<AirlineModel>();
  modalText:string="";
modalHeader:string="";
  ngOnInit(): void {
    this.getAirLines();
  }
  ToggleDisplay(page:string)
  {
    switch(page)
    {
      case 'AddAirline':
        {
          this._router.navigate(['AddAirline'])
          break;
        }
    }
  }

  getAirLines()
  {
    this._airline.GetAllAirlines().subscribe(data =>{
      this.AirlinesList=data;//console.log(this.allAirport)
    });
  }
  RemoveAirline(airline:AirlineModel)
{
  
  this._airline.RemoveAirline(airline.airlineId).subscribe(res => {this.DisplayModalPopup("Success", "Airline Deleted Successfully"),  this.getAirLines()}, res=> {this.DisplayModalPopup("Error", "An error occurred")});
}
DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}

}
