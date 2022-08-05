import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { AirportMaster } from '../Models/airportmaster';
import { BookingPassengerModel } from '../Models/BookingPassenderModel';
import { FlightModel } from '../Models/flightModel';
import { FlightSearchRequest } from '../Models/FlightsearchRequest';
import { FlightSearchResults } from '../Models/FlightSearchResults';
import { GenderTypeModel } from '../Models/GenderTypeModel';
import { MealTypeModel } from '../Models/MealTypeModel';
import { SeatTypeModel } from '../Models/SeatTypeModel';
import { AirportService } from '../Services/airport.service';
import { BookingDetailService } from '../Services/booking-detail.service';
import { CommonService } from '../Services/common.service';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.css']
})
export class AddBookingComponent implements OnInit {

 
  constructor(private _router:Router,private _booking:BookingDetailService,private _airport :AirportService,private commonservice:CommonService) { }

  ngOnInit(): void {

    forkJoin(
    this.commonservice.GetGenderTypes(),this._airport.getallAirport(),this.commonservice.GetMealPlanTypes(),this.commonservice.GetSeatTypes())
    .subscribe(([genderResponse,locationResponse,mealtypeResponse,seattypeResponse]) =>
    {
      

      this.BindGender(genderResponse);
      this.BindLocations(locationResponse);
      this.BindMealTypes(mealtypeResponse);
      this.BindSeatTypes(seattypeResponse)
      
    });
  }

  mealTypes:Array<MealTypeModel> = new Array<MealTypeModel>();
  locations:Array<AirportMaster> = new Array<AirportMaster>();
  genders:Array<GenderTypeModel>=new Array<GenderTypeModel>();
  seats:Array<SeatTypeModel>=new Array<SeatTypeModel>();
  modalText:string="";
  modalHeader:string="";
  sourceLocationSelected:any;
  destinationLocationSelected:any;
  instrumentTypeSelected:any;
  mealTypeSelected:any;
  flightSelected:any;
  genderSelected:any;
  seatSelected:any;
  flightSearchRequest:FlightSearchRequest = new FlightSearchRequest();
  flightSearchResults:FlightSearchResults = new FlightSearchResults();
  isSearchClicked:boolean=false;
  noOfPassengers:any;
  totalBookingCost:number=0;
  vacantBusinessOnward:number=0;
  vacantRegularOnward:number=0;
  isBookingProcessing:boolean=false;
bookingPassengers:Array<BookingPassengerModel> = new Array<BookingPassengerModel>();
isOnwardFlightSelected:boolean=true;
onwardFlightSelected:any;
ContactNo:string="";
Address:string="";
scheduleDate:any;
sourceLocationId:any;
destinationLocationId:any;
flightScheduleDayId:any;
DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}

