import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { AddFlightModel } from '../Models/AddFlightModel';
import { AirlineModel } from '../Models/airlineModel';
import { InstrumentTypeModel } from '../Models/InstrumentTypeModel';
import { AirlineService } from '../Services/airline.service';
import { AirportService } from '../Services/airport.service';
import { CommonService } from '../Services/common.service';
import { FlightService } from '../Services/flight.service';

@Component({
  selector: 'app-add-flight',
  templateUrl: './add-flight.component.html',
  styleUrls: ['./add-flight.component.css']
})
export class AddFlightComponent implements OnInit {

  instrumentTypes:Array<InstrumentTypeModel> = new Array<InstrumentTypeModel>();
airlinetypes:Array<AirlineModel> = new Array<AirlineModel>();
airlineSelected:any;

instrumentTypeSelected:any;

noneinstrument:any={
  instrumentId:0,
    instrumentName:"None"
    
};
modalText:string="";
modalHeader:string="";
noneairline:any={
  airlineId:0,
  airlineName:"None"
    
};
AddFlightRequest:AddFlightModel = new AddFlightModel();

  constructor(private _flight:FlightService,private _router:Router, private commonservice:CommonService,private airline:AirlineService) { }

  ngOnInit(): void {
    forkJoin(this.commonservice.GetInstrumentTypes(),this.airline.GetAllAirlines()).subscribe(([instrumentResponse,airlineResponse]) =>
    {
      
      this.BindInstrumentTypes(instrumentResponse);
      this.BindAirlines(airlineResponse);
      
    });
  }

  BindInstrumentTypes(instrumentTypes:any)
{
this.instrumentTypes = instrumentTypes;
this.instrumentTypes.splice(0, 0, this.noneinstrument);
this.instrumentTypeSelected = instrumentTypes[0];
}

BindAirlines(airlinestype:any)
{
this.airlinetypes = airlinestype;
this.airlinetypes.splice(0, 0, this.noneairline);
this.airlineSelected = airlinestype[0];
}
  ToggleDisplay(page:string)
  {
    switch(page)
    {
        case 'ManagerFlight':
          {
            this._router.navigate(['flightmasterlist'])
            break;
          }
    }
  }
  hasError(typeofvalidator:string,controlname:string):Boolean{
    return this.AddFlightRequest.formFlightAddGroup.controls[controlname].hasError(typeofvalidator);
  }
  AddFlight()
  {
    if(this.AddFlightRequest.flightCode == "")
    {
      this.DisplayModalPopup("Error","Please enter the Airline name");
      return;
    }
    if(this.airlineSelected.airlineId == null ||this.airlineSelected.airlineId==0)
    {
      this.DisplayModalPopup("Error","Please enter the Airline Name");
      return;
    }
    if(this.instrumentTypeSelected.instrumentId == null || this.instrumentTypeSelected.instrumentId==0)
    {
      this.DisplayModalPopup("Error","Please enter the instrument Name");
      return;
    }
    
  
    let flightAddRequest = {
      flightCode:this.AddFlightRequest.flightCode,
      airlineId:this.airlineSelected.airlineId,
      instrumentId:this.instrumentTypeSelected.instrumentId
 
  }
 // this.airportService.AddAirport(airportAddRequest).subscribe(res=> { res=> { this.DisplayModalPopup("Success", "Airline Added Successfully")},err=> {  this.DisplayModalPopup("Error", "An Error occurred while adding the airline")});
  this._flight.AddFlight(flightAddRequest).subscribe(res=> { this.DisplayModalPopup("Success", "Flight Added Successfully")},err=> {  this.DisplayModalPopup("Error", "An Error occurred while adding the Flight")});
  
  // if(res=="Success")
    // {
    //   this.DisplayModalPopup("Success", "Airport Added Successfully")
    // }
    // else{
    //   this.DisplayModalPopup("Error", "An Error occurred while adding the airport")
    // }
    // })
    
  this.AddFlightRequest = new AddFlightModel();

}
DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}
}
