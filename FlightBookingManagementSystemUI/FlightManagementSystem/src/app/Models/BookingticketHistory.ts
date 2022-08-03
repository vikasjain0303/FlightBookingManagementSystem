import { BookingPassengers } from "./BookingPassengers";

export class TicketHistoryModel {
    airlineId:number=0;
    bookingId:number=0;
    flightId:number=0;
    address:string="";
    contactNo:string="";
    noOfSeatsBook:number=0;
    mealPlanId:number=0;
    mealPlanType:string="";
    PnrNumber:string="";
    travelDate:any;
    bookingDatetime:any;
    totalPrice:any;
    isCancelled:boolean=false;
    sourceLocation:string="";
    destinationLocation:string="";
    passengerDetails:Array<BookingPassengers> = new Array<BookingPassengers>();
}