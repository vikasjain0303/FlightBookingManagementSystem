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


}
