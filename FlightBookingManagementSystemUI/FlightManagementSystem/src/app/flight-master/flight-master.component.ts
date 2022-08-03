import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FlightModel } from '../Models/flightModel';

import { FlightService } from '../Services/flight.service';

@Component({
  selector: 'app-flight-master',
  templateUrl: './flight-master.component.html',
  styleUrls: ['./flight-master.component.css']
})
export class FlightMasterComponent implements OnInit {

  FlightList:Array<FlightModel> = new Array<FlightModel>();

  constructor(private _router:Router, private _flight:FlightService) { }

  ngOnInit(): void {
    this.getFlights();
  }

  getFlights()
  {
    this._flight.GetAllFlight().subscribe(data =>{
      this.FlightList=data;console.log(this.FlightList)
    });
  }
  ToggleDisplay(page:string)
  {
    switch(page)
    {
      case 'AddFlight':
        {
          this._router.navigate(['AddFlight'])
          break;
        }
    }
  }


}