BindGender(gender :any)
{
  this.genders=gender;
  //this.genderSelected=this.genders[0];
}
BindSeatTypes(seat :any)
{
  this.seats=seat;
  this.seatSelected=this.seats[0]
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


SearchFlights()
{
  if(this.flightSearchRequest.onwardTripRequest.travelDateTime == undefined)
  {
    this.DisplayModalPopup("Error", "Please select the onward journey travel date");
    return;
  }
  
  let onwardTripRequest = {
    sourceId: this.sourceLocationSelected.id,
    destinationId: this.destinationLocationSelected.id,
    travelDateTime: this.flightSearchRequest.onwardTripRequest.travelDateTime,
  }

  this.destinationLocationId= this.destinationLocationSelected.airportId;
  this.sourceLocationId= this.sourceLocationSelected.airportId;
  this.scheduleDate= this.flightSearchRequest.onwardTripRequest.travelDateTime == "" ? null : this.flightSearchRequest.onwardTripRequest.travelDateTime;

  this.flightSearchRequest.onwardTripRequest = onwardTripRequest;

 

this._booking.SearchFlight(this.scheduleDate, this.sourceLocationId,this.destinationLocationId)
.subscribe( res => {
  console.log(res);
  this.flightSearchResults.onwardTripResults=res;
  //this.BindSearchResults(a)
},
err => { this.DisplayModalPopup("Error", "An error occurred while searching for flights")});
  
}

ResetFields()
{
  this.vacantBusinessOnward = 0;
  this.vacantRegularOnward = 0;
  this.noOfPassengers = 0;
  this.totalBookingCost = 0;
}
BindSearchResults(result:any)
{
  this.flightSearchResults.onwardTripResults = result.onwardTripResults;
  this.isSearchClicked = true;
}
OnOnwardResultSelect(flight:any)
{
  let selectedIndex = this.flightSearchResults.onwardTripResults.findIndex(x => x.isSelected);
  if(selectedIndex >= 0)
  {
    this.flightSearchResults.onwardTripResults[selectedIndex].isSelected = false;
  }

  flight.isSelected = true;
  this.vacantBusinessOnward = flight.vacantSeatBusinessClass;
  this.vacantRegularOnward = flight.vacantSeatRegularClass;
  this.flightScheduleDayId = flight.flightScheduleDayId
  let tempTotalCost = flight.cost;

  

  this.totalBookingCost = tempTotalCost * Number(this.noOfPassengers);
  debugger;
}

OnPassengerCountChange()
{
  let tempCost = 0;
  let selectedIndex = this.flightSearchResults.onwardTripResults.findIndex(x => x.isSelected);

  if(selectedIndex >= 0)
  {
    tempCost = this.flightSearchResults.onwardTripResults[selectedIndex].ticketCost;
  }



  this.totalBookingCost = tempCost * Number(this.noOfPassengers);
  debugger;
}


ContinueBooking()
{
  let onwardSelectedIndex = this.flightSearchResults.onwardTripResults.findIndex(x => x.isSelected);
  

  if(onwardSelectedIndex < 0 )
  {
    this.DisplayModalPopup("Error", "Please select a Flight to continue booking");
    return;
  }

  if(this.noOfPassengers == undefined || this.noOfPassengers <= 0)
  {
    this.DisplayModalPopup("Error", "Please select a minimum of 1 passenger to continue booking");
    return;
  }

  this.isBookingProcessing = !this.isBookingProcessing;
  
  for(let i = 0; i < Number(this.noOfPassengers); i++)
  {
    let dummyPassenger:BookingPassengerModel = new BookingPassengerModel();
    dummyPassenger.passengerName = "Passenger " + (i+1);
    dummyPassenger.index = i;
    this.bookingPassengers.push(dummyPassenger);
  }


  this.isOnwardFlightSelected = this.flightSearchResults.onwardTripResults.findIndex(x => x.isSelected) >=0 ? true : false;
  
  if(onwardSelectedIndex >= 0)
  {
    this.onwardFlightSelected = this.flightSearchResults.onwardTripResults[onwardSelectedIndex];
    this.isOnwardFlightSelected = this.isOnwardFlightSelected;
  }
 
  window.scroll({ top: 0, left: 0, behavior: 'smooth' });

}


CheckOutBooking()
{
   for(let i = 0; i < this.bookingPassengers.length; i++)
   {
    if(this.ContactNo == "")
    {
      this.DisplayModalPopup("Error","Please enter Contact no");
      return;
    }
    if(this.Address == "")
    {
      this.DisplayModalPopup("Error","Please enter the customer's Address");
      return;
    }
    if(this.bookingPassengers[i].passengerName == "")
     {
        this.DisplayModalPopup("Error","Please enter the passenger name for passenger " + (i + 1));
        return;
     }
     if(this.bookingPassengers[i].genderId <= 0)
     {
      this.DisplayModalPopup("Error","Please select the gender for passenger "+ (i + 1));
      return;
     }
    
    
    }

     if(this.isOnwardFlightSelected )
     {
       if( (Number(this.noOfPassengers) > this.vacantBusinessOnward))
       {
         this.DisplayModalPopup("Error", "Cannot book onward Business ticket as passenger count exceeds vacant seats.");
         return;
       }
       if( (Number(this.noOfPassengers) > this.vacantRegularOnward))
       {
         this.DisplayModalPopup("Error", "Cannot book onward Regular ticket as passenger count exceeds vacant seats.");
         return;
       }
            forkJoin(this._booking.BookFlightTicket(this.GenerateOnwardFlightBookingRequest()))
      .subscribe(res => { window.alert("Booking created successfully, Redirecting you back to the AddBooking page"),
      window.location.reload()
 // this._router.navigate(['addbooking'])
    },
      err => {this.DisplayModalPopup("Error", "An error occurred while adding the Airline schedule inventory")});
     }
     
     

    
  }


  GenerateOnwardFlightBookingRequest()
{
  let bookingOnwardPassengerDetails = new Array<any>();

       for(let i = 0; i < this.bookingPassengers.length; i++)
       {
         let passenger = {
           passengerId:0,
           bookingId:0,
           passengerName:this.bookingPassengers[i].passengerName,
           genderId:this.bookingPassengers[i].genderId,
          // genderType:"",
           mealTypeId:this.mealTypeSelected.mealTypeId,
          // passengerAge:Number(this.bookingPassengers[i].passengerAge),
           //seatNo:this.bookingPassengers[i].seatnoOnward,
          //  isBusinessSeat:this.seatTypeOnward == 'Business' ? true : false,
          //  isRegularSeat:this.seatTypeOnward == 'Regular' ? true : false
         }

         bookingOnwardPassengerDetails.push(passenger);
       }
       let onwardFlightBookingRequest = {

         flightId: this.onwardFlightSelected.flightId,
        bookingId:0,
         contactNo: this.ContactNo,
         address: this.Address,
         noOfSeatsBook: Number(this.noOfPassengers),
         //mealPlanId: this.mealTypeSelected.mealTypeId,
         pnrNumber: "",
         airLineId:1,
         sourceId: this.sourceLocationSelected.airportId,
         destinationId: this.destinationLocationSelected.airportId,
         journeyDate: this.flightSearchRequest.onwardTripRequest.travelDateTime,
         bookingDatetime: this.flightSearchRequest.onwardTripRequest.travelDateTime,
         seatTypeId : this.seatSelected.seatTypeId,
         totalPrice:this.totalBookingCost,
         flightScheduleDayId:this.flightScheduleDayId,
         isActive: true,
         passengerDetails: bookingOnwardPassengerDetails
       }

       return onwardFlightBookingRequest;
}




}

