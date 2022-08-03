import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AirportMaster } from '../Models/airportmaster';
import { FlightScheduleModel } from '../Models/FlightScheduleModel';
import { AirportService } from '../Services/airport.service';
import { FlightScheduleService } from '../Services/flight-schedule.service';

@Component({
  selector: 'app-flight-schedule-master',
  templateUrl: './flight-schedule-master.component.html',
  styleUrls: ['./flight-schedule-master.component.css']
})
export class FlightScheduleMasterComponent implements OnInit {

  sourceLocationSelected:any;
destinationLocationSelected:any;
locations:Array<AirportMaster> = new Array<AirportMaster>();
scheduleDate:any;
sourceLocationId:any;
destinationLocationId:any;
scheduleResults:Array<FlightScheduleModel> = new Array<FlightScheduleModel>();
showNoResultsFound:boolean=false;
modalText:string="";
modalHeader:string="";


  constructor(private _router:Router, private _scheduleService:FlightScheduleService,private airportService:AirportService) { }

  ngOnInit(): void {
    this.airportService.getallAirport().subscribe(data=> this.BindLocations(data));
  }

  
BindLocations(locations:any)
  {
    this.locations = locations;
    //this.locations.splice(0, 0, this.none);
    this.sourceLocationSelected = locations[0];
    this.destinationLocationSelected = locations[0];
  }
  ToggleDisplay(routeName:string)
  {
    switch(routeName)
    {
      case 'AddSchedule' :
      {
        this._router.navigate(['AddSchedule'])
        break;
      }
    }
  }

  SearchSchedule()
{
  
     this.destinationLocationId= this.destinationLocationSelected.airportId;
    this.sourceLocationId= this.sourceLocationSelected.airportId;
    this.scheduleDate= this.scheduleDate == "" ? null : this.scheduleDate;
  
   
  this._scheduleService.SearchSchedule(this.scheduleDate, this.sourceLocationId,this.destinationLocationId).subscribe(res=> this.BindResultToModel(res));
}
BindResultToModel(result:any)
{
  this.scheduleResults = result;
  this.showNoResultsFound = this.scheduleResults.length == 0 ? true : false;

}


}
