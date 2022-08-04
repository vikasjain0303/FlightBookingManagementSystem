import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { AddFlightScheduleModel } from '../Models/AddScheduleModel';
import { AirportMaster } from '../Models/airportmaster';
import { FlightModel } from '../Models/flightModel';
import { GenderTypeModel } from '../Models/GenderTypeModel';
import { InstrumentTypeModel } from '../Models/InstrumentTypeModel';
import { MealTypeModel } from '../Models/MealTypeModel';
import { AirportService } from '../Services/airport.service';
import { CommonService } from '../Services/common.service';
import { FlightScheduleService } from '../Services/flight-schedule.service';
import { FlightService } from '../Services/flight.service';

@Component({
  selector: 'app-addschedule',
  templateUrl: './addschedule.component.html',
  styleUrls: ['./addschedule.component.css']
})
export class AddscheduleComponent implements OnInit {

  constructor(private _router:Router,private _airport :AirportService,private _scheduleService:FlightScheduleService,private _flight:FlightService,private commonservice:CommonService) { }
  ngOnInit(): void {
    forkJoin(this.commonservice.GetInstrumentTypes(),this._flight.GetAllFlight(),
    this.commonservice.GetGenderTypes(),this._airport.getallAirport(),this.commonservice.GetMealPlanTypes())
    .subscribe(([instrumentResponse,flightResponse,genderResponse,locationResponse,mealtypeResponse]) =>
    {
      
      this.BindInstrumentTypes(instrumentResponse);
      this.BindFlight(flightResponse);
      this.BindGender(genderResponse);
      this.BindLocations(locationResponse);
      this.BindMealTypes(mealtypeResponse);
      
    });
  }
  AddSchedule:AddFlightScheduleModel = new AddFlightScheduleModel();
mealTypes:Array<MealTypeModel> = new Array<MealTypeModel>();
instrumentTypes:Array<InstrumentTypeModel> = new Array<InstrumentTypeModel>();
locations:Array<AirportMaster> = new Array<AirportMaster>();
flights:Array<FlightModel> = new Array<FlightModel>();
genders:Array<GenderTypeModel>=new Array<GenderTypeModel>();
modalText:string="";
modalHeader:string="";
sourceLocationSelected:any;
destinationLocationSelected:any;
instrumentTypeSelected:any;
mealTypeSelected:any;
flightSelected:any;
genderSelected:any;
selectedRadioOption:string="Daily";
today:any;


BindInstrumentTypes(instrumentTypes:any)
{
this.instrumentTypes = instrumentTypes;
this.instrumentTypeSelected = instrumentTypes[0];
}


BindGender(gender :any)
{
  this.genders=gender;
  this.genderSelected=this.genders[0];
}
BindFlight(flight :any)
{
  this.flights=flight;
  this.flightSelected=this.flights[0]
}
BindMealTypes(mealTypes:any)
{
  this.mealTypes = mealTypes;
  this.mealTypeSelected = mealTypes[0];
}

BindLocations(locations:any)
{
  this.locations = locations;
  this.sourceLocationSelected = locations[0];
  this.destinationLocationSelected = locations[0];
}

ToggleDisplay(routeName:string)
{
  switch(routeName)
  {
    case 'ManageSchedule' :
    {
      this._router.navigate(['searchSchedule'])
      break;
    }
  }
}

ProcessDaysSelection()
{
  if(this.selectedRadioOption == 'Daily')
  {
    this.AddSchedule.weekdaysIds = '1,2,3,4,5,6,7';
    
  }
  else if(this.selectedRadioOption == 'Weekdays')
  {
    this.AddSchedule.weekdaysIds = "1,2,3,4,5";
    
  }
  else if(this.selectedRadioOption == 'Weekends')
  {
    this.AddSchedule.weekdaysIds = "6,7";
  }
  // else if(this.selectedRadioOption == 'Specific')
  // {
  //   if
  //   this.AddSchedule.weekdaysIds = this.isSundayChecked ? "7":"";
  //   this.AddSchedule.weekdaysIds = this.isMondayChecked;
  //   this.AddSchedule.tuesday = this.isTuesdayChecked;
  //   this.AddSchedule.wednesday = this.isWednesdayChecked;
  //   this.AddSchedule.thursday = this.isThursdayChecked;
  //   this.AddSchedule.friday = this.isFridayChecked;
  //   this.AddSchedule.saturday = this.isSaturdayChecked;
  // }
}


HasError(typeofvalidator:string,controlname:string):Boolean{
  return this.AddSchedule.formFlightScheduleAddGroup.controls[controlname].hasError(typeofvalidator);
}

AddScheduleData()
{
  if(this.sourceLocationSelected.airportId == this.destinationLocationSelected.airportId)
  {
    this.DisplayModalPopup("Error", "Source and Destination cannot be the same");
    return;
  }
  
  
  this.ProcessDaysSelection();

  let scheduleRequestData = {
    flightId: this.flightSelected.flightId,
    //airlineId: this.airlineSelected.id,
    startDate:this.AddSchedule.startDate.split('T')[0],
  departureTime:this.AddSchedule.startDate.split('T')[1],
  
  endDate:this.AddSchedule.endDate.split('T')[0],
   arrivalTime:this.AddSchedule.endDate.split('T')[1],
    instrumentId: this.instrumentTypeSelected.instrumentId,
    totalSeatBusinessClass: Number(this.AddSchedule.totalSeatBusinessClass),
    totalSeatRegularClass: Number(this.AddSchedule.totalSeatRegularClass),
    vacantSeatBusinessClass: Number(this.AddSchedule.totalSeatBusinessClass),
    vacantSeatRegularClass: Number(this.AddSchedule.totalSeatRegularClass),
    ticketCost: Number(this.AddSchedule.ticketCost),
    rowNo: Number(this.AddSchedule.rowNo),
    mealTypeId: this.mealTypeSelected.mealTypeId,
    sourceId: this.sourceLocationSelected.airportId,
    destinationId: this.destinationLocationSelected.airportId,
    weekdaysIds:this.AddSchedule.weekdaysIds
  }

  this._scheduleService.AddScheduleInventory(scheduleRequestData).subscribe(res=>{ this.DisplayModalPopup("Success", "Airline schedule added successfully"), this.AddSchedule = new AddFlightScheduleModel(); },err=>{ this.DisplayModalPopup("Error", "An error occurred while adding the Airline schedule inventory")})

}
DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}

  OnRadioOptionChange(radioOption:string)
  {
    this.selectedRadioOption = radioOption;
  
  }

  SetMinDate()
{
  this.today = new Date().toISOString().split('T')[0];
  this.today = this.today + 'T00:00';
}
}
