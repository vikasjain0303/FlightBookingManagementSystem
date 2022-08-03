import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AirportMaster } from '../Models/airportmaster';
import { AirportService } from '../Services/airport.service';

@Component({
  selector: 'app-air-port-master',
  templateUrl: './air-port-master.component.html',
  styleUrls: ['./air-port-master.component.css']
})
export class AirPortMasterComponent implements OnInit {

  allAirport:Array<AirportMaster>= new Array<AirportMaster>();
  //AirlinesList:Array<AirlineModel> = new Array<AirlineModel>();

  constructor(private airportService:AirportService,private _router:Router) { }

  ngOnInit(): void {
    this.getAirports();
  }
  getAirports()
  {
    this.airportService.getallAirport().subscribe(data =>{
      this.allAirport=data//console.log(this.allAirport)
    });
  }

  ToggleDisplay(page:string)
{
  switch(page)
  {
    case 'AddAirPort':
      {
        this._router.navigate(['AddAirPort'])
        break;
      }
  }
}
 

}
